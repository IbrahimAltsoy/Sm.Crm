using MediatR;
using Sm.Crm.Application.Repositories;
using R = Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Requests.CreateRequest
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommandRequest, CreateRequestCommandResponse>
    {
        readonly ICommandRepository<R.Request, int> _commandRepository;

        public CreateRequestCommandHandler(ICommandRepository<R.Request, int> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<CreateRequestCommandResponse> Handle(CreateRequestCommandRequest request, CancellationToken cancellationToken)
        {
                await _commandRepository.Create(new()
                {
                    Description = request.Description,
                    CustomerUserId = request.CustomerUserId,
                    EmployeeUserId = request.EmployeeUserId,
                    RequestStatusId = request.RequestStatusId
                });
                return new()
                {
                    Message = "Kayıt başarılı bir şekilde eklendi"
                };
            
            
        }
    }
}
