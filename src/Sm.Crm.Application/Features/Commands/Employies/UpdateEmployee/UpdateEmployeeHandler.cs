using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Employies.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeResponse>
    {
        readonly ICommandRepository<Employee, int> _commandRepository;
        readonly IQueryRepository<Employee, int> _queryRepository;

        public UpdateEmployeeHandler(ICommandRepository<Employee, int> commandRepository, IQueryRepository<Employee, int> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _queryRepository.GetByIdAsync(request.Id, false);
            employee.Phone = request.Phone;
            employee.Email = request.Email;
            employee.DepartmentId = request.DepartmentId;
            employee.PhotoPath = request.PhotoPath;
            await _commandRepository.Update(employee);
            //await _commandRepository.Update(new()
            //{
            //    Email = employee.Email,
            //    Phone = employee.Phone,
            //    DepartmentId = employee.DepartmentId,
            //    PhotoPath = employee.PhotoPath
            //    //Phone = request.Phone,
            //    //Email = request.Email,
            //    //DepartmentId = request.DepartmentId,
            //    //PhotoPath = request.PhotoPath

            //});
            return new();
        }
    }
}
