using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Repositories.Users;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Repositories;
using Sm.Crm.Infrastructure.Repositories.Customers;

namespace Sm.Crm.Infrastructure.Repositories.Users
{
    public class UserQueryRepository : QueryRepository<User, int>, IUserQueryRepository
    {
        readonly DbSet<User> _table;
        public UserQueryRepository(ApplicationDbContext context) : base(context)
        {
            _table =context.Set<User>();
        }
        public IQueryable<User> GetAllUser()
        {
            return _table.AsQueryable();
        }
    }
}

