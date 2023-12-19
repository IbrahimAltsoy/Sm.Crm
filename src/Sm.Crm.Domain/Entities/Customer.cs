using Sm.Crm.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;


namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Customer : BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public string IdentityNumber { get; set; } = null!;

    public int? GenderId { get; set; }

    public int? StatusTypeId { get; set; }

    public short? CustomerType { get; set; }

    public int? TitleId { get; set; }

    public string? CompanyName { get; set; }

    public int? RegionId { get; set; }

    public DateOnly? BirthDate { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Region? Region { get; set; }

    public virtual StatusType? StatusType { get; set; }

    public virtual Title? Title { get; set; }

    public virtual User User { get; set; } = null!;
}
