using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Departments.DepartmentGetAll
{
    public class DepartmentGetAllQueryHandler : IRequestHandler<DepartmentGetAllQueryRequest, DepartmentGetAllQueryResponse>
    {
        readonly IQueryRepository<Department, int> _queryRepository;
        public DepartmentGetAllQueryHandler(IQueryRepository<Department, int> queryRepository)
        {
            _queryRepository = queryRepository;
        }
        public async Task<DepartmentGetAllQueryResponse> Handle(DepartmentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var totalDepartmentsCount = _queryRepository.GetAll(false).Count();
            var departments = _queryRepository.GetAll(false)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(dep=>new
                {
                    dep.Id,
                    dep.Name
                }).ToList();
            return new()
            {
                Departments = departments,
                TotalDepartmentsCount = totalDepartmentsCount

            };

        }
    }
}
