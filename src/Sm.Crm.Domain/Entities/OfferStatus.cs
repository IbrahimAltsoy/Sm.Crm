

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class OfferStatus:BaseEntity
{
    //public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
