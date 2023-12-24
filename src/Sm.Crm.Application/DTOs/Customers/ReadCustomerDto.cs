using Sm.Crm.Domain.Entities.LST;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Enums;

namespace Sm.Crm.Application.DTOs.Customers
{
    public class ReadCustomerDto
    {
        public string? IdentityNumber { get; set; }
        public CustomerTypeEnum? CustomerType { get; set; }
        public string? CompanyName { get; set; }
        public DateOnly? BirthDate { get; set; }

        public int? UserId { get; set; }
        public GenderEnum? Gender { get; set; }
        public int? StatusTypeId { get; set; }
        public int? TitleId { get; set; }
        public int? TerritoryId { get; set; }

        
    }
}
