using Xpense.infrastructure.Data;
using Xpense.infrastructure.Repositories.Security.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Xpense.infrastructure.Repositories.Security
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public UserRepository(XpenseContext context, UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser<Guid>> Add(IdentityUser<Guid> user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                var errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.Code + " " + error.Description;
                }
                throw new Exception(errors);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<IdentityUser<Guid>> Get(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            return user;
        }

        public async Task<ICollection<IdentityUser<Guid>>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<IdentityUser<Guid>> Login(string username, string password)
        {
            var identityUsr = await _userManager.FindByNameAsync(username);

            var is_valid_user = false;
            if (await _userManager.CheckPasswordAsync(identityUsr, password))
            {
                is_valid_user = true;
            }

            return (is_valid_user == true) ? identityUsr : null;
        }

        public async Task<IdentityUser<Guid>> Update(IdentityUser<Guid> user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return null;
            return user;
        }
    }
}
