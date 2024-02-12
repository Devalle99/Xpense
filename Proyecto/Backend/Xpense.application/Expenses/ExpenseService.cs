using Xpense.application.Expenses.Interfaces;
using Xpense.application.Expenses.Models;
using Xpense.domain.Expenses;
using Xpense.infrastructure.Repositories.Expenses.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

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

        public async Task<ICollection<ExpenseGetAllDto>> GetAllForUser(Guid userId, string orderBy, int? categoryId, decimal? minAmount, DateTime? startDate, DateTime? endDate)
        {
            var expenses = await _expenseRepository.GetAllForUser(userId, orderBy, categoryId, minAmount, startDate, endDate);

            var expensesList = expenses.Select(x => new ExpenseGetAllDto
            {
                Id = x.Id,
                Concepto = x.Concepto,
                Monto = x.Monto.ToString("0.00"),
                CategoriaId = x.Categoria != null ? x.Categoria.Id : 0,
                CategoriaNombre = x.Categoria != null ? x.Categoria.Nombre : "Sin categoría",
                CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy")
            }).ToList();
            return expensesList;
        }

        public async Task<string> GetTotalsForUser(Guid userId, string attribute, int? categoryId, DateTime? month)
        {
            string total = await _expenseRepository.GetTotalsForUser(userId, attribute, categoryId, month);

            return total;
        }

        public async Task<string> GetTotalsByCategory(Guid userId, DateTime startDate, DateTime endDate)
        {
            // Llamada al repositorio para obtener el diccionario
            var totalAmountByCategory = await _expenseRepository.GetTotalsByCategory(userId, startDate, endDate);

            // Serializar el diccionario a formato JSON
            string jsonResult = JsonConvert.SerializeObject(totalAmountByCategory);

            return jsonResult;
        }
    }
}
