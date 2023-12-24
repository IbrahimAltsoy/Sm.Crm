using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class Employee : BaseEntity
{
    public int UserId { get; set; }
    public string IdentityNumber { get; set; } = null!;
    public int? GenderId { get; set; }
    public int? DepartmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public int? StatusTypeId { get; set; }
    public int? TerritoryId { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int? ReportsToUserId { get; set; }
    public string PhotoPath { get; set; }
}