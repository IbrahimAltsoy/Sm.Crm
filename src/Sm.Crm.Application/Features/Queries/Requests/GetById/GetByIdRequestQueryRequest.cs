using MediatR;

namespace Sm.Crm.Application.Features.Queries.Requests.GetById
{
    public class GetByIdRequestQueryRequest:IRequest<GetByIdRequestQueryResponse>
    {
        public int Id { get; set; }
    }
}
