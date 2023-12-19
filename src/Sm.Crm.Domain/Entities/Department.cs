using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Department:BaseEntity
{
    //public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
