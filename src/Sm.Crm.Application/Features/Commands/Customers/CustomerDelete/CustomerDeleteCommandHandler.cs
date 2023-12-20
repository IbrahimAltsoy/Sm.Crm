using MediatR;
using Sm.Crm.Application.Services.Customers;

namespace Sm.Crm.Application.Features.Commands.Customers.CustomerDelete
{
    public class CustomerDeleteCommandHandler :IRequestHandler<CustomerDeleteCommandRequest, CustomerDeleteCommandResponse>
    {
        readonly ICustomerService _customerService;

        public CustomerDeleteCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDeleteCommandResponse> Handle(CustomerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await _customerService.CustomerDelete(request.Id);
            return new();


        }
    }
}
