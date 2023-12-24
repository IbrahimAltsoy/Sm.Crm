using Bogus;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Enums;
using Sm.Crm.Infrastructure.Persistence.Abstract;


namespace Sm.Crm.Infrastructure.Persistence.Seeders;

public class CustomerSeeder : ISeeder
{
    public async Task Seed(ApplicationDbContext context)
    {
        if (context.Customers.Any()) return;

        var companySet = new Bogus.DataSets.Company(locale: "tr");

        var customerFaker = new Faker<Customer>()
            .RuleFor(e => e.CompanyName, c => companySet.CompanyName())
            .RuleFor(e => e.IdentityNumber, c => c.Random.Long(11111111111, 59999999999).ToString())
            .RuleFor(e => e.BirthDate, c => new DateOnly(c.Random.Int(1980, 2000), 1, 1))
            .RuleFor(u => u.CustomerType, f => f.PickRandom<CustomerTypeEnum>())
            .RuleFor(u => u.Gender, f => f.PickRandom<GenderEnum>());
        //.RuleFor(e => e.UserId, c => c.Random.Int(1, 1000))
        //StatusTypeId = 1,
        //TerritoryId = 1,
        //TitleId = 1,

        var list = customerFaker.Generate(500);

        await context.Customers.AddRangeAsync(list);
        await context.SaveChangesAsync();
    }
}