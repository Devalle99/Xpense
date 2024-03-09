using Xpense.infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Xpense.infrastructure.Repositories.Security.Interfaces;

namespace Xpense.infrastructure.Repositories.Security
{
    public class RoleRepository : IRoleRepository
    {
        private readonly XpenseContext _context;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        public RoleRepository(XpenseContext context, RoleManager<IdentityRole<Guid>> roleManager, UserManager<IdentityUser<Guid>> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IdentityRole<Guid>> Add(IdentityRole<Guid> role)
        {
            var aux = await _roleManager.CreateAsync(role);
            return role;
        }

        public async Task<bool> Delete(Guid id)
        {
            var role = _roleManager.Roles.First(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<IdentityRole<Guid>> Get(Guid Id)
        {
            return await _roleManager.Roles.FirstAsync(x => x.Id == Id);
        }

        public async Task<ICollection<IdentityRole<Guid>>> GetAll()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole<Guid>> Update(IdentityRole<Guid> role)
        {
            await _roleManager.UpdateAsync(role);
            return role;
        }

        public async Task<IList<string>> GetRolesByUser(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            var roles = await _userManager.GetRolesAsync(user);
            List<string> normalizedRoles = new List<string>();
            foreach (var item in roles)
            {
                var role = _context.Roles.FirstOrDefault(x => x.Name.Equals(item));
                normalizedRoles.Add(role.NormalizedName);
            }

            return normalizedRoles;
        }

        public async Task<ICollection<IdentityRole<Guid>>> GetRolesByUserId(Guid userId)
        {
            var userRoles = _context.UserRoles.Where(x => x.UserId == userId).ToList();
            List<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();
            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByIdAsync(userRole.RoleId.ToString());
                roles.Add(role);
            }

            return roles;
        }

        public async Task<bool> AsignRoleToUser(Guid userId, Guid roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var result = await _userManager.AddToRoleAsync(user, role.NormalizedName);

            return result.Succeeded;
        }

        public async Task<bool> RemoveRoleToUser(Guid userId, Guid roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = await _roleManager.FindByIdAsync(roleId.ToString());

            var result = await _userManager.RemoveFromRoleAsync(user, role.NormalizedName);
            return result.Succeeded;
        }
    }
}