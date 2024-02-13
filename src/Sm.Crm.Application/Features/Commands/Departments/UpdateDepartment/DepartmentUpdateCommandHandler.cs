using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Departments.UpdateDepartment
{
    public class DepartmentUpdateCommandHandler :IRequestHandler<DepartmentUpdateCommandRequest, DepartmentUpdateCommandResponse>
    {
        readonly ICommandRepository<Department, int> _commandRepository;
        readonly IQueryRepository<Department, int> _queryRepository;

        public DepartmentUpdateCommandHandler(ICommandRepository<Department, int> commandRepository, IQueryRepository<Department, int> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<DepartmentUpdateCommandResponse> Handle(DepartmentUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _queryRepository.GetByIdAsync(request.Id);
            department.Name = request.Name;
            await _commandRepository.Update(department);
            return new();
        }
    }
}
