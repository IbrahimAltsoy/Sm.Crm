using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Departments.DeleteDepartment
{
    public class DepartmentDeleteCommandHandler : IRequestHandler<DepartmentDeleteCommandRequest, DepartmentDeleteCommandResponse>
    {
        readonly ICommandRepository<Department, int> _commandRepository;
        public DepartmentDeleteCommandHandler(ICommandRepository<Department, int> commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public async Task<DepartmentDeleteCommandResponse> Handle(DepartmentDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.DeleteById(request.Id);
            return new();
        }
    }
}
