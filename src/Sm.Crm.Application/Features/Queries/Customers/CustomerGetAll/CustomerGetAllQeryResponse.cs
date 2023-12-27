
using Sm.Crm.Domain.Enums;

namespace Sm.Crm.Application.Features.Queries.Customers.CustomerGetAll
{
    public class CustomerGetAllQeryResponse
    {
        public int TotalCustomerCount { get; set; }
        public object Customers { get; set; }
        //public string? IdentityNumber { get; set; }
        //public CustomerTypeEnum? CustomerType { get; set; }
        //public string? CompanyName { get; set; }
        //public DateOnly? BirthDate { get; set; }

        //public int? UserId { get; set; }
        //public GenderEnum? Gender { get; set; }
        //public int? StatusTypeId { get; set; }
        //public int? TitleId { get; set; }
        //public int? TerritoryId { get; set; }


    }
}
