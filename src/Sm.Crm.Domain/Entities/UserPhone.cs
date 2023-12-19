using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class UserPhone:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public short PhoneType { get; set; }

    public virtual User User { get; set; } = null!;
}
