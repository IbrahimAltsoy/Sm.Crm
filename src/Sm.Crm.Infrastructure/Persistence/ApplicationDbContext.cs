using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Common.Interfaces;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Entities.LST;
using System.Reflection;
namespace Sm.Crm.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext,IApplicationDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Notification> Notificiations { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPhone> UserPhones { get; set; }
    public DbSet<UserEmail> UserEmails { get; set; }

    #region LST Schema

    public DbSet<UserStatus> UserStatuses { get; set; }
    public DbSet<TaskStatusItem> TaskStatuses { get; set; }
    public DbSet<Department> Departments { get; set; }

    #endregion

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}
