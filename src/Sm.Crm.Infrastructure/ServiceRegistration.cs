
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Persistence.Services.Customers;
using Sm.Crm.Infrastructure.Repositories.Customers;

namespace Sm.Crm.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));

            services.AddScoped<ICustomerQueryRepository,CustomerQueryRepository>();
         services.AddScoped<ICustomerCommandRepository,CustomerCommandRepository>();    
         services.AddScoped<ICustomerService, CustomerService>();

        }
    }
}
