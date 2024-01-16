using MediatR;

namespace Sm.Crm.Application.Features.Commands.Employies.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest : IRequest<UpdateEmployeeResponse>
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
