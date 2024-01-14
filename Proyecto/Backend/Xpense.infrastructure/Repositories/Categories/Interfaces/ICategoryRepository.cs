using Xpense.domain.Categories;

namespace Xpense.infrastructure.Repositories.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category category);
        public Task<Category> Get(int id);
        public Task<ICollection<Category>> GetAll();
        public Task<Category> Update(Category category);
        public Task<bool> Delete(int id);
    }
}
