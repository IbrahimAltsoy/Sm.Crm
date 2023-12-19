
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerReadRepository : QueryRepository<Customer>, ICustomerQueryRepository
    {
        public CustomerReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
