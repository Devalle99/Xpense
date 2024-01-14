using Xpense.application.Security.Dto;

namespace Xpense.application.Security.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDto> Add(RoleAddDto role);

        Task<RoleDto> Update(RoleDto role);

        Task<RoleDto> Get(Guid id);

        Task<bool> Delete(Guid id);

        Task<ICollection<RoleDto>> GetAll();

        Task<IList<string>> GetRolesByUser(UserDto user);
        Task<ICollection<RoleDto>> GetRolesByUserId(Guid userId);

        Task<bool> AsignRoleToUser(Guid userId, Guid roleId);
        Task<bool> RemoveRoleToUser(Guid userId, Guid roleId);
    }
}
