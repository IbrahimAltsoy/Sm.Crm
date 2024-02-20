using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Requests.RequestStatus
{
    public class RequestStatusQueryHandler : IRequestHandler<RequestStatusQueryRequest, RequestStatusQueryResponse>
    {
        readonly IQueryRepository<Request, int> _queryRepository;

        public RequestStatusQueryHandler(IQueryRepository<Request, int> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<RequestStatusQueryResponse> Handle(RequestStatusQueryRequest request, CancellationToken cancellationToken)
        {
            var statusTrue = _queryRepository.GetAll().Where(p => p.RequestStatusId == 1).Count();
            var statusFalse = _queryRepository.GetAll().Where(p => p.RequestStatusId == 0).Count();
            return new()
            {
                StatusTrue = statusTrue,
                StatusFalse = statusFalse
            };
        }
    }
}
