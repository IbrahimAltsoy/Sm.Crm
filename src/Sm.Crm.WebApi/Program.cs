using Microsoft.AspNetCore.Hosting;
using Sm.Crm.Application;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Infrastructure;
using Sm.Crm.Infrastructure.Filters;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Persistence.Mapping;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Sm.Crm.Application.Validator.Customer;
using Sm.Crm.WebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IValidator<CreateCustomerDto>, CreateCustomerValidator>();

builder.Services.AddScoped<IAsyncActionFilter, ValidationFilter>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddHttpClient();
builder.Services.AddWebApiServices();

builder.Services.AddAutoMapper(typeof(Program), typeof(MappingProfile));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configration => configration.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//builder.Services.AddApplicationServices();
//builder.Services.AddDbContext<ApplicationDbContext>();
// Add services to the container.

//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service dependiences


//MultipleActiveResultSets = True;
//dotnet ef dbcontext scaffold "Server=DESKTOP-O97PCTN;Database=SF2_CRM; Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o OutputDirectory
//A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SNI_PN11, error: 26 - Error Locating Server/Instance Specified)


//Server = destrop-097pctn\sqlexpress; Database = ECommerceDb; Trusted_Connection = True; TrustServerCertificate = True
//dotnet ef dbcontext scaffold "destrop-097pctn\sqlexpress;Database=SF2_CRM; Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o OutputDirectory

//    destrop-097pctn\sqlexpress
//DESKTOP - O97PCTN\SQLEXPRESS
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
            NameClaimType = ClaimTypes.Name

        };
    });

var app = builder.Build();

// CodeFirst Db Creating
using var scope = app.Services.CreateScope();
//var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.InitializeDb();
}
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
//Ibrahim 
