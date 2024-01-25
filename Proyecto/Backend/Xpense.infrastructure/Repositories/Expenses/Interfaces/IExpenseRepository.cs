using Xpense.domain.Expenses;

namespace Xpense.infrastructure.Repositories.Expenses.Interfaces
{
    public interface IExpenseRepository
    {
        public Task<Expense> Create(Expense expense);
        public Task<Expense> Get(int id, Guid UsuarioId);
        public Task<ICollection<Expense>> GetAll();
        public Task<Expense> Update(Expense expense);
        public Task<bool> Delete(int id);
    }
}
