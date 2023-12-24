using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerQueryRepository : QueryRepository<Customer, long>,ICustomerQueryRepository
    {
        
        public CustomerQueryRepository(ApplicationDbContext context) : base(context)
        {
        }
                   

    }
}
