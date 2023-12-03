using Xpense.application.Expenses.Interfaces;
using Xpense.application.Expenses.Models;
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
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseReadDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ExpenseReadDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseReadDto> Update(ExpenseReadDto expense)
        {
            throw new NotImplementedException();
        }
    }
}
