using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Common;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerQueryRepository : QueryRepository<Customer, long>,ICustomerQueryRepository
    {
        private readonly DbSet<Customer> _table;
        public CustomerQueryRepository(ApplicationDbContext context) : base(context)
        {
            _table = context.Set<Customer>();
        }

        public IQueryable<Customer> GetAllCustomer()
        {
            var query = _table.AsQueryable();
            return query;
        }
    }
}
