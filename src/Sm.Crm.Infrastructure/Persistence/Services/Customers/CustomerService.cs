

using AutoMapper;
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
        readonly IMapper _mapper;


        public CustomerService(ICustomerQueryRepository customerReadRepository, ICustomerCommandRepository customerWriteRepository, IMapper mapper)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _mapper = mapper;
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
              

        public  List<ReadCustomerDto> GetAllCustomers()
        {
            var customers = _mapper.Map<List<ReadCustomerDto>>( _customerReadRepository.GetAll(true));
          
            
            return customers;
        }

        public async System.Threading.Tasks.Task CustomerUpdateAsync(CustomerUpdateDto customerUpdate)
        {
            Customer? customer = await _customerReadRepository.GetByIdAsync(customerUpdate.Id,true);
            if (customer!=null)
            {
                customer.UserId = customerUpdate.UserId;
                customer.IdentityNumber = customerUpdate.IdentityNumber;
                await _customerWriteRepository.SaveChanges();

            }
            
            
        }

        public async System.Threading.Tasks.Task CustomerDelete(int id)
        {
            Customer? customer = await _customerReadRepository.GetByIdAsync(id,true);
            if (customer!=null)
            {
                  _customerWriteRepository.Delete(customer);
                await _customerWriteRepository.SaveChanges();
            }
        }
    }
}
