using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Features.Commands.Users.LoginRefreshToken;
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
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] LoginRefreshTokenCommandRequest request)
        {
            LoginRefreshTokenCommandResponse response = await _mediator.Send(request); 
            return Ok(response);


        }
    }
}
