using Xpense.application.Expenses.Interfaces;
using Xpense.application.Expenses.Models;
using Xpense.domain.Expenses;
using Xpense.infrastructure.Repositories.Expenses.Interfaces;

namespace Xpense.application.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<ExpenseReadDto> Create(ExpenseCreateDto expense)
        {
            Expense expenseEntity = new Expense();
            expenseEntity.Concepto = expense.Concepto;
            expenseEntity.Monto = expense.Monto;
            expenseEntity.CategoriaId = expense.CategoriaId;
            expenseEntity.UsuarioId = (Guid)expense.UsuarioId;
            expenseEntity.CreatedAt = DateTime.Now;
            expenseEntity.UpdatedAt = DateTime.Now;
            expenseEntity.CreatedBy = "API Request";

            expenseEntity = await _expenseRepository.Create(expenseEntity);

            ExpenseReadDto result = new ExpenseReadDto
            {
                Id = expenseEntity.Id,
                Concepto = expenseEntity.Concepto,
                Monto = expenseEntity.Monto,
                CategoriaId = expenseEntity.CategoriaId,
                CreatedAt = expenseEntity.CreatedAt,
                UsuarioId = expenseEntity.UsuarioId
            };
            return await Task.FromResult(result);
        }

        public async Task<ExpenseReadDto> Update(ExpenseReadDto expense)
        {
            var expenseEntity = await _expenseRepository.Get(expense.Id, (Guid)expense.UsuarioId);
            expenseEntity.Concepto = expense.Concepto;
            expenseEntity.Monto = expense.Monto;
            expenseEntity.CategoriaId = expense.CategoriaId;
            expenseEntity.UpdatedAt = DateTime.Now;
            await _expenseRepository.Update(expenseEntity);
            return expense;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _expenseRepository.Delete(id);
            return result;
        }

        public async Task<ExpenseReadDto> Get(int id, Guid userId)
        {
            var expenseEntity = await _expenseRepository.Get(id, userId);

            var mappedExpense = new ExpenseReadDto
            {
                Id = expenseEntity.Id,
                Concepto = expenseEntity.Concepto,
                Monto = expenseEntity.Monto,
                CategoriaId = expenseEntity.CategoriaId,
                CreatedAt = expenseEntity.CreatedAt,
                UsuarioId = expenseEntity.UsuarioId
            };

            return mappedExpense;
        }


        public async Task<ICollection<ExpenseReadDto>> GetAll()
        {
            var expenses = await _expenseRepository.GetAll();
            var expensesList = expenses.Select(x => new ExpenseReadDto
            {
                Id = x.Id,
                Concepto = x.Concepto,
                Monto = x.Monto,
                CategoriaId = x.CategoriaId,
                CreatedAt = x.CreatedAt,
                UsuarioId = x.UsuarioId
            }).ToList();
            return expensesList;
        }

        public async Task<ICollection<ExpenseReadDto>> GetAllForUser(string sort, string filter, Guid userId)
        {
            var expenses = await _expenseRepository.GetAllForUser(sort, filter, userId);

            var expensesList = expenses.Select(x => new ExpenseReadDto
            {
                Id = x.Id,
                Concepto = x.Concepto,
                Monto = x.Monto,
                CategoriaId = x.CategoriaId,
                CreatedAt = x.CreatedAt,
                UsuarioId = x.UsuarioId
            }).ToList();
            return expensesList;
        }


        public async Task<ICollection<ExpenseReadDto>> GetTotalsForUser(string attribute, Guid userId)
        {
            var expenses = await _expenseRepository.GetTotalsForUser(attribute, userId);

            var expensesList = expenses.Select(x => new ExpenseReadDto
            {
                Id = x.Id,
                Concepto = x.Concepto,
                Monto = x.Monto,
                CategoriaId = x.CategoriaId,
                CreatedAt = x.CreatedAt,
                UsuarioId = x.UsuarioId
            }).ToList();

            return expensesList;
        }
    }
}
