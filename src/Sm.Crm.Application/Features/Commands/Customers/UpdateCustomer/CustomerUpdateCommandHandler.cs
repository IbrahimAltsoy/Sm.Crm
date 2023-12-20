using MediatR;
using Sm.Crm.Application.Services.Customers;

namespace Sm.Crm.Application.Features.Commands.Customers.UpdateCustomer
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommandRequest, CustomerUpdateCommandResponse>
    {
        readonly ICustomerService _customerService;

        public CustomerUpdateCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerUpdateCommandResponse> Handle(CustomerUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            await _customerService.CustomerUpdateAsync(new()
            {
                Id = request.Id,
                UserId = request.UserId,
                IdentityNumber = request.IdentityNumber
            });
            return new();
            
        }
    }
}
//await _basketService.UpdateQuantityAsync(new()
//{
//    BasketItemId = request.BasketItemId,
//    Quantity = request.Quantity
//});

//return new();