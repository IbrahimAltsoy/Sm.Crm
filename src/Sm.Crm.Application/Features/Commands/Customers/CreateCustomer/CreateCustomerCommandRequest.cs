using MediatR;

namespace Sm.Crm.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommandRequest:IRequest<CreateCustomerCommandResponse>
    {
        public string CompanyName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        //public DateTimeOffset DeletedAt { get; set; }


    }
}
