

using Sm.Crm.Application.Repositories.Users;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Users
{
    public class UserCommandRepository : CommandRepository<User, int>, IUserCommandRepository
    {
        public UserCommandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
