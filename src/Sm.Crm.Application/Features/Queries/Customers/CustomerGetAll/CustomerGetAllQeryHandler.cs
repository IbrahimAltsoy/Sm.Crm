using MediatR;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Domain.Enums;

namespace Sm.Crm.Application.Features.Queries.Customers.CustomerGetAll
{
    public class CustomerGetAllQeryHandler : IRequestHandler<CustomerGetAllQeryRequest, List<CustomerGetAllQeryResponse>>
    {
        readonly ICustomerService _customerService;

        public CustomerGetAllQeryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<List<CustomerGetAllQeryResponse>> Handle(CustomerGetAllQeryRequest request, CancellationToken cancellationToken)
        {
            List<ReadCustomerDto> customers = await _customerService.GetAllCustomers();
            List<CustomerGetAllQeryResponse> customerResponses = customers
        .Select(c => new CustomerGetAllQeryResponse
        {
            IdentityNumber = c.IdentityNumber,
            CompanyName = c.CompanyName,
            BirthDate = c.BirthDate,
            UserId = c.UserId
        })
        .ToList();

            return customerResponses;

        }
    }
}


//public string? IdentityNumber { get; set; }
//public CustomerTypeEnum? CustomerType { get; set; }
//public string? CompanyName { get; set; }
//public DateOnly? BirthDate { get; set; }

//public int? UserId { get; set; }
//public GenderEnum? Gender { get; set; }
//public int? StatusTypeId { get; set; }
//public int? TitleId { get; set; }
//public int? TerritoryId { get; set; }