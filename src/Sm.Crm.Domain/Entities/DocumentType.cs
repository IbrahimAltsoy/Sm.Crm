
namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class DocumentType:BaseEntity
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
