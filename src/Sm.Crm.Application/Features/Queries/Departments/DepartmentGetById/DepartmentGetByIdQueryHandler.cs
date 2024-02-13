using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Departments.DepartmentGetById
{
    public class DepartmentGetByIdQueryHandler : IRequestHandler<DepartmentGetByIdQueryRequest, DepartmentGetByIdQueryResponse>
    {
        readonly IQueryRepository<Department, int> _repository;

        public DepartmentGetByIdQueryHandler(IQueryRepository<Department, int> repository)
        {
            _repository = repository;
        }

        public async Task<DepartmentGetByIdQueryResponse> Handle(DepartmentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var department =await _repository.GetByIdAsync(request.Id);
            return new()
            {
                Name = department.Name
            };
        }
    }
}
