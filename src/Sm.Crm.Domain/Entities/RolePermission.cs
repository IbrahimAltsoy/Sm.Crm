

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class RolePermission:BaseEntity
{
    //public int Id { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
