

using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Infrastructure.Persistence.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerQueryRepository _customerReadRepository;
        readonly ICustomerCommandRepository _customerWriteRepository;

        public CustomerService(ICustomerQueryRepository customerReadRepository, ICustomerCommandRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<CreateCustomerResponseDto> CreateAsync(CreateCustomerDto createUser)
        {

            await _customerWriteRepository.AddAsync(new Customer()
            {
                UserId = createUser.UserId,
                IdentityNumber = createUser.IdentityNumber
            });
            await _customerWriteRepository.SaveChanges();
            return new()
            {
                
                Message = "Kayıt başarılı bir şekilde gerçekleşti"
            };
        }

        public  List<Customer> GetAllCustomers()
        {
           
            List<Customer> customers = _customerReadRepository.Table.ToList();
            //List<ReadCustomerDto> query = customers.ToList();
            //List<ReadCustomerDto> readCustomerDto = _customerReadRepository.GetAll(true).ToList();
            return customers;
        }
    }
}
