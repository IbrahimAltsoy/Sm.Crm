using MediatR;
using Sm.Crm.Application.Repositories;
using R=Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Requests.DeleteRequest
{
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommandRequest, DeleteRequestCommandResponse>
    {
        readonly ICommandRepository<R.Request, int> _commandRepository;

        public DeleteRequestCommandHandler(ICommandRepository<R.Request, int> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<DeleteRequestCommandResponse> Handle(DeleteRequestCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.DeleteById(request.Id);
            return new();
        }
    }
}
