

using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Infrastructure.Persistence.Services.Customers
{
    public class CustomerService:ICustomerService
    {
        readonly ICustomerQueryRepository _customerReadRepository;
        readonly ICustomerCommandRepository _customerWriteRepository;

        public CustomerService(ICustomerQueryRepository customerReadRepository, ICustomerCommandRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

       

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = _customerReadRepository.GetAll(true).ToList();
            return customers;
        }
    }
}
