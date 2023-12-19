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

        public Task<List<CustomerGetAllQeryResponse>> Handle(CustomerGetAllQeryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
