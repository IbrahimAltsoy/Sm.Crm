using MediatR;

namespace Sm.Crm.Application.Features.Commands.Requests.DeleteRequest
{
    public class DeleteRequestCommandRequest:IRequest<DeleteRequestCommandResponse>
    {
        public int Id { get; set; }
    }
}
