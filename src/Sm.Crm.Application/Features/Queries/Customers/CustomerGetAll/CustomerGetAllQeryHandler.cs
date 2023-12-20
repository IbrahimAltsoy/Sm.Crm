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
          
        }
    }
}


