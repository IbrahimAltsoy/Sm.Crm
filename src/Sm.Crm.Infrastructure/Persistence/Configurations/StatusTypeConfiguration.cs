using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sm.Crm.Domain.Entities.LST;

namespace Sm.Crm.Infrastructure.Persistence.Configurations;

public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
{
    public void Configure(EntityTypeBuilder<StatusType> builder)
    {
        builder.ToTable(nameof(StatusType), "LST");

        builder
            .Property(b => b.Name)
            .HasMaxLength(150);

        builder
            .HasMany(b => b.Customers)
            .WithOne(e => e.StatusTypeFk)
            .HasForeignKey(e => e.StatusTypeId);
    }
}