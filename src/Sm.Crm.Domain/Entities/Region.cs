

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Region:BaseEntity
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
