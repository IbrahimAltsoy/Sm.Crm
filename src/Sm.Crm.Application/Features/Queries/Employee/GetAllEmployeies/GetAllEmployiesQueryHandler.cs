using MediatR;
using Sm.Crm.Application.Repositories;
using E =Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Employee.GetAllEmployeies
{
    internal class GetAllEmployiesQueryHandler : IRequestHandler<GetAllEmployiesQueryRequest, GetAllEmployiesQueryResponse>
    {            

        public async Task<GetAllEmployiesQueryResponse> Handle(GetAllEmployiesQueryRequest request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
