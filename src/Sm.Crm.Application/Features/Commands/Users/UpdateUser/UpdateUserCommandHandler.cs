using MediatR;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Repositories.Users;

namespace Sm.Crm.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler :IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        readonly IUserQueryRepository _userQueryRepository;
        readonly IUserCommandRepository _userCommandRepository;

        public UpdateUserCommandHandler(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository)
        {
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetById(request.Id);
            if (user!=null)
            {
                user.Name = request.Name;
                user.Surname = request.Surname;
                user.UserName = request.UserName;
                user.PhoneNumber = request.PhoneNumber;
                user.Email = request.Email;
                await _userCommandRepository.Update(user);
            }
            return new();          

           
        }
    }
}
