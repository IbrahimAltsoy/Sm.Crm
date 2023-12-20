

using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Application.Services.Customers
{
    public interface ICustomerService
    {
        List<ReadCustomerDto> GetAllCustomers();
        Task<CreateCustomerResponseDto> CreateAsync(CreateCustomerDto createUser);
    }
}
