using MediatR;

namespace Sm.Crm.Application.Features.Queries.Requests.GetAllRequest
{
    public class GetAllRequestQueryRequest:IRequest<GetAllRequestQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
