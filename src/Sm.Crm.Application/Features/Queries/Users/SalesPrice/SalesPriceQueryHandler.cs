using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Users.SalesPrice
{
    public class SalesPriceQueryHandler : IRequestHandler<SalesPriceQueryRequest, SalesPriceQueryResponse>
    {
        readonly IQueryRepository<Sale, int> _saleRepository;

        public SalesPriceQueryHandler(IQueryRepository<Sale, int> saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<SalesPriceQueryResponse> Handle(SalesPriceQueryRequest request, CancellationToken cancellationToken)
        {
            var lowercPrice = _saleRepository.GetAll().Where(p=>p.SaleAmount>=0 & p.SaleAmount<250).Count();
            var basicPrice = _saleRepository.GetAll().Where(p=>p.SaleAmount>=250 & p.SaleAmount<500).Count();
            var mediumPrice = _saleRepository.GetAll().Where(p=>p.SaleAmount>=500 & p.SaleAmount<750).Count();
            var upperPrice = _saleRepository.GetAll().Where(p=>p.SaleAmount>750).Count();
            return new()
            {
                LowercPrice = lowercPrice,
                BasicPrice = basicPrice,
                MediumPrice = mediumPrice,
                UpperPrice = upperPrice,
            };
        }
    }
}
