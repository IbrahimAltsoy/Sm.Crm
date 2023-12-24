using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class UserEmail : BaseEntity
{
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public short? EmailType { get; set; }

    // Navigation Properties
    //public User? UserFk { get; set; }
}