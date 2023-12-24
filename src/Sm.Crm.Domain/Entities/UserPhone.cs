using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class UserPhone : BaseEntity
{
    public int UserId { get; set; }

    public string PhoneNumber { get; set; }

    public short PhoneType { get; set; }

    // Navigation Properties
    //public virtual User User { get; set; }
}