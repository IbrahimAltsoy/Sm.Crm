using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities.LST;

public class Territory : BaseEntity
{
    public string Name { get; set; }

    public int RegionId { get; set; }
}