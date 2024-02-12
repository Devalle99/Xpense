using Xpense.application.Expenses.Models;

namespace Xpense.application.Expenses.Interfaces
{
    public interface IExpenseService
    {
        public Task<ExpenseReadDto> Create(ExpenseCreateDto expense);
        public Task<ExpenseReadDto> Update(ExpenseReadDto expense);
        public Task<bool> Delete(int id);
        public Task<ExpenseReadDto> Get(int id, Guid userId);
        public Task<ICollection<ExpenseReadDto>> GetAll();
        public Task<ICollection<ExpenseGetAllDto>> GetAllForUser(Guid userId, string orderBy, int? categoryId, decimal? minAmount, DateTime? startDate, DateTime? endDate);
        public Task<string> GetTotalsForUser(Guid userId, string attribute, int? categoryId, DateTime? month);
        public Task<string> GetTotalsByCategory(Guid userId, DateTime startDate, DateTime endDate);
    }
}
