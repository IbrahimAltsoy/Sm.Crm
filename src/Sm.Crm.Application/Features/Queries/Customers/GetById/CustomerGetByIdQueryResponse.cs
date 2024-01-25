using Sm.Crm.Domain.Enums;

namespace Sm.Crm.Application.Features.Queries.Customers.GetById
{
    public class CustomerGetByIdQueryResponse
    {
        public string Id { get; set; }
        public string? IdentityNumber { get; set; }
        
        public string? CompanyName { get; set; }
        
    }
}
