using Microsoft.EntityFrameworkCore;
using Sm.Crm.Domain.Entities.LST;
using Sm.Crm.Domain.Entities;


namespace Sm.Crm.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Notification> Notificiations { get; }
    DbSet<Offer> Offers { get; }
    DbSet<Request> Requests { get; }
    DbSet<Sale> Sales { get; }
    DbSet<TaskItem> Tasks { get; }
    DbSet<User> Users { get; }
    DbSet<UserPhone> UserPhones { get; }
    DbSet<UserEmail> UserEmails { get; }

    #region LST Schema

    DbSet<UserStatus> UserStatuses { get; }
    DbSet<TaskStatusItem> TaskStatuses { get; }
    DbSet<Department> Departments { get; }

    #endregion

    Task SaveChangesAsync();
}
