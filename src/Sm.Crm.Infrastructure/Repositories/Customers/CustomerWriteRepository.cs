using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerWriteRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
