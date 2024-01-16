using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployiesController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }
    }
}
