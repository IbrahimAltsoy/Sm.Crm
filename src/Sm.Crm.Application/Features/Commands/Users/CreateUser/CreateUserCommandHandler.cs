using MediatR;
using Sm.Crm.Application.Services.Users;

namespace Sm.Crm.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserCommandResponse response = await _userService.CreateUserAsync(new(){
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
            
           
        }
    }
}
