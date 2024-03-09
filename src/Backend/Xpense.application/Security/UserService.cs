using Xpense.application.Security.Dto;
using Xpense.application.Security.Interfaces;
using Xpense.infrastructure.Repositories.Security.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Xpense.application.Security
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Add(UserAddDto user)
        {
            IdentityUser<Guid> userEntity = new IdentityUser<Guid>
            {
                Email = user.Email,
                UserName = user.Email
            };

            var result = await _userRepository.Add(userEntity, user.Password);

            return new UserDto
            {
                Id = result.Id,
                Email = result.Email,
                Name = result.UserName
            };

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var user = await _userRepository.Get(id);
            return new UserDto { Id = user.Id, Email = user.Email, Name = user.UserName };
        }

        public async Task<ICollection<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(x => new UserDto
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.UserName
            }).ToList();
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            var userEntity = await _userRepository.Login(login.Username, login.Password);
            UserDto user = null;
            if (userEntity is not null)
                user = new UserDto
                {
                    Id = userEntity.Id,
                    Email = userEntity.Email,
                    Name = userEntity.UserName
                };

            return user;
        }

        public async Task<UserDto> Update(UserDto user)
        {
            var userEntity = await _userRepository.Get(user.Id);
            userEntity.UserName = user.Email;
            userEntity.Email = user.Email;

            var result = _userRepository.Update(userEntity);
            if (result != null)
                return user;
            return null;
        }
    }
}
