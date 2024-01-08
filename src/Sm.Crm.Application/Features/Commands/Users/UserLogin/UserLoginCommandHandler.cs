using MediatR;
using Sm.Crm.Application.Features.Commands.Users.UserLogin;
using Sm.Crm.Application.Services.Authencation;

namespace Sm.Crm.Application.Features.Commands.Users.UserLogin
{
    public class UserLoginCommandHandler :IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public UserLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 15 * 60);
            return new UserLoginCommandResponse()
            {
                Token = token,
                Message = "Giriş Başarılı"
            };
        }
    }
}
