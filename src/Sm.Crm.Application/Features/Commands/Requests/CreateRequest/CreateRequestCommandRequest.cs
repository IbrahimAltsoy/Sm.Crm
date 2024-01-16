using MediatR;

namespace Sm.Crm.Application.Features.Commands.Requests.CreateRequest
{
    public class CreateRequestCommandRequest:IRequest<CreateRequestCommandResponse>
    {
        public int CustomerUserId { get; set; }
        public int EmployeeUserId { get; set; }
        public int RequestStatusId { get; set; }
        public string? Description { get; set; }
    }
}
