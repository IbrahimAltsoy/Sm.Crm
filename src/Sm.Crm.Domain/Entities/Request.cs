using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class Request : BaseEntity
{
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string? Description { get; set; }
}