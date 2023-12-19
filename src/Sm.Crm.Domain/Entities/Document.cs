

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class Document:BaseEntity
{
    //public int Id { get; set; }

    public int UserId { get; set; }

    public int? RequestId { get; set; }

    public string DocumentFileName { get; set; } = null!;

    public int DocumentTypeId { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
