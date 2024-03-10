using Xpense.domain.Categories;

namespace Xpense.infrastructure.Repositories.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category category);
        public Task<Category> Update(Category category);
        public Task<bool> Delete(int id);
        public Task<Category> Get(Guid userId, int id);
        public Task<ICollection<Category>> GetAll(Guid userId);
    }
}
