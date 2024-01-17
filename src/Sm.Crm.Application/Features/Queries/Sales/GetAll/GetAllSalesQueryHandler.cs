using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Sales.GetAll
{
    public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQueryRequest, GetAllSalesQueryResponse>
    {
        readonly IQueryRepository<Sale, int> _repository;

        public GetAllSalesQueryHandler(IQueryRepository<Sale, int> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllSalesQueryResponse> Handle(GetAllSalesQueryRequest request, CancellationToken cancellationToken)
        {
            var totalSales = _repository.GetAll().Count();
            var requests = _repository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.SaleAmount,
                    p.SaleDate,                    
                    p.RequestId,
                    p.EmployeeUserId,


                }).ToList();

            return new()
            {
                Sales = requests,
                TotalSalesCount = totalSales
            };
        }
    }
}
