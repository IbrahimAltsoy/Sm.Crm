using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer), "dbo");

        builder
            .Property(b => b.IdentityNumber)
            .HasMaxLength(100);

        builder
            .Property(b => b.CompanyName)
            .HasMaxLength(250);

        builder
            .HasOne(e => e.UserFk)
            .WithOne(e => e.CustomerFk)
            .HasForeignKey<Customer>(e => e.UserId)
            //.IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        // Global Query Filter
        builder.HasQueryFilter(p => p.DeletedBy == null);
    }
}