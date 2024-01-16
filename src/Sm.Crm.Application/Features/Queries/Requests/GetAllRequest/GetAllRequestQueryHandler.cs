using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Requests.GetAllRequest
{
    public class GetAllRequestQueryHandler : IRequestHandler<GetAllRequestQueryRequest, GetAllRequestQueryResponse>
    {
        readonly IQueryRepository<Request, int> _queryRepository;

        public GetAllRequestQueryHandler(IQueryRepository<Request, int> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<GetAllRequestQueryResponse> Handle(GetAllRequestQueryRequest request, CancellationToken cancellationToken)
        {
            var totalREquestsCount =  _queryRepository.GetAll().Count();
            var requests = _queryRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.RequestStatusId,
                    p.EmployeeUserId,
                    p.CustomerUserId,
                    p.Description
                    

                }).ToList();
            return new()
            {
                TotalRequestCount = totalREquestsCount,
                Requests = requests
            };
        }
    }
}
