using MediatR;

namespace Sm.Crm.Application.Features.Commands.Users.LoginRefreshToken
{
    public class LoginRefreshTokenCommandRequest:IRequest<LoginRefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
