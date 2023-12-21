using Microsoft.EntityFrameworkCore;
using Sm.Crm.Domain.Entities.BaseEntity;
namespace Sm.Crm.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext/*, IApplicationDbContext*/
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<OfferStatus> OfferStatuses { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestStatus> RequestStatuses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<Domain.Entities.BaseEntity.Task> Tasks { get; set; }
    public DbSet<Domain.Entities.BaseEntity.TaskStatus> TaskStatuses { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<UserEmail> UserEmails { get; set; }
    public DbSet<UserPhone> UserPhones { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserStatus> UserStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {


        //builder.Entity<Request>()
        // .HasOne(r => r.CustomerUser)
        // .WithMany()
        // .HasForeignKey(r =>r.CustomerUserId);



        //builder.Entity<Request>()
        //    .HasOne(r => r.EmployeeUser)
        //    .WithMany()
        //    .HasForeignKey(r => r.EmployeeUserId);
        builder.Entity<Offer>()
            .Property(o => o.BidAmount)
            .HasColumnType("decimal(18, 2)");
        builder.Entity<Sale>()
            .Property(s => s.SaleAmount)
            .HasColumnType("decimal(18, 2)");

        base.OnModelCreating(builder);

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker Entitiler üzerinde yeni ekleme ve  yapılan değişiklikleri yakalayan propertidir.
        var values = ChangeTracker.Entries<BaseEntity>();
        foreach (var value in values)
        {
            _ = value.State switch
            {
                EntityState.Added => value.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => value.Entity.UpdateDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
