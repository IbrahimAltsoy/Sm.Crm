using Sm.Crm.Application.DTOs.Users;

namespace Sm.Crm.Application.Services.Authencation
{
    public interface IExternalAuthencation
    {
        Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
