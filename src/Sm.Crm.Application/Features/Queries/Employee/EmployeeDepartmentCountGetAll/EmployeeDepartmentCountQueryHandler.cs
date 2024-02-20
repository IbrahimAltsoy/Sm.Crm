using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;
using E = Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Employee.EmployeeDepartmentCountGetAll
{
    public class EmployeeDepartmentCountQueryHandler :IRequestHandler<EmployeeDepartmentCountQueryRequest, EmployeeDepartmentCountQueryResponse>
    {
        readonly IQueryRepository<E.Employee, int> _queryRepository;
        readonly IQueryRepository<E.Department, int> _queryDepartmenRepository;

        public EmployeeDepartmentCountQueryHandler(IQueryRepository<E.Employee, int> queryRepository, IQueryRepository<Department, int> queryDepartmenRepository)
        {
            _queryRepository = queryRepository;
            _queryDepartmenRepository = queryDepartmenRepository;
        }

        public async Task<EmployeeDepartmentCountQueryResponse> Handle(EmployeeDepartmentCountQueryRequest request, CancellationToken cancellationToken)
        {            
            var administration = _queryRepository.GetAll().Where(p=>p.DepartmentId==1).Count();
            var sale = _queryRepository.GetAll().Where(p=>p.DepartmentId==2).Count();
            var marketing = _queryRepository.GetAll().Where(p=>p.DepartmentId==3).Count();
            var accounting = _queryRepository.GetAll().Where(p=>p.DepartmentId==4).Count();
            var technical = _queryRepository.GetAll().Where(p=>p.DepartmentId==5).Count();
            var humanResourcesUnit = _queryRepository.GetAll().Where(p=>p.DepartmentId==6).Count();
            return new()
            {
                Administration = administration,
                Sale = sale,
                Marketing = marketing,
                Accounting = accounting,
                Technical = technical,
                HumanResourcesUnit = humanResourcesUnit
            };
        }
    }
}
//public int Sale { get; set; }
//public int Marketing { get; set; }
//public int Accounting { get; set; }
//public int Technical { get; set; }
//public int HumanResourcesUnit { get; set; }