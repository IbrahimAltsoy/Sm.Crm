using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Features.Commands.Customers.CreateCustomer;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
   readonly ICustomerService _customerService;
    readonly IMediator _mediator;


    public CustomerController(ICustomerService customerService, IMediator mediator)
    {
        _customerService = customerService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {        
        var customers =  _customerService.GetAllCustomers();
        int a = 5;
        return Ok(customers);        

    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommandRequest create)
    {
        CreateCustomerCommandResponse response =await _mediator.Send(create);
        return Ok(response);
    }

}
