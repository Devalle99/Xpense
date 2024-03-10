using Xpense.application.Security.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.application.Security.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> Add(UserAddDto user);

        Task<UserDto> Update(UserDto user);

        Task<UserDto> Get(Guid id);

        Task<bool> Delete(Guid id);

        Task<ICollection<UserDto>>GetAll();

        Task<UserDto> Login(LoginDto login);
    }
}
