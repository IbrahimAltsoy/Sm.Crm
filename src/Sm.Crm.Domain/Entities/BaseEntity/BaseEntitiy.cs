namespace Sm.Crm.Domain.Entities.BaseEntity
{

    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        virtual public DateTime? UpdateDate { get; set; }

    }

}
