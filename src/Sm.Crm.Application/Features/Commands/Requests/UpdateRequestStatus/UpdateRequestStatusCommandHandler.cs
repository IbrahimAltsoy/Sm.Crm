using MediatR;
using Sm.Crm.Application.Repositories.Requests;

namespace Sm.Crm.Application.Features.Commands.Requests.UpdateRequestStatus
{
    public class UpdateRequestStatusCommandHandler :IRequestHandler<UpdateRequestStatusCommandRequest, UpdateRequestCommandStatusResponse>
    {
        readonly IRequestCommandReposityory _requestCommandReposityory;

        public UpdateRequestStatusCommandHandler(IRequestCommandReposityory requestCommandReposityory)
        {
            _requestCommandReposityory = requestCommandReposityory;
        }

        public async Task<UpdateRequestCommandStatusResponse> Handle(UpdateRequestStatusCommandRequest request, CancellationToken cancellationToken)
        {
           await _requestCommandReposityory.RequestStatusChangeAsync(request.Id);
            return new()
            {
                Message = "İstek statusu başarıyla gerçekleşti"
            };

        }
    }
}
