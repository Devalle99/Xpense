using Xpense.domain.Expenses;

namespace Xpense.infrastructure.Repositories.Expenses.Interfaces
{
    public interface IExpenseRepository
    {
        public Task<Expense> Create(Expense expense);
        public Task<Expense> Update(Expense expense);
        public Task<bool> Delete(int id);
        public Task<Expense> Get(int id, Guid userId);
        public Task<ICollection<Expense>> GetAll();
        public Task<ICollection<Expense>> GetAllForUser(string sort, string filter, Guid userId);
        public Task<ICollection<Expense>> GetTotalsForUser(string attribute, Guid userId);

    }
}
