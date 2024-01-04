using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Repositories.Users;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Repositories;

namespace Sm.Crm.Infrastructure.Repositories.Users
{
    public class UserQueryRepository : QueryRepository<User, int>, IUserQueryRepository
    {
        public UserQueryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
