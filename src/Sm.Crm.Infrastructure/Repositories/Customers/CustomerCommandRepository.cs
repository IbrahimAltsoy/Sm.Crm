using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;

namespace Sm.Crm.Infrastructure.Repositories.Customers
{
    public class CustomerCommandRepository : CommandRepository<Customer, long>, ICustomerCommandRepository
    {        
        public CustomerCommandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
