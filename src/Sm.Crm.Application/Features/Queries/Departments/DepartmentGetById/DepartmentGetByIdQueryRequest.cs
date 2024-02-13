using MediatR;

namespace Sm.Crm.Application.Features.Queries.Departments.DepartmentGetById
{
    public class DepartmentGetByIdQueryRequest:IRequest<DepartmentGetByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
