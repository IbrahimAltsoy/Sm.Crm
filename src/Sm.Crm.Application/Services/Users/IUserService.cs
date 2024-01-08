using Microsoft.AspNetCore.Identity;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Features.Commands.Users.CreateUser;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Services.Users
{
    public interface IUserService
    {
        Task<List<UserReadDto>> GetUserAllAsync();
        Task<CreateUserCommandResponse> CreateUserAsync(UserCreateDto userCreate);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userCreate);
        Task<UserReadDto> GetUserByIdAsync(int userId);
        Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenTime);
        //Task<string> GetUserRoleAsync(UserReadDto user);

    }
}
