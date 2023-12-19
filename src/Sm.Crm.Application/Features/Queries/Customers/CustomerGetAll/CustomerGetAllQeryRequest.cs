using MediatR;

namespace Sm.Crm.Application.Features.Queries.Customers.CustomerGetAll
{
    public class CustomerGetAllQeryRequest: IRequest<List<CustomerGetAllQeryResponse>>
    {
    }
}
