using MediatR;

namespace Sm.Crm.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryRequest:IRequest<GetUserByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
