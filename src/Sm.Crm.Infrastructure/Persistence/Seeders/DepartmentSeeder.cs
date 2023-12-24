using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence.Abstract;

namespace Sm.Crm.Infrastructure.Persistence.Seeders;

public class DepartmentSeeder : ISeeder
{
    public async Task Seed(ApplicationDbContext context)
    {
        if (context.Departments.Any()) return;

        var list = new List<Department>()
        {
            new() { Name = "Administration" },
            new() { Name = "Sale" },
            new() { Name = "Marketing" },
            new() { Name = "Accounting" },
            new() { Name = "Technical" }
        };
        await context.Departments.AddRangeAsync(list);
        await context.SaveChangesAsync();
    }
}