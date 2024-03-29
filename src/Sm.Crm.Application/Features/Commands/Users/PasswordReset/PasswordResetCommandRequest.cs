﻿using MediatR;

namespace Sm.Crm.Application.Features.Commands.Users.PasswordReset
{
    public class PasswordResetCommandRequest:IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}
