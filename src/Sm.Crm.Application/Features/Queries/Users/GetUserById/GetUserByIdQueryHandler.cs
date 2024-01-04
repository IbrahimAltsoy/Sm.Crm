using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Services.Users;

namespace Sm.Crm.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler :IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            UserReadDto user = await _userService.GetUserByIdAsync(request.Id);
            return new()
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}
