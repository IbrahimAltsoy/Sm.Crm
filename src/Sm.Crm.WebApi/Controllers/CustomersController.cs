using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Features.Commands.Customers.CreateCustomer;
using Sm.Crm.Application.Features.Commands.Customers.CustomerDelete;
using Sm.Crm.Application.Features.Commands.Customers.UpdateCustomer;
using Sm.Crm.Application.Features.Queries.Customers.CustomerGetAll;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Repositories.Customers;
using System.Net;

namespace Sm.Crm.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Admin")]
public class CustomersController : ControllerBase
{

    readonly IMediator _mediator;
    readonly ICustomerService _customerService;
    readonly ICustomerQueryRepository _customerQueryRepository;
    



    public CustomersController(IMediator mediator, ICustomerService customerService, ICustomerQueryRepository customerQueryRepository)
    {

        _mediator = mediator;
        _customerService = customerService;
        _customerQueryRepository = customerQueryRepository;

    }
    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    List<Customer> customers = await _customerQueryRepository.GetAll();
    //    int a = 5;
    //    return Ok(customers.Take(5).ToList());
    //}

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] CustomerGetAllQeryRequest request)
    {
        CustomerGetAllQeryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommandRequest create)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            CreateCustomerCommandResponse response = await _mediator.Send(create);
            return StatusCode((int)HttpStatusCode.Created);
        }

    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateCommandRequest request)
    {
        CustomerUpdateCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] CustomerDeleteCommandRequest request)
    {
        CustomerDeleteCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

}
