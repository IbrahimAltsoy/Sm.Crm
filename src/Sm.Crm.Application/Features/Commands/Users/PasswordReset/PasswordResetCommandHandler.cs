using MediatR;
using Sm.Crm.Application.Services.Authencation;

namespace Sm.Crm.Application.Features.Commands.Users.PasswordReset
{
    public class PasswordResetCommandHandler :IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
    {
        readonly IAuthService _authService;

        public PasswordResetCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.ResetPasswordAsync(request.Email);
            return new();
        }
    }
}
