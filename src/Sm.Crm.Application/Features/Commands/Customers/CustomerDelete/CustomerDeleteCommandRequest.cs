using MediatR;

namespace Sm.Crm.Application.Features.Commands.Customers.CustomerDelete
{
    public class CustomerDeleteCommandRequest:IRequest<CustomerDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
