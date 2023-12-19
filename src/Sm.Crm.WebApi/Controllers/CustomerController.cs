using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
   readonly ICustomerService _customerService;
   

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
       
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //var response = _customerService.GetAllCustomers();

        //int a = 5;
        //return Ok(response);
        var customers =  _customerService.GetAllCustomers();
        int a = 5;
        return Ok(customers);
        

    }
}
