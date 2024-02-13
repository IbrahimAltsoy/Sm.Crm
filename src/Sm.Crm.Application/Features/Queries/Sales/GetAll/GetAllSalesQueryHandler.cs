using MediatR;
using Sm.Crm.Application.Repositories;
using E=Sm.Crm.Domain.Entities;


namespace Sm.Crm.Application.Features.Queries.Sales.GetAll
{
    public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQueryRequest, GetAllSalesQueryResponse>
    {
        readonly IQueryRepository<E.Sale, int> _repository;
        readonly IQueryRepository<E.Employee, int> _employeeRepository;
        readonly IQueryRepository<E.Request, int> _requestRepository;

        public GetAllSalesQueryHandler(IQueryRepository<E.Sale, int> repository, IQueryRepository<E.Employee, int> employeeRepository, IQueryRepository<E.Request, int> requestRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _requestRepository = requestRepository;
        }


        public async Task<GetAllSalesQueryResponse> Handle(GetAllSalesQueryRequest request, CancellationToken cancellationToken)
        {


            var totalSales = _repository.GetAll().Count();

            var requests = _repository.GetAll(false)
                .Where(sale => sale.RequestId != null)
                .Where(sale => sale.EmployeeUserId != null)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Join(_employeeRepository.GetAll(),
                      sale => sale.EmployeeUserId,
                      employee => employee.Id,
                      (sale, employee) => new
                      {
                          sale.Id,
                          sale.Name,
                          sale.Description,
                          sale.SaleAmount,
                          sale.SaleDate,
                          sale.RequestId,
                          EmployeeName = employee.Name + " " + employee.Surname
                      })
                .Join(_requestRepository.GetAll(),
                      sale => sale.RequestId,
                      request => request.Id,
                      (sale, request) => new
                      {
                          sale,
                          Request = request
                      })
                .ToList();

            return new GetAllSalesQueryResponse
            {
                Sales = requests.Select(sale => new
                {
                    sale.sale.Id,
                    sale.sale.Name,
                    sale.sale.Description,
                    sale.sale.SaleAmount,
                    sale.sale.SaleDate,
                    sale.sale.RequestId,
                    sale.sale.EmployeeName,
                    RequestDescription = sale.Request.Description
                }),
                TotalSalesCount = totalSales
            };
        }





        //public async Task<GetAllSalesQueryResponse> Handle(GetAllSalesQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var totalSales = _repository.GetAll().Count();
        //    var requests = _repository.GetAll(false)
        //        .Skip(request.Page * request.Size)
        //        .Take(request.Size)
        //        .Join(_employeeRepository.GetAll(),
        //              sale => sale.EmployeeUserId,
        //              employee => employee.Id,
        //              (sale, employee) => new
        //              {
        //                  sale.Id,
        //                  sale.Name,
        //                  sale.Description,
        //                  sale.SaleAmount,
        //                  sale.SaleDate,
        //                  sale.RequestId,
        //                  EmployeeName = employee.Name + " " + employee.Surname
        //              }).ToList();

        //    return new GetAllSalesQueryResponse
        //    {
        //        Sales = requests,
        //        TotalSalesCount = totalSales
        //    };
        //}
    }
}
