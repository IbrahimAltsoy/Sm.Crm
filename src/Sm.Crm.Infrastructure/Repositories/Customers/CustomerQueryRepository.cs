
using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Repositories.Customers;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerQueryRepository : QueryRepository<Customer>,ICustomerQueryRepository
    {
        
        public CustomerQueryRepository(ApplicationDbContext context) : base(context)
        {
        }
                   

    }
}
