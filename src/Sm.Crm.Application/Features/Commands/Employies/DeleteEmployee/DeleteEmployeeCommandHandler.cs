using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Employies.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler :IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        readonly ICommandRepository<Employee, int> _commandRepository;
        readonly IQueryRepository<Employee, int> _queryRepository;

        public DeleteEmployeeCommandHandler(ICommandRepository<Employee, int> commandRepository, IQueryRepository<Employee, int> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            //Employee response =await _queryRepository.GetByIdAsync(request.Id);
            await _commandRepository.DeleteById(request.Id);
            return new();
            

        }
    }
}
