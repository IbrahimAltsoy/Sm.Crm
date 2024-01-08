using Sm.Crm.Application.DTOs.Users;

namespace Sm.Crm.Application.Features.Commands.Users.UserLogin
{
    public class UserLoginCommandResponse
    {
        public Token Token { get; set; }
        public string Message { get; set; }
    }
    //public class LoginUserSuccessCommandResponse :UserLoginCommandResponse
    //{
    //   public Token Token { get; set; }
    //}
    //public class LoginUserUnSuccessCommandResponse :UserLoginCommandResponse
    //{
    //    public string Message { get; set; }
    //}
}
