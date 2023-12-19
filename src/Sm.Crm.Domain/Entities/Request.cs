using System;
using System.Collections.Generic;

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Request:BaseEntity
{
    //public int Id { get; set; }

    //public int CustomerUserId { get; set; }

   
    //public int EmployeeUserId { get; set; }

    public int RequestStatusId { get; set; }

    public string? Description { get; set; }

   // public virtual User CustomerUser { get; set; } = null!;

   // public virtual User EmployeeUser { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual RequestStatus RequestStatus { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
