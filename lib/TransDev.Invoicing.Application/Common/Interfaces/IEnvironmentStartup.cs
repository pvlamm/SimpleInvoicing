namespace TransDev.Invoicing.Application.Common.Interfaces
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IEnvironmentStartup
    {
        IConfiguration Configuration { get; }

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
        void ConfigureServices(IServiceCollection services);
    }
}