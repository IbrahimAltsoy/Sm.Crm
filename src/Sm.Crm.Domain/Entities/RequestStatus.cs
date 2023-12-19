

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class RequestStatus:BaseEntity
{
    //public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
