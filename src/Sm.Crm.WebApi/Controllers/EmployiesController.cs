using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Features.Commands.Employies.CreateEmployee;
using Sm.Crm.Application.Features.Commands.Employies.DeleteEmployee;
using Sm.Crm.Application.Features.Commands.Employies.UpdateEmployee;
using Sm.Crm.Application.Features.Queries.Employee.GetAllEmployeies;
using Sm.Crm.Application.Features.Queries.Employee.GetById;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdEmployeeQueryRequest request)
        {
            GetByIdEmployeeQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployiesQueryRequest request)
        {
            GetAllEmployiesQueryResponse response =await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeeCommandRequest request)
        {
            CreateEmployeeCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeCommandRequest request) 
        {
            UpdateEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEmployeeCommandRequest request)
        {
            DeleteEmployeeCommandResponse response = await _mediator.Send(request);
            return Ok(request);
        }
    }
}
