using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class UserEmail:BaseEntity
{
    //public int Id { get; set; }

    public int? UserId { get; set; }

    public string? EmailAddress { get; set; }

    public short? EmailType { get; set; }

    public virtual User? User { get; set; }
}
