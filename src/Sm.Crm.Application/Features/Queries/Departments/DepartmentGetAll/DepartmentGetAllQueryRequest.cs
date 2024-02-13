using MediatR;

namespace Sm.Crm.Application.Features.Queries.Departments.DepartmentGetAll
{
    public class DepartmentGetAllQueryRequest:IRequest<DepartmentGetAllQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
