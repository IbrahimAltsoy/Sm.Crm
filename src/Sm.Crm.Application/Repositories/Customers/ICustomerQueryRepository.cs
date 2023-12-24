using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Repositories.Customers
{
    public interface ICustomerQueryRepository: IQueryRepository<Customer, long>
    {
    }
}
