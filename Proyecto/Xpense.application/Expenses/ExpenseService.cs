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
            expenseEntity.UsuarioId = expense.UsuarioId;
            expenseEntity.Concepto = expense.Concepto;
            expenseEntity.Monto = expense.Monto;
            expenseEntity.CategoriaId = expense.CategoriaId;

            expenseEntity = await _expenseRepository.Create(expenseEntity);

            ExpenseReadDto result = new ExpenseReadDto
            {
                Id = expenseEntity.Id,
                Concepto = expenseEntity.Concepto
            };
            return await Task.FromResult(result);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _expenseRepository.Delete(id);
            return result;
        }

        public async Task<ExpenseReadDto> Get(int id)
        {
            var expenseEntity = await _expenseRepository.Get(id);
            var mappedExpense = new ExpenseReadDto
            {
                Id = expenseEntity.Id,
                UsuarioId = expenseEntity.UsuarioId,
                Concepto = expenseEntity.Concepto,
                Monto = expenseEntity.Monto,
                CategoriaId = expenseEntity.CategoriaId
            };
            return mappedExpense;
        }

        public async Task<ICollection<ExpenseReadDto>> GetAll()
        {
            var expenses = await _expenseRepository.GetAll();
            var expensesList = expenses.Select(x => new ExpenseReadDto
            {
                Id = x.Id,
                UsuarioId = x.UsuarioId,
                Concepto = x.Concepto,
                Monto = x.Monto,
                CategoriaId = x.CategoriaId
            }).ToList();
            return expensesList;
        }

        public async Task<ExpenseReadDto> Update(ExpenseReadDto expense)
        {
            var expenseEntity = await _expenseRepository.Get(expense.Id);
            expenseEntity.Prioridad = expense.Prioridad;
            expenseEntity.Nombre = expense.Nombre;
            expenseEntity.Descripcion = expense.Descripcion;
            expenseEntity.FechaDePublicacion = expense.FechaDePublicacion;
            expenseEntity.ImageUrl = expense.ImageUrl;
            expenseEntity.Resumen = expense.Resumen;
            await _expenseRepository.Update(expenseEntity);
            return expense;
        }
    }
}
