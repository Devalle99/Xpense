using Xpense.domain.Categories;
using Xpense.infrastructure.Repositories.Categories.Interfaces;

namespace Xpense.infrastructure.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<Category> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
