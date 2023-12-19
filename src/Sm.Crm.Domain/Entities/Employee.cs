using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Employee:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public string? IdentityNumber { get; set; }

    public int? GenderId { get; set; }

    public int? DepartmentId { get; set; }

    //public DateOnly? StartDate { get; set; }

    public int? StatusTypeId { get; set; }

    public int? RegionId { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? ParentEmployeeId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Region? Region { get; set; }

    public virtual StatusType? StatusType { get; set; }

    public virtual User User { get; set; } = null!;
}
