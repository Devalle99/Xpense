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
        public Task<ICollection<ExpenseReadDto>> GetAllForUser(string sort, string filter, Guid userId);
        public Task<ICollection<ExpenseReadDto>> GetTotalsForUser(string attribute, Guid userId);
    }
}
