using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;
using System;

namespace Sm.Crm.Application.Features.Commands.Employies.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
    {
        readonly ICommandRepository<Employee, int> _commandRepository;

        public CreateEmployeeCommandHandler(ICommandRepository<Employee, int> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.Create(new()
            {
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone,
                Email = request.Email,
                IdentityNumber = request.IdentityNumber,
                //GenderId = request.GenderId,
                //DepartmentId = request.DepartmentId,
                //StartDate = DateTime.UtcNow,               
                PhotoPath = request.PhotoPath
            });
            return new();
        }
    }
}

