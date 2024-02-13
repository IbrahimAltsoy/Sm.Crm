using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Departments.CreateDepartment
{
    public class DepartmentCreateCommandHandler : IRequestHandler<DepartmentCreateCommandRequest, DepartmentCreateCommandResponse>
    {
        readonly ICommandRepository<Department, int> _commandRepository;
        public DepartmentCreateCommandHandler(ICommandRepository<Department, int> commandRepository)
        {
            _commandRepository = commandRepository;   
        }

        public async Task<DepartmentCreateCommandResponse> Handle(DepartmentCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.Create(new()            
            {
                Name = request.Name
            });
            return new();
        }
    }
}
