using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sm.Crm.Application.Features.Commands.Sales.CreateSales;
using Sm.Crm.Application.Features.Commands.Sales.DeleteSale;
using Sm.Crm.Application.Features.Commands.Sales.UpdateSales;
using Sm.Crm.Application.Features.Queries.Sales.GetAll;
using Sm.Crm.Application.Features.Queries.Sales.GetById;
using Sm.Crm.Application.Features.Queries.Users.SalesPrice;

namespace Sm.Crm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdSalesQueryRequest request)
        {
            GetByIdSalesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSalesQueryRequest request)
        {
            GetAllSalesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateSalesCommandRequest request)
        {
            CreateSalesCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSalesCommandRequest request)
        {
            UpdateSalesCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteSaleCommandRequest request)
        {
            DeleteSaleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("sale-price")]
        public async Task<IActionResult> SalePriceAsync([FromQuery] SalesPriceQueryRequest request)
        {
            SalesPriceQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
