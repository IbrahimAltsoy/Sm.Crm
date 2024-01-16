using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Employies.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler :IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        readonly ICommandRepository<Employee, int> _commandRepository;
       

        public DeleteEmployeeCommandHandler(ICommandRepository<Employee, int> commandRepository)
        {
            _commandRepository = commandRepository;
          
        }

        public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            
            await _commandRepository.DeleteById(request.Id);
            return new();
            

        }
    }
}
