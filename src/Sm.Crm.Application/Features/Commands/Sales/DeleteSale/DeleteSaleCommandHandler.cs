using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Sales.DeleteSale
{
    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommandRequest, DeleteSaleCommandResponse>
    {
        readonly ICommandRepository<Sale, int> _commandRepository;

        public DeleteSaleCommandHandler(ICommandRepository<Sale, int> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<DeleteSaleCommandResponse> Handle(DeleteSaleCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.DeleteById(request.Id);
            return new();
        }
    }
}
