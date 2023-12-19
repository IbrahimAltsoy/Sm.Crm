

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Task:BaseEntity
{
    //public int Id { get; set; }

    public int RequestId { get; set; }

    public int EmployeeUserId { get; set; }

    //public DateTime TaskStartDate { get; set; }

    public DateTime TaskEndDate { get; set; }

    public string Description { get; set; } = null!;

    public int TaskStatusId { get; set; }

    public virtual User EmployeeUser { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;

    public virtual TaskStatus TaskStatus { get; set; } = null!;
}
