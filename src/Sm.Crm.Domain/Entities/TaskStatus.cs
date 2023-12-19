
namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class TaskStatus:BaseEntity
{
    //public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
