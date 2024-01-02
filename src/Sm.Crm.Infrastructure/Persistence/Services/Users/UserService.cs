using Microsoft.AspNetCore.Identity;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Services.Users;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Application.Features.Commands.Users.CreateUser;

namespace Sm.Crm.Infrastructure.Persistence.Services.Users
{
    public class UserService : IUserService
    {


        readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> CreateUserAsync(UserCreateDto userCreate)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                //Id = new(),
                Name= userCreate.Name,
                Surname = userCreate.Surname,
                UserName = userCreate.UserName,
                PhoneNumber = userCreate.PhoneNumber,
                Email = userCreate.Email

            }, userCreate.Password);
            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
                response.Message = "Yeni kullanıcı kaydı başarılı bir şekilde gerçekleşti.";
            else
            {
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Description} - {error.Code}<br>";
                }
            }
            return response;
                    

        }

        //public Task<UserReadDto> GetAppUserByIdAsync(int userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<UserReadDto>> GetUserAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<string> GetUserRoleAsync(UserReadDto user)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IdentityResult> UpdateUserAsync(UserUpdateDto userCreate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
