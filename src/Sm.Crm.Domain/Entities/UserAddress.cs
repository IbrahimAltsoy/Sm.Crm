using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class UserAddress:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = null!;

    public short AddressType { get; set; }

    public virtual User User { get; set; } = null!;
}
