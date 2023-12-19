

namespace Sm.Crm.Domain.Entities.BaseEntity;

public partial class User:BaseEntity
{
    //public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? UserStatusId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Request> RequestCustomerUsers { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestEmployeeUsers { get; set; } = new List<Request>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

    public virtual ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();

    public virtual ICollection<UserPhone> UserPhones { get; set; } = new List<UserPhone>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual UserStatus? UserStatus { get; set; }
}
