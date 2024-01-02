using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Repositories.Users
{
    public interface IUserCommandRepository: ICommandRepository<User,int>
    {
    }
}
