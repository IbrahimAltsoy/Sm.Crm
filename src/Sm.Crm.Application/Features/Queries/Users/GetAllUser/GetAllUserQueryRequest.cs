using MediatR;

namespace Sm.Crm.Application.Features.Queries.Users.GetAllUser
{
    public class GetAllUserQueryRequest:IRequest<GetAllUserQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
