using MediatR;

namespace Sm.Crm.Application.Features.Queries.Sales.GetAll
{
    public class GetAllSalesQueryRequest:IRequest<GetAllSalesQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
