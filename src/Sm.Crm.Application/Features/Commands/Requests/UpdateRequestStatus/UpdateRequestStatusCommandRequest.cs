using MediatR;

namespace Sm.Crm.Application.Features.Commands.Requests.UpdateRequestStatus
{
    public class UpdateRequestStatusCommandRequest:IRequest<UpdateRequestCommandStatusResponse>
    {
        public int Id { get; set; }      
    }
}