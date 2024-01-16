using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Common;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerQueryRepository : QueryRepository<Customer, long>, ICustomerQueryRepository
    {
        readonly DbSet<Customer> _table;

        public CustomerQueryRepository(ApplicationDbContext context) : base(context)
        {
            _table = context.Set<Customer>();
        }

      
        public IQueryable<Customer> GetAllCustomer()
        {
           return _table.AsQueryable();
        }
    }
}
