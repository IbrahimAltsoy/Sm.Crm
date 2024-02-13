using MediatR;
using Sm.Crm.Application.Repositories;
using E=Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Requests.GetAllRequest
{
    public class GetAllRequestQueryHandler : IRequestHandler<GetAllRequestQueryRequest, GetAllRequestQueryResponse>
    {
        readonly IQueryRepository<E.Request, int> _queryRepository;
        readonly IQueryRepository<E.Employee, int> _employeeRepository;
        readonly IQueryRepository<E.Customer, long> _customerQueryRepository;
        

        public GetAllRequestQueryHandler(IQueryRepository<E.Request, int> queryRepository, IQueryRepository<E.Employee, int> employeeRepository, IQueryRepository<E.Customer, long> customerQueryRepository)
        {
            _queryRepository = queryRepository;
            _employeeRepository = employeeRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<GetAllRequestQueryResponse> Handle(GetAllRequestQueryRequest request, CancellationToken cancellationToken)
        {
            var totalRequestsCount = _queryRepository.GetAll().Count();
            var requests = (from queryRequest in _queryRepository.GetAll(false)
                            join employee in _employeeRepository.GetAll() on queryRequest.EmployeeUserId equals employee.Id
                            join customer in _customerQueryRepository.GetAll() on queryRequest.CustomerUserId equals customer.Id
                            select new
                            {
                                queryRequest.Id,
                                queryRequest.RequestStatusId,
                                EmployeeName = employee.Name,
                                CustomerName = customer.CompanyName,
                                queryRequest.Description,
                                queryRequest.CustomerUserId,
                                queryRequest.EmployeeUserId
                                
                            })
                 .Skip(request.Page * request.Size)
                 .Take(request.Size)
                 .ToList();


            return new()
            {
                TotalRequestCount = totalRequestsCount,
                Requests = requests
            };
        }
    }
}


//var totalREquestsCount =  _queryRepository.GetAll().Count();
//var requests = _queryRepository.GetAll(false)                
//    .Skip(request.Page * request.Size).Take(request.Size)
//    .Select(p => new
//    {
//        p.Id,
//        p.RequestStatusId,
//        p.EmployeeUserId,
//        p.CustomerUserId,
//        p.Description


//    }).ToList();