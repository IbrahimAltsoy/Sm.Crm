using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class Sale : BaseEntity
{
    public string Name { get; set; }
    public int? RequestId { get; set; }
    public int? EmployeeUserId { get; set; }    
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }

    // Navigation Properties
    public Request? RequestFk { get; set; }

    public Employee? EmployeeFk { get; set; }
}