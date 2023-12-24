using MediatR;

namespace Sm.Crm.Application.Features.Commands.Customers.UpdateCustomer
{
    public class CustomerUpdateCommandRequest:IRequest<CustomerUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string IdentityNumber { get; set; } = null!;
    }
}
