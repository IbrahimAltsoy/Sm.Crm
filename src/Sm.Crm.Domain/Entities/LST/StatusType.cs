using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities.LST;

public class StatusType : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Customer> Customers { get; set; }
}