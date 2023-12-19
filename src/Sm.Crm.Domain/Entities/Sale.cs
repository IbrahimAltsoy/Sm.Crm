

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Sale:BaseEntity
{
    //public int Id { get; set; }

    public int RequestId { get; set; }

    public int EmployeeUserId { get; set; }

    //public DateTime SaleDate { get; set; }

    public decimal SaleAmount { get; set; }

    public string Description { get; set; } = null!;

    public virtual User EmployeeUser { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
