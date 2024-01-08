using MediatR;

namespace Sm.Crm.Application.Features.Commands.Users.UserLogin
{
    public class UserLoginCommandRequest:IRequest<UserLoginCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
