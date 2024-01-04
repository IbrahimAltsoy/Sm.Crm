using Sm.Crm.Domain.Entities;
using U=Sm.Crm.Domain.Entities;
namespace Sm.Crm.Application.Repositories.Users
{
    public interface IUserQueryRepository:IQueryRepository<U.User, int>
    {
        IQueryable<User> GetAllUser();
    }
}
