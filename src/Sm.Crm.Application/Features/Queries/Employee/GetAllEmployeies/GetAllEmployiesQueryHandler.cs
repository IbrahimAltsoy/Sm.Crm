using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using E =Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Employee.GetAllEmployeies
{
    internal class GetAllEmployiesQueryHandler : IRequestHandler<GetAllEmployiesQueryRequest, GetAllEmployiesQueryResponse>
    {
        readonly IQueryRepository<E.Employee, int> _queryRepository;

        public GetAllEmployiesQueryHandler(IQueryRepository<E.Employee, int> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<GetAllEmployiesQueryResponse> Handle(GetAllEmployiesQueryRequest request, CancellationToken cancellationToken)
        {
            var totalEmployiesCount = _queryRepository.GetAll(false).Count();

            var employies = _queryRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Surname,
                    p.Phone,
                    p.Email,
                    p.PhotoPath

                }).ToList();
            return new()
            {
                Employies = employies,
                TotalEmployiesCount = totalEmployiesCount
            };
            
        }
    }
}
