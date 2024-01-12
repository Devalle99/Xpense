using Microsoft.EntityFrameworkCore;
using Xpense.domain.Categories;
using Xpense.infrastructure.Data;
using Xpense.infrastructure.Repositories.Categories.Interfaces;

namespace Xpense.infrastructure.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly XpenseContext _context;
        public CategoryRepository(XpenseContext context) { 
            _context = context;
        }
        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var categoryEntity = await _context.Categories.FirstAsync(c => c.Id == id);
            _context.Categories.Remove(categoryEntity);
            var isDeleted = await _context.SaveChangesAsync() > 0;
            return isDeleted;
        }

        public async Task<Category> Get(int id)
        {
            var categoryEntity = await _context.Categories.FirstAsync(c => c.Id == id);
            return categoryEntity;
        }

        public async Task<ICollection<Category>> GetAll()
        {
            var categoryEntities = await _context.Categories.ToListAsync();
            return categoryEntities;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
