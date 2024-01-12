﻿using MailKit.Net.Smtp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Sm.Crm.Application.Features.Commands.Users.LoginRefreshToken;
using Sm.Crm.Application.Features.Commands.Users.PasswordReset;
using Sm.Crm.Application.Features.Commands.Users.UserLogin;

namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginCommandRequest request)
        {
            UserLoginCommandResponse response = await _mediator.Send(request);
            int a = 5;
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] LoginRefreshTokenCommandRequest request)
        {
            LoginRefreshTokenCommandResponse response = await _mediator.Send(request); 
            return Ok(response);


        }
        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest request)
        {
            PasswordResetCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
    }
}
