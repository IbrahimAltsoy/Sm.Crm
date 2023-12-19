

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Title:BaseEntity
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
