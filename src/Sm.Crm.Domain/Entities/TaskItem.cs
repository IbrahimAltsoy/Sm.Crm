using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class TaskItem : BaseEntity
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
    public int TaskStatusId { get; set; }

    #region Navigation Properties

    public Request RequestFk { get; set; }
    public Employee EmployeeFk { get; set; }
    public TaskStatus TaskStatusFk { get; set; }

    #endregion
}