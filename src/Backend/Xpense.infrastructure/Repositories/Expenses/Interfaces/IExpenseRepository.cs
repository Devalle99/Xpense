﻿using Xpense.domain.Expenses;

namespace Xpense.infrastructure.Repositories.Expenses.Interfaces
{
    public interface IExpenseRepository
    {
        public Task<Expense> Create(Expense expense);
        public Task<Expense> Update(Expense expense);
        public Task<bool> Delete(int id, Guid userId);
        public Task<Expense> Get(int id, Guid userId);
        public Task<ICollection<Expense>> GetAll(Guid userId, string orderBy, int? categoryId, decimal? minAmount, DateTime? startDate, DateTime? endDate);
        public Task<string> GetTotals(Guid userId, string attribute, int? categoryId, DateTime? month);
        public Task<Dictionary<string, decimal>> GetTotalsByCategory(Guid userId, DateTime startDate, DateTime endDate);
    }
}
