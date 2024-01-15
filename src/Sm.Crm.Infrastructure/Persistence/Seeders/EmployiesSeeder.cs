using Bogus;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence.Abstract;

namespace Sm.Crm.Infrastructure.Persistence.Seeders
{
    public class EmployiesSeeder : ISeeder
    {
        public async Task Seed(ApplicationDbContext context)
        {
            if (context.Employees.Any()) return;
            var companySet = new Bogus.DataSets.Name(locale: "tr");
            var employiesFaker = new Faker<Employee>("tr")
                .RuleFor(e=>e.Name, e=>e.Name.FirstName())
                .RuleFor(e=>e.Surname, e=>e.Name.LastName())
                .RuleFor(e=>e.Email,e=>e.Internet.Email())               
                .RuleFor(e => e.UserId, e => e.IndexFaker)
                .RuleFor(e => e.IdentityNumber, e => e.Random.Number(10000000, 99999999).ToString())
                .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber("5#########"))
                .RuleFor(e => e.GenderId, e => e.Random.Number(0, 1))
                .RuleFor(e => e.StartDate, e => e.Date.Between(DateTime.Now.AddYears(-10), DateTime.Now).Date)
                .RuleFor(e => e.BirthDate, e => DateOnly.FromDateTime(e.Date.Between(DateTime.Now.AddYears(-55), DateTime.Now.AddYears(-18))))
                .RuleFor(e => e.PhotoPath, e => e.Image.PicsumUrl());

            var list = employiesFaker.Generate(500);
            await context.Employees.AddRangeAsync(list);
            await context.SaveChangesAsync();

        }
    }
}
