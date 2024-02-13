using MediatR;

namespace Sm.Crm.Application.Features.Commands.Departments.UpdateDepartment
{
    public class DepartmentUpdateCommandRequest:IRequest<DepartmentUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
