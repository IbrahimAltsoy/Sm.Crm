using Bogus;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence.Abstract;

namespace Sm.Crm.Infrastructure.Persistence.Seeders
{
    public class SaleSeeder : ISeeder
    {
        public async Task Seed(ApplicationDbContext context)
        {
            if (context.Sales.Any()) return;
            var saleSet = new Bogus.DataSets.Commerce(locale: "tr");
            var saleFaker = new Faker<Sale>("tr")
                .RuleFor(p => p.EmployeeUserId, e => e.Random.Number(1, 500))
                //.RuleFor(p => p.EmployeeFk, f => new Faker<Employee>().Generate())
                //.RuleFor(p => p.RequestId, e => e.Random.Number(1, 500))
                .RuleFor(p => p.Name, p=>p.Commerce.ProductName())
                .RuleFor(p => p.SaleDate, f => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now).ToUniversalTime())
                .RuleFor(p => p.SaleAmount, f => f.Random.Decimal(10, 1000))
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription());

            var list = saleFaker.Generate(500);
            await context.Sales.AddRangeAsync(list);
            await context.SaveChangesAsync();
           
        }
    }
}
