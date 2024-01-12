using Xpense.application.Expenses.Models;

namespace Xpense.application.Expenses.Interfaces
{
    public interface IExpenseService
    {
        public Task<ExpenseReadDto> Create(ExpenseCreateDto expense);
        public Task<ExpenseReadDto> Get(int id);
        public Task<ICollection<ExpenseReadDto>> GetAll();
        public Task<ExpenseReadDto> Update(ExpenseReadDto expense);
        public Task<bool> Delete(int id);
    }
}
