using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Features.Commands.Departments.CreateDepartment;
using Sm.Crm.Application.Features.Commands.Departments.DeleteDepartment;
using Sm.Crm.Application.Features.Commands.Departments.UpdateDepartment;
using Sm.Crm.Application.Features.Queries.Departments.DepartmentGetAll;
using Sm.Crm.Application.Features.Queries.Departments.DepartmentGetById;


namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly IMediator _mediator;


        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] DepartmentGetByIdQueryRequest  request)
        {
            DepartmentGetByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DepartmentGetAllQueryRequest request)
        {
            DepartmentGetAllQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentCreateCommandRequest request)
        {
            DepartmentCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(DepartmentUpdateCommandRequest request)
        {
            DepartmentUpdateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DepartmentDeleteCommandRequest request)
        {
            DepartmentDeleteCommandResponse response = await _mediator.Send(request);
            return Ok(request);
        }
    }
}
