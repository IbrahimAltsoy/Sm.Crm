

using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Application.Services.Customers
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Task<CreateCustomerResponseDto> CreateAsync(CreateCustomerDto createUser);
    }
}
