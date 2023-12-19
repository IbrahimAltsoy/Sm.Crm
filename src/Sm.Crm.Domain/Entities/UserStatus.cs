using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class UserStatus:BaseEntity
{
    //public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
