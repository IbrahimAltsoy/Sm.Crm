using MediatR;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Services.Authencation;

namespace Sm.Crm.Application.Features.Commands.Users.LoginRefreshToken
{
    public class LoginRefreshTokenCommandHandler :IRequestHandler<LoginRefreshTokenCommandRequest,LoginRefreshTokenCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginRefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginRefreshTokenCommandResponse> Handle(LoginRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            return new LoginRefreshTokenCommandResponse()
            {
                Token = token
            };
        }
    }
}
