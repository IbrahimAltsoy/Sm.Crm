

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Notification:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public string? Title { get; set; }

    public string Description { get; set; } = null!;

    public bool IsRead { get; set; }

    //public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public virtual User User { get; set; } = null!;
}
