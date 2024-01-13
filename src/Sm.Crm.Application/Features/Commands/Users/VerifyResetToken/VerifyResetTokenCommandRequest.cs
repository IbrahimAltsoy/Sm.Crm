using MediatR;

namespace Sm.Crm.Application.Features.Commands.Users.VerifyResetToken
{
    public class VerifyResetTokenCommandRequest:IRequest<VerifyResetTokenCommandResponse>
    {
        public string UserId { get; set; }
        public string ResetToken { get; set; }
    }
}
