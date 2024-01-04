using MediatR;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Repositories.Users;
using Sm.Crm.Application.Services.Users;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Users.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        readonly IUserService _userService;
        readonly IUserQueryRepository _userQueryRepository;

        public GetAllUserQueryHandler(IUserService userService, IUserQueryRepository userQueryRepository)
        {
            _userService = userService;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _userQueryRepository.GetAllUser().Count();
            var users = _userQueryRepository.GetAllUser().Skip(request.Page * request.Size).Take(request.Size).Select(u => new
            {
                u.Name,
                u.Surname,
                u.UserName,
                u.PhoneNumber,
                u.Email
            }).ToList();
            return new()
            {
                Users = users,
                TotalUserCount = totalCount

            };
            
        }
    }
}
