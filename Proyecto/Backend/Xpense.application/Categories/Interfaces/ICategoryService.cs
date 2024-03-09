using Xpense.application.Categories.Models;

namespace Xpense.application.Categories.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryReadDto> Create(CategoryCreateDto category);
        public Task<CategoryReadDto> Get(Guid userId, int id);
        public Task<ICollection<CategoryReadDto>> GetAll(Guid userId);
        public Task<CategoryReadDto> Update(CategoryReadDto category);
        public Task<bool> Delete(int id);
    }
}
