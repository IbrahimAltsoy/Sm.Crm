using MailKit.Net.Smtp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Sm.Crm.Application.Features.Commands.Users.GoogleLogin;
using Sm.Crm.Application.Features.Commands.Users.LoginRefreshToken;
using Sm.Crm.Application.Features.Commands.Users.PasswordReset;
using Sm.Crm.Application.Features.Commands.Users.UpdatePassword;
using Sm.Crm.Application.Features.Commands.Users.UserLogin;
using Sm.Crm.Application.Features.Commands.Users.VerifyResetToken;
using Sm.Crm.Application.Hubs;

namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILoginHubService _loginHubService;

        public AuthController(IMediator mediator, ILoginHubService loginHubService)
        {
            _mediator = mediator;
            _loginHubService = loginHubService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginCommandRequest request)
        {
            UserLoginCommandResponse response = await _mediator.Send(request);
            if (response != null)
            {
                await _loginHubService.UserLoginSendMessageAsync(request.UsernameOrEmail, "Giriş işlemleri", response.Message);
                int a = 5;
            }
            return Ok(response);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
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
        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody]VerifyResetTokenCommandRequest request)
        {
            VerifyResetTokenCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("password-update")]
        public async Task<IActionResult> PasswordUpdate([FromBody] UpdatePasswordCommandRequest request)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
    }
}
