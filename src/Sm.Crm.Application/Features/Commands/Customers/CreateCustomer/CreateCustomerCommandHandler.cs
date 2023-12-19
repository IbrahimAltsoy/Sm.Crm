using MediatR;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;

namespace Sm.Crm.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
       readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _customerService.CreateAsync(new()
            {
                IdentityNumber = request.IdentityNumber,
                UserId = request.UserId
            });
            return new();
            
            
        }
    }
}
