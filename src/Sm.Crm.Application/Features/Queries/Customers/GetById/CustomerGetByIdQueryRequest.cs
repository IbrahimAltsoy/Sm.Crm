using MediatR;

namespace Sm.Crm.Application.Features.Queries.Customers.GetById
{
    public class CustomerGetByIdQueryRequest:IRequest<CustomerGetByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
