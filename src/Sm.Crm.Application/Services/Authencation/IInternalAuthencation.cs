using Sm.Crm.Application.DTOs.Users;

namespace Sm.Crm.Application.Services.Authencation
{
    public interface IInternalAuthencation
    {
        Task<Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
