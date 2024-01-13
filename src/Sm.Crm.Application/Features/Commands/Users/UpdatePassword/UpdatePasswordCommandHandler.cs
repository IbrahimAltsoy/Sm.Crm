using MediatR;
using Sm.Crm.Application.Exceptionss;
using Sm.Crm.Application.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sm.Crm.Application.Features.Commands.Users.UpdatePassword
{
    
    public class UpdatePasswordCommandHandler :IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeFailledException("Lütgen aynı şifreyi giriniz");



            await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
            return new();
            
        }
    }
}
