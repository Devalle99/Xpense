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

        public async Task<Expense> Update(Expense expense)
        {
            _context.Expenses.Update(expense);
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

        public async Task<Expense> Get(int id, Guid userId)
        {
            var expenseEntity = await _context.Expenses.FirstAsync(e => e.Id == id && e.UsuarioId == userId);

            return expenseEntity;
        }

        public async Task<ICollection<Expense>> GetAll()
        {
            var expenseEntities = await _context.Expenses.OrderByDescending(x => x.CreatedAt).ToListAsync();
            return expenseEntities;
        }

        public async Task<ICollection<Expense>> GetAllForUser(Guid userId, string orderBy, int? categoryId, decimal? minAmount, DateTime? startDate, DateTime? endDate)
        {
            IQueryable<Expense> query = _context.Expenses
                .Include(e => e.Categoria)
                .Where(e => e.UsuarioId == userId);

            // Aplicar filtros
            if (categoryId.HasValue)
            {
                query = query.Where(e => e.Categoria != null && e.Categoria.Id == categoryId);
            }

            if (minAmount.HasValue)
            {
                query = query.Where(e => e.Monto >= minAmount.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(e => e.CreatedAt >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.CreatedAt <= endDate.Value);
            }

            switch (orderBy)
            {
                case "conceptoAsc":
                    query = query.OrderBy(e => e.Concepto);
                    break;
                case "conceptoDesc":
                    query = query.OrderByDescending(e => e.Concepto);
                    break;
                case "montoAsc":
                    query = query.OrderBy(e => e.Monto);
                    break;
                case "montoDesc":
                    query = query.OrderByDescending(e => e.Monto);
                    break;
                case "categoriaAsc":
                    query = query.OrderBy(e => e.Categoria != null ? e.Categoria.Nombre : "Sin categoría");
                    break;
                case "categoriaDesc":
                    query = query.OrderByDescending(e => e.Categoria != null ? e.Categoria.Nombre : "Sin categoría");
                    break;
                case "fechaAsc":
                    query = query.OrderBy(e => e.CreatedAt);
                    break;
                case "fechaDesc":
                    query = query.OrderByDescending(e => e.CreatedAt);
                    break;
                default:
                    query = query.OrderBy(e => e.CreatedAt);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<string> GetTotalsForUser(Guid userId, string attribute, int? categoryId, DateTime? month)
        {
            IQueryable<Expense> query = _context.Expenses
                .Where(e => e.UsuarioId == userId);

            // Aplicar filtros adicionales según el atributo
            switch (attribute)
            {
                case "general":
                    // No se requieren filtros adicionales para el total general
                    break;
                case "categoria":
                    if (categoryId.HasValue)
                    {
                        if (categoryId == 0)
                        {
                            query = query.Where(e => e.Categoria == null);
                        }
                        else
                        {
                            query = query.Where(e => e.Categoria != null && e.Categoria.Id == categoryId.Value);

                        }
                    }
                    break;
                case "mes":
                    if (month.HasValue)
                    {
                        int year = month.Value.Year;
                        int monthNumber = month.Value.Month;
                        query = query.Where(e => e.CreatedAt.Year == year && e.CreatedAt.Month == monthNumber);
                    }
                    break;
                default:
                    break;
            }

            // Calcular la suma del miembro Monto
            string totalAmount = (await query.SumAsync(e => e.Monto)).ToString("0.00");

            return totalAmount;
        }

        public async Task<Dictionary<string, decimal>> GetTotalsByCategory(Guid userId, DateTime startDate, DateTime endDate)
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();

            var query = _context.Expenses
                .Where(e => e.UsuarioId == userId && e.CreatedAt >= startDate && e.CreatedAt <= endDate)
                .GroupBy(e => e.Categoria != null ? e.Categoria.Nombre : "Sin categoría")
                .Select(group => new
                {
                    CategoryName = group.Key,
                    TotalAmount = group.Sum(e => e.Monto)
                });

            var groupedResults = await query.ToListAsync();

            foreach (var item in groupedResults)
            {
                result.Add(item.CategoryName, item.TotalAmount);
            }

            return result;
        }
    }
}
