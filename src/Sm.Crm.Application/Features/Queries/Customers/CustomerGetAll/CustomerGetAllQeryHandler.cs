using MediatR;
using Sm.Crm.Application.Services.Customers;

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
            List<CustomerGetAllQeryResponse> customers = _customerService.GetAllCustomers().Select(c =>new CustomerGetAllQeryResponse            
            {
                UserId = c.UserId,
                IdentityNumber = c.IdentityNumber,
                GenderId = c.GenderId,
                StatusTypeId = c.StatusTypeId,
                CustomerType = c.CustomerType,
                TitleId = c.TitleId,
                CompanyName = c.CompanyName,
                RegionId = c.RegionId,
                BirthDate = c.BirthDate

            }).ToList();

            return customers;
          //var result = _customerService.GetAllCustomers();
          //  return result.Select(c => new CustomerGetAllQeryResponse
          //  {
          //     UserId = c.UserId,
          //     IdentityNumber = c.IdentityNumber,
          //     GenderId = c.GenderId,
          //     StatusTypeId = c.StatusTypeId,
          //     CustomerType = c.CustomerType,
          //     TitleId = c.TitleId,
          //     CompanyName = c.CompanyName,
          //     RegionId = c.RegionId,
          //     BirthDate = c.BirthDate
          //  }).ToList();

        }
    }
}

//public int UserId { get; set; }

//public string IdentityNumber { get; set; } = null!;

//public int? GenderId { get; set; }

//public int? StatusTypeId { get; set; }

//public short? CustomerType { get; set; }

//public int? TitleId { get; set; }

//public string? CompanyName { get; set; }

//public int? RegionId { get; set; }

//public DateOnly? BirthDate { get; set; }
