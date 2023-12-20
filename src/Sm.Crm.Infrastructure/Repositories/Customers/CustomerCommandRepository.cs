using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
