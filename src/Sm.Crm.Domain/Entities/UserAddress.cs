using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class UserAddress : BaseEntity
{
    public int UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public short AddressType { get; set; }

    //public virtual User User { get; set; } = null!;
}