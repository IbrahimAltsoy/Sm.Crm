using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Features.Commands.Users.CreateUser;
using Sm.Crm.Application.Features.Commands.Users.UpdatePassword;
using Sm.Crm.Application.Features.Commands.Users.UpdateUser;
using Sm.Crm.Application.Features.Queries.Users.GetAllUser;
using Sm.Crm.Application.Features.Queries.Users.GetUserById;
using Sm.Crm.Application.Services.Users;

namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IUserService _userService;

        public UserController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
    
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllUserQueryRequest request)
        {
            GetAllUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetUserByIdQueryRequest request)
        {
            GetUserByIdQueryResponse response= await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            //user: username:string password: Response35.
            return Ok(response);
        }
       
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse response = await _mediator.Send(request);
            
            return Ok("Güncelleme başarılı bir şekilde yapılmıştır.");
        }
        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest request)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(request);
            int a = 5;
            return Ok(response);

        }

    }
}
