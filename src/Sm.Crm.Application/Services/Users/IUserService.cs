using Microsoft.AspNetCore.Identity;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Features.Commands.Users.CreateUser;

namespace Sm.Crm.Application.Services.Users
{
    public interface IUserService
    {
        //Task<List<UserReadDto>> GetUserAllAsync();
        Task<CreateUserCommandResponse> CreateUserAsync(UserCreateDto userCreate);
        //Task<IdentityResult> UpdateUserAsync(UserUpdateDto userCreate);
        //Task<UserReadDto> GetAppUserByIdAsync(int userId);
        //Task<string> GetUserRoleAsync(UserReadDto user);

    }
}
