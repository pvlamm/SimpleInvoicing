namespace TransDev.Invoicing.ApplicationTests;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions.Common;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TransDev.Invoicing.Application;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.ApplicationTests.ServiceMocks;
using TransDev.Invoicing.Infrastructure.Persistance;
using TransDev.Invoicing.Infrastructure.Services;

public class ApplicationTestsStartup : IEnvironmentStartup
{
    public ApplicationTestsStartup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();

        #region [ Mocked Infrastructure ]

        services.AddTransient<IDateTimeService, DateTimeServiceMock>();

        services.AddTransient<ISystemAddressService, SystemAddressServiceMock>();
        services.AddTransient<ISystemStateService, SystemStateServiceMock>();

        services.AddTransient<IAuthenticationService, AuthenticationServiceMock>();

        services.AddTransient<IItemService, ItemServiceMock>();
        services.AddTransient<IClientService, ClientServiceMock>();

        #endregion
    }
}
