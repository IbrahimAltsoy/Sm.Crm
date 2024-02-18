using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Features.Commands.Requests.CreateRequest;
using Sm.Crm.Application.Features.Commands.Requests.DeleteRequest;
using Sm.Crm.Application.Features.Commands.Requests.UpdateRequest;
using Sm.Crm.Application.Features.Commands.Requests.UpdateRequestStatus;
using Sm.Crm.Application.Features.Queries.Employee.GetById;
using Sm.Crm.Application.Features.Queries.Requests.GetAllRequest;
using Sm.Crm.Application.Features.Queries.Requests.GetById;

namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdRequestQueryRequest request)
        {
            GetByIdRequestQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRequestQueryRequest request)
        {
            GetAllRequestQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateRequestCommandRequest request)
        {
            CreateRequestCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRequestCommandRequest request)
        {
            UpdateRequestCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteRequestCommandRequest request)
        {
            DeleteRequestCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("request-status")]
        public async Task<IActionResult> RequestStatusChangeAsync(UpdateRequestStatusCommandRequest request)
        {
            UpdateRequestCommandStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
