using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Features.Commands.Users.CreateUser;
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
        public async Task<IActionResult> Get()
        {
          
            return Ok(await _userService.GetUserAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
           await _userService.GetUserByIdAsync(id);
            return Ok(await _userService.GetUserByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            //user: username:string password: Response35.
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userCreate)
        {
            await _userService.UpdateUserAsync(userCreate);
            return Ok("Güncelleme başarılı bir şekilde yapılmıştır.");
        }
             
    }
}
