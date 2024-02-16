using MediatR;

namespace Sm.Crm.Application.Features.Commands.Departments.CreateDepartment
{
    public class DepartmentCreateCommandRequest:IRequest<DepartmentCreateCommandResponse>
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
    }
}
