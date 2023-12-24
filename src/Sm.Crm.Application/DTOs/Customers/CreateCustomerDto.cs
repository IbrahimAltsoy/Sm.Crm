

namespace Sm.Crm.Application.DTOs.Customers
{
    public class CreateCustomerDto
    {
        public string CompanyName { get; set; }

        public string IdentityNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DeletedAt { get; set; }

    }
}
