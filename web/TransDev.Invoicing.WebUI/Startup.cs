namespace TransDev.Invoicing.WebUI;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.OpenApi.Models;

using TransDev.Invoicing.Application;
using TransDev.Invoicing.Infrastructure;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {
            builder
            .WithOrigins("http://localhost:8081")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        services.AddApplication();
        services.AddInfrastructre(Configuration);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransDev.Invoicing.WebUI", Version = "v1" });
        });

        services.AddSwaggerDocument(options =>
        {
            options.GenerateEnumMappingDescription = true;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        const string swaggerRoot = "/api/docs";
        const string swaggerJson = swaggerRoot + "/v1/swagger.json";

        app.UseCors("CorsPolicy");
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerJson, "TransDev.Invoicing.WebUI"));
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStaticFiles();

        if (env.IsDevelopment())
        {
            app.UseHttpsRedirection();
        }

        app.UseRouting();

        app.UseOpenApi(options => options.Path = swaggerJson);
        app.UseSwaggerUi3(options =>
        {
            options.DocumentPath = swaggerJson;
            options.Path = swaggerRoot;
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            //endpoints.MapRazorPages();
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    }
}
