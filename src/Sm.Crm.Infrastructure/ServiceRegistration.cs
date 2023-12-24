
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sm.Crm.Application.Common.Interfaces;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Application.Validator.Customer;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Persistence.Mapping;
using Sm.Crm.Infrastructure.Persistence.Services.Customers;
using Sm.Crm.Infrastructure.Repositories.Customers;

namespace Sm.Crm.Infrastructure
{
    public static class ServiceRegistration
    {
        //public static void AddInfrastructureServices(this IServiceCollection services)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));

        //    services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        //    services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
        //    services.AddScoped<ICustomerService, CustomerService>();
        //    //services.AddScoped<IValidator<CreateCustomerDto>, CreateCustomerValidator>();


        //}


        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            //services.AddScoped<IValidator<CreateCustomerDto>, CreateCustomerValidator>();

            return services;
        }
        //public static MapperConfiguration Initialize()
        //{
        //    return new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile<MappingProfile>();
        //    });
        //}
    }
}
