using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class Offer : BaseEntity
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }

    // Navigation Properties
    public Request RequestFk { get; set; }

    public Employee EmployeeFk { get; set; }
}