using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sm.Crm.Application.Features.Queries.Sales.GetById
{
    public class GetByIdSalesQueryHandler : IRequestHandler<GetByIdSalesQueryRequest, GetByIdSalesQueryResponse>
    {
        readonly IQueryRepository<Sale, int> _queryRepository;

        public GetByIdSalesQueryHandler(IQueryRepository<Sale, int> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<GetByIdSalesQueryResponse> Handle(GetByIdSalesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _queryRepository.GetByIdAsync(request.Id);
            if (result == null) return null;
            else
            {
                return new()
                {
                    Name = result.Name,
                    Description = result.Description,
                    SaleAmount = result.SaleAmount,
                    SaleDate = result.SaleDate,
                    RequestId = result.RequestId,
                    EmployeeUserId = result.EmployeeUserId

                };
            }
            
        }
    }
}


