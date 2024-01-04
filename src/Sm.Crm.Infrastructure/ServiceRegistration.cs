
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sm.Crm.Application.Common.Interfaces;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Repositories.Users;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Application.Services.Users;
using Sm.Crm.Application.Validator.Customer;
using Sm.Crm.Domain;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Persistence.Mapping;
using Sm.Crm.Infrastructure.Persistence.Services.Customers;
using Sm.Crm.Infrastructure.Persistence.Services.Users;
using Sm.Crm.Infrastructure.Repositories;
using Sm.Crm.Infrastructure.Repositories.Customers;
using Sm.Crm.Infrastructure.Repositories.Users;

namespace Sm.Crm.Infrastructure
{
    public static class ServiceRegistration
    {
        

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));

            

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<User, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
          
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
