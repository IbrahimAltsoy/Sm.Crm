using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Application.DTOs.Customers
{
    public class CreateCustomerDto
    {
        public int UserId { get; set; }

        public string IdentityNumber { get; set; } = null!;
     
    }
}
