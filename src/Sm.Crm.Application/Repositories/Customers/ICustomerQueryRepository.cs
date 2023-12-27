using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Common.Interfaces;
using Sm.Crm.Domain.Common;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Repositories.Customers
{
    public interface ICustomerQueryRepository: IQueryRepository<Customer, long>
    {
        
        IQueryable<Customer> GetAllCustomer();
        
    }
}
