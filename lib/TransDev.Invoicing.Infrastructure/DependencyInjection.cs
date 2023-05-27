namespace TransDev.Invoicing.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;
using TransDev.Invoicing.Infrastructure.Persistance;
using TransDev.Invoicing.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructre(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase") || configuration["inmemorydb"] == "true")
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging(true)
                    .UseInMemoryDatabase("cleanDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging(true)
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddTransient<IDateTimeService, DateTimeService>();
        
        services.AddTransient<ISystemAddressService, SystemAddressService>();
        services.AddTransient<ISystemStateService, SystemStateService>();
        
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        services.AddTransient<IItemService, ItemService>();
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<IContactService, ContactService>();
        services.AddTransient<IInvoiceService, InvoiceService>();

        return services;
    }

    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });
}
