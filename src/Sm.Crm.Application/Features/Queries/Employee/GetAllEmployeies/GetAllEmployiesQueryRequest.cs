using MediatR;

namespace Sm.Crm.Application.Features.Queries.Employee.GetAllEmployeies
{
    public class GetAllEmployiesQueryRequest:IRequest<GetAllEmployiesQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
