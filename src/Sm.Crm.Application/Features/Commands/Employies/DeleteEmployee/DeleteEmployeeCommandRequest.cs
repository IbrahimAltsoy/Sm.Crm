using MediatR;

namespace Sm.Crm.Application.Features.Commands.Employies.DeleteEmployee
{
    public class DeleteEmployeeCommandRequest:IRequest<DeleteEmployeeCommandResponse>
    {
        public int Id { get; set; }
       
    }
}
