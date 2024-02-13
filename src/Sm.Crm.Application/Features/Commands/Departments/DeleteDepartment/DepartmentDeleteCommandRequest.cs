using MediatR;

namespace Sm.Crm.Application.Features.Commands.Departments.DeleteDepartment
{
    public class DepartmentDeleteCommandRequest: IRequest<DepartmentDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
