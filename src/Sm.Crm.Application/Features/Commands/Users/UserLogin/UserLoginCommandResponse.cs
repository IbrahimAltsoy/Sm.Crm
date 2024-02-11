using Sm.Crm.Application.DTOs.Users;

namespace Sm.Crm.Application.Features.Commands.Users.UserLogin
{
    public class UserLoginCommandResponse
    {
        public Token AccessToken { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
  
}
