using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities.LST;

public class Region : BaseEntity
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
}