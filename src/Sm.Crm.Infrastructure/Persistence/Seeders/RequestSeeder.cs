using Bogus;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence.Abstract;

namespace Sm.Crm.Infrastructure.Persistence.Seeders
{
    public class RequestSeeder : ISeeder
    {
        public async Task Seed(ApplicationDbContext context)
        {
            if (context.Requests.Any()) return;

            var requestSet = new Bogus.DataSets.Commerce(locale: "tr");

            var requestFaker = new Faker<Request>("tr")
                .RuleFor(r => r.CustomerUserId, r => r.Random.Number(0, 500))
                .RuleFor(r => r.EmployeeUserId, r => r.Random.Number(0,500))
                .RuleFor(r => r.RequestStatusId, r => r.Random.Number(0, 1))
                .RuleFor(r => r.Description, r => r.Commerce.ProductDescription());

            var list = requestFaker.Generate(500);

            await context.Requests.AddRangeAsync(list);
            await context.SaveChangesAsync();




        }
    }
}
