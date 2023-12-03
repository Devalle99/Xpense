using Xpense.application.Categories.Interfaces;
using Xpense.application.Categories.Models;
using Xpense.infrastructure.Repositories.Categories.Interfaces;

namespace Xpense.application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryReadDto> Create(CategoryCreateDto category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryReadDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryReadDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryReadDto> Update(CategoryReadDto category)
        {
            throw new NotImplementedException();
        }
    }
}
