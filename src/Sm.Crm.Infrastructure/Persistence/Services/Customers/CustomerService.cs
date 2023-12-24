using AutoMapper;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Repositories.Customers;


namespace Sm.Crm.Infrastructure.Persistence.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerQueryRepository _customerQueryRepository;
        readonly ICustomerCommandRepository _customerCommandRepository;
        readonly IMapper _mapper;


        public CustomerService(ICustomerQueryRepository customerQueryRepository, ICustomerCommandRepository customerCommandRepository, IMapper mapper)
        {
            _customerQueryRepository = customerQueryRepository;
            _customerCommandRepository = customerCommandRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResponseDto> CreateAsync(CreateCustomerDto createUser)
        {

            await _customerCommandRepository.Create(new Customer()
            {
                CompanyName = createUser.CompanyName,
                IdentityNumber = createUser.IdentityNumber,
                CreatedAt = DateTime.UtcNow,
                DeletedAt = DateTime.UtcNow,

            });
            
            return new()
            {

                Message = "Kayıt başarılı bir şekilde gerçekleşti"
            };
        }


        public async Task<List<ReadCustomerDto>> GetAllCustomers()
        {
            List<Customer> customers = await _customerQueryRepository.GetAll();
            List<ReadCustomerDto> result = new List<ReadCustomerDto>();
            foreach (var customer in customers)
            {
                result.Add(_mapper.Map<ReadCustomerDto>(customer));
            }
            return result;

            ////var customers = _mapper.Map<List<ReadCustomerDto>>(_customerReadRepository.GetAll(true));
            //var customers = _mapper.Map<List<ReadCustomerDto>>(_customerQueryRepository.GetAll());

            //int a = 5;
            //return customers;
        }

        public async Task CustomerUpdateAsync(CustomerUpdateDto customerUpdate)
        {
            Customer? customer = await _customerQueryRepository.GetById(customerUpdate.Id);
            if (customer != null)
            {
                customer.CompanyName = customerUpdate.CompanyName;
                customer.IdentityNumber = customerUpdate.IdentityNumber;
                await _customerCommandRepository.Update(customer);

            }


        }

        public async Task CustomerDelete(int id)
        {
            Customer? customer = await _customerQueryRepository.GetById(id);
            if (customer != null)
            {
                await _customerCommandRepository.Delete(customer);
                // await _customerWriteRepository.SaveChanges();
            }
        }
    }
}
