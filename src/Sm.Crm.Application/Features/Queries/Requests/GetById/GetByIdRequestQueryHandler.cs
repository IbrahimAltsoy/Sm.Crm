using MediatR;
using Sm.Crm.Application.Repositories;
using R=Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Requests.GetById
{
    public class GetByIdRequestQueryHandler : IRequestHandler<GetByIdRequestQueryRequest, GetByIdRequestQueryResponse>
    {
        readonly IQueryRepository<R.Request,int> _repository;

        public GetByIdRequestQueryHandler(IQueryRepository<R.Request, int> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdRequestQueryResponse> Handle(GetByIdRequestQueryRequest request, CancellationToken cancellationToken)
        {
           var result = await _repository.GetByIdAsync(request.Id,false);
            if (result == null) return null;
            else
            {
                return new()
                {
                    Description =result.Description,
                    CustomerUserId = result.CustomerUserId,
                    RequestStatusId = result.RequestStatusId,
                    EmployeeUserId = result.EmployeeUserId


                };
            }
            
        }
    }
}
