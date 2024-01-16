using MediatR;

namespace Sm.Crm.Application.Features.Commands.Requests.UpdateRequest
{
    public class UpdateRequestCommandRequest:IRequest<UpdateRequestCommandResponse>
    {
        public int Id { get; set; }
        public int CustomerUserId { get; set; }
        public int EmployeeUserId { get; set; }
        public int RequestStatusId { get; set; }
        public string? Description { get; set; }
    }
}
