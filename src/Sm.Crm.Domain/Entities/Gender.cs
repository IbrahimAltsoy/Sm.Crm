
namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Gender:BaseEntity
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
