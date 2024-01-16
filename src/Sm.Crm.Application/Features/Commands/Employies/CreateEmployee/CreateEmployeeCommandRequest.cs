using MediatR;

namespace Sm.Crm.Application.Features.Commands.Employies.CreateEmployee
{
    public class CreateEmployeeCommandRequest:IRequest<CreateEmployeeCommandResponse>
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public int? GenderId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? StartDate { get; set; } 
        public string PhotoPath { get; set; }
    }
}
