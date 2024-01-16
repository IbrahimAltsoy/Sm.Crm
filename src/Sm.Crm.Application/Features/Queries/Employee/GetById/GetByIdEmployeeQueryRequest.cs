using MediatR;

namespace Sm.Crm.Application.Features.Queries.Employee.GetById
{
    public class GetByIdEmployeeQueryRequest:IRequest<GetByIdEmployeeQueryResponse>
    {
        public int Id { get; set; }
    }
}
