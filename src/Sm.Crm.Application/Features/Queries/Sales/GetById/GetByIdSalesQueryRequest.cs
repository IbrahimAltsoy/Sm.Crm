using MediatR;

namespace Sm.Crm.Application.Features.Queries.Sales.GetById
{
    public class GetByIdSalesQueryRequest:IRequest<GetByIdSalesQueryResponse>
    {
        public int Id { get; set; }
    }
}
