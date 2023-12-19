using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class UserRole:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
