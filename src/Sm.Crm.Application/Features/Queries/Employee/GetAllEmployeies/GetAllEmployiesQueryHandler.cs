using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using E =Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Employee.GetAllEmployeies
{
    internal class GetAllEmployiesQueryHandler : IRequestHandler<GetAllEmployiesQueryRequest, GetAllEmployiesQueryResponse>
    {
        readonly IQueryRepository<E.Employee, int> _queryRepository;
        readonly IQueryRepository<E.Department, int> _queryDepartmenRepository;

        public GetAllEmployiesQueryHandler(IQueryRepository<E.Employee, int> queryRepository, IQueryRepository<E.Department, int> queryDepartmenRepository)
        {
            _queryRepository = queryRepository;
            _queryDepartmenRepository = queryDepartmenRepository;
        }

        //public async Task<GetAllEmployiesQueryResponse> Handle(GetAllEmployiesQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var totalEmployiesCount = _queryRepository.GetAll(false).Count();

        //    var employies = _queryRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
        //        .Select(p => new
        //        {
        //            p.Id,
        //            p.Name,
        //            p.Surname,
        //            p.Phone,
        //            p.Email,
        //            p.PhotoPath,
        //            p.IdentityNumber,
        //            p.DepartmentId

        //        }).ToList();
        //    return new()
        //    {
        //        Employies = employies,
        //        TotalEmployiesCount = totalEmployiesCount
        //    };

        //}
        public async Task<GetAllEmployiesQueryResponse> Handle(GetAllEmployiesQueryRequest request, CancellationToken cancellationToken)
        {
            var totalEmployiesCount = _queryRepository.GetAll(false).Count();

            var employiesWithDepartments = _queryRepository.GetAll(false)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Join(_queryDepartmenRepository.GetAll(), 
                    emp => emp.DepartmentId,
                    dep => dep.Id,
                    (emp, dep) => new
                    {
                        Employee = emp,
                        DepartmentName = dep.Name
                    })
                .Select(joined => new
                {
                    joined.Employee.Id,
                    joined.Employee.Name,
                    joined.Employee.Surname,
                    joined.Employee.Phone,
                    joined.Employee.Email,
                    joined.Employee.PhotoPath,
                    joined.Employee.IdentityNumber,
                    joined.Employee.DepartmentId,
                    joined.DepartmentName
                })
                .ToList();

            return new GetAllEmployiesQueryResponse
            {
                Employies = employiesWithDepartments,
                TotalEmployiesCount = totalEmployiesCount
            };
        }


    }
}
