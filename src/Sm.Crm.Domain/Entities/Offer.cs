

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Offer:BaseEntity
{
    //public int Id { get; set; }

    public int RequestId { get; set; }

    public int EmployeeUserId { get; set; }

    public DateTime OfferDate { get; set; }

    public decimal BidAmount { get; set; }

    public int OfferStatusId { get; set; }

    public virtual User EmployeeUser { get; set; } = null!;

    public virtual OfferStatus OfferStatus { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
