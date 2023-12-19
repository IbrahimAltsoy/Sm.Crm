

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Setting:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public string? SettingKey { get; set; }

    public string SettingValue { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
