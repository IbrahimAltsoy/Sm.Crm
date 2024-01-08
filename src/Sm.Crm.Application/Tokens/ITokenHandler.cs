using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int second,User  user);
        string CreateRefreshToken();
    }
}
