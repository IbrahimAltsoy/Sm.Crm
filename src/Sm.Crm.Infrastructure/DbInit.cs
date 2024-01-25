using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sm.Crm.Infrastructure.Persistence.Seeders;

namespace Sm.Crm.Infrastructure.Persistence;

public static class DbInitExtensions
{
    public static async Task InitializeDb(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        //context.Database.Migrate();
        //// LST
        //await new DepartmentSeeder().Seed(context);

        //await new CustomerSeeder().Seed(context);
        //await new EmployiesSeeder().Seed(context);
        //await new SaleSeeder().Seed(context);
        //await new RequestSeeder().Seed(context);

    }
}