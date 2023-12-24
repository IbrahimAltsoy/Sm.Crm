using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class Notification : BaseEntity
{
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string Description { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }

    //public User User { get; set; } = null!;
}