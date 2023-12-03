using Xpense.domain.Expenses;
using Xpense.infrastructure.Repositories.Expenses.Interfaces;

namespace Xpense.infrastructure.Repositories.Expenses
{
    public class ExpenseRepository : IExpenseRepository
    {
        public async Task<Expense> Create(Expense expense)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Expense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> Update(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
