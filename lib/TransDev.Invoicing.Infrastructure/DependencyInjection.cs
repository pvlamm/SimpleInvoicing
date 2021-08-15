using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Infrastructure.Persistance;
using TransDev.Invoicing.Infrastructure.Services;

namespace TransDev.Invoicing.Infrastructure
{
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
                        .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
    }
}
