using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;
using R=Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Requests.UpdateRequest
{
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommandRequest, UpdateRequestCommandResponse>
    {
        readonly ICommandRepository<R.Request, int> _commandRepository;
        readonly IQueryRepository<R.Request, int> _queryRepository;

        public UpdateRequestCommandHandler(ICommandRepository<Request, int> commandRepository, IQueryRepository<Request, int> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<UpdateRequestCommandResponse> Handle(UpdateRequestCommandRequest request, CancellationToken cancellationToken)
        {
            R.Request result = await _queryRepository.GetByIdAsync(request.Id, false);
            if (result != null)
            {
                result.Description = request.Description;
                result.EmployeeUserId = request.EmployeeUserId;
                result.CustomerUserId = request.CustomerUserId;
                result.RequestStatusId = request.RequestStatusId;
                await _commandRepository.Update(result);
                return new()
                {
                    Message = "Güncelleme işlemi başarıyla gerçekleşti"
                };
            }
            else { return new() { Message = "Güncelleme yapılırken bir sorun oluştu" }; }
            
        }
    }
}
