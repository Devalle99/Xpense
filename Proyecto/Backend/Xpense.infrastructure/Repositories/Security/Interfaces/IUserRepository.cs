using Microsoft.AspNetCore.Identity;

namespace Xpense.infrastructure.Repositories.Security.Interfaces
{
    public interface IUserRepository
    {
        public Task<IdentityUser<Guid>> Get(Guid Id);
        public Task<ICollection<IdentityUser<Guid>>> GetAll();
        public Task<IdentityUser<Guid>> Add(IdentityUser<Guid> user, string password);
        public Task<IdentityUser<Guid>> Update(IdentityUser<Guid> user);
        public Task<bool> Delete(Guid id);
        public Task<IdentityUser<Guid>> Login(string username, string password);
    }
}
