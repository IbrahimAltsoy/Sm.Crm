namespace Sm.Crm.Infrastructure.Persistence.Abstract
{
    public interface ISeeder
    {
        Task Seed(ApplicationDbContext context);
    }
}
