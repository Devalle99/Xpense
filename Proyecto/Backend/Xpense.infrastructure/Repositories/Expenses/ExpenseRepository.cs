using Microsoft.EntityFrameworkCore;
using Xpense.domain.Categories;
using Xpense.domain.Expenses;
using Xpense.infrastructure.Data;
using Xpense.infrastructure.Repositories.Expenses.Interfaces;

namespace Xpense.infrastructure.Repositories.Expenses
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly XpenseContext _context;
        public ExpenseRepository(XpenseContext context)
        {
            _context = context;
        }
        public async Task<Expense> Create(Expense expense)
        {
            await _context.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> Delete(int id)
        {
            var expenseEntity = await _context.Expenses.FirstAsync(e => e.Id == id);
            _context.Expenses.Remove(expenseEntity);
            var isDeleted = await _context.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<Expense> Get(int id, Guid UsuarioId)
        {
            var expenseEntity = await _context.Expenses.FirstAsync(e => e.Id == id && e.UsuarioId == UsuarioId);

            return expenseEntity;
        }

        public async Task<ICollection<Expense>> GetAll()
        {
            //var expenseEntities = await _context.Expenses.OrderBy(x => x.Monto).Where(x => x.Monto > Monto).ToListAsync();
            var expenseEntities = await _context.Expenses.OrderBy(x => x.Monto).ToListAsync();
            return expenseEntities;
        }

        public async Task<Expense> Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
            return expense;
        }
    }
}
