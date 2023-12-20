

using Sm.Crm.Application.DTOs.Customers;


namespace Sm.Crm.Application.Services.Customers
{
    public interface ICustomerService
    {
        List<ReadCustomerDto> GetAllCustomers();
        Task<CreateCustomerResponseDto> CreateAsync(CreateCustomerDto createUser);
        Task CustomerUpdateAsync(CustomerUpdateDto customerUpdate);
        Task CustomerDelete(int id);
    }
}
