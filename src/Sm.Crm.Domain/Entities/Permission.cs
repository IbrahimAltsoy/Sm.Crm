
namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Permission:BaseEntity
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
