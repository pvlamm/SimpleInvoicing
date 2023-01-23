namespace TransDev.SimpleInvoicing.TestHelpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Moq;
using Respawn;
using Newtonsoft.Json;

using TransDev.Invoicing.Infrastructure.Persistance;
using TransDev.Invoicing.WebUI;
using Respawn.Graph;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq.Expressions;
using TransDev.Invoicing.Application.Common.Interfaces;

[TestClass]
public static class Testing
{
    private static IConfigurationRoot _configuration;
    private static IServiceScopeFactory _scopeFactory;
    private static Respawner _checkpoint;
    private static string _currentUserId;

    private readonly static Dictionary<string, string> PropertyToTableLookup = new Dictionary<string, string>();

    [AssemblyInitialize]
    public static async void RunBeforeAnyTests(TestContext context)
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

        _configuration = builder.Build();

        var startup = new Startup(_configuration);

        RunBeforeAnyTests(context, startup);
    }

    [AssemblyInitialize]
    public static async void RunBeforeAnyTests(TestContext context, IEnvironmentStartup startup)
    {
        var services = new ServiceCollection();

        services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.EnvironmentName == "Development" &&
            w.ApplicationName == "TransDev.Invoicing.WebUI"));

        services.AddLogging();

        startup.ConfigureServices(services);

        // Replace service registration for ICurrentUserService
        // Remove existing registration
        /* -- We'll be implementing this when we NEED to implement this
        var currentUserServiceDescriptor = services.FirstOrDefault(d =>
            d.ServiceType == typeof(ICurrentUserService));

        services.Remove(currentUserServiceDescriptor);

        var mailService = services.FirstOrDefault(d => d.ServiceType == typeof(IMailService));
        services.Remove(mailService);
        var currentUserService = new CurrentUserServiceTest();

        services.AddTransient<ICurrentUserService, CurrentUserServiceTest>();
        services.AddTransient<IMailService, MailServiceTest>();
        */

        _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

        JsonConvert.DefaultSettings = () =>
            new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

        EnsureDatabase();

        var connection = _configuration.GetConnectionString("DefaultConnection");
        try
        {
            _checkpoint = Respawner.CreateAsync(connection, new RespawnerOptions
            {
                TablesToIgnore = new Table[] { "__EFMigrationsHistory" },
                WithReseed = true
            }).Result;
        }
        catch(Exception e)
        {
            string errormsg = e.Message;
        }
    }

    private static void EnsureDatabase()
    {
        using var _ = GetImplementation(out ApplicationDbContext context);
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var _ = GetImplementation(out IMediator mediator);
        return await mediator.Send(request);
    }

    public static async Task<string> RunAsDefaultUserAsync()
    {
        return await RunAsUserAsync("test@local", "Testing1234!");
    }

    public static async Task<string> RunAsUserAsync(string userName, string _)
    {
        //using var _ = GetImplementation(out UserManager<SystemUser> userManager);
        //var user = new SystemUser { Username = userName, Email = userName };
        //var result = await userManager.CreateAsync(user, password);
        //_currentUserId = user.Username;

        // TODO: Remove
        await Task.Yield();

        _currentUserId = userName;

        return _currentUserId;
    }

    public static string GetTableName(IApplicationDbContext context, Expression<Func<IApplicationDbContext, IQueryable>> tableLookup)
    {
        var memberExpr = (MemberExpression)tableLookup.Body;
        var key = memberExpr.Member.Name;
        if (!PropertyToTableLookup.TryGetValue(key, out var tableName))
        {
            var type = memberExpr.Type;
            if (type.IsGenericType)
                type = type.GetGenericArguments()[0];
            tableName = context.Model.FindEntityType(type).GetTableName();
            PropertyToTableLookup.Add(key, tableName);
        }
        return tableName;
    }

    public static async Task ResetState()
    {
        await _checkpoint.ResetAsync(_configuration.GetConnectionString("DefaultConnection"));
        _currentUserId = null;
    }

    public static async Task<TEntity> FindAsync<TEntity>(int id)
        where TEntity : class
    {
        using var _ = GetImplementation(out ApplicationDbContext context);
        return await context.FindAsync<TEntity>(id);
    }

    public static async Task<TEntity> FindAsync<TEntity>(long id)
        where TEntity : class
    {
        using var _ = GetImplementation(out ApplicationDbContext context);
        return await context.FindAsync<TEntity>(id);
    }

    public static async Task<TResult> ExecuteAsync<TEntity, TResult>(Func<IQueryable<TEntity>, Task<TResult>> query)
        where TEntity : class
    {
        using var _ = GetImplementation(out ApplicationDbContext context);
        var result = await query(context.Set<TEntity>());

        return result;
    }

    [AssemblyCleanup]
    public static void RunAfterAnyTests()
    {
    }

    //public class CurrentUserServiceTest : ICurrentUserService
    //{
    //    public string Username => _currentUserId;
    //}

    public static string GetSourceFile() => new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();

    #region [ GetImplementation ]

    public static IDisposable GetImplementation<T1>(out T1 impl1)
    {
        var scope = _scopeFactory.CreateScope();
        try
        {
            impl1 = scope.ServiceProvider.GetService<T1>();
        }
        catch
        {
            scope.Dispose();
            throw;
        }
        return scope;
    }

    public static IDisposable GetImplementation<T1, T2>(out T1 impl1, out T2 impl2)
    {
        var scope = _scopeFactory.CreateScope();
        try
        {
            impl1 = scope.ServiceProvider.GetService<T1>();
            impl2 = scope.ServiceProvider.GetService<T2>();
        }
        catch
        {
            scope.Dispose();
            throw;
        }
        return scope;
    }

    public static IDisposable GetImplementation<T1, T2, T3>(out T1 impl1, out T2 impl2, out T3 impl3)
    {
        var scope = _scopeFactory.CreateScope();
        try
        {
            impl1 = scope.ServiceProvider.GetService<T1>();
            impl2 = scope.ServiceProvider.GetService<T2>();
            impl3 = scope.ServiceProvider.GetService<T3>();
        }
        catch
        {
            scope.Dispose();
            throw;
        }
        return scope;
    }

    public static IDisposable GetImplementation<T1, T2, T3, T4>(out T1 impl1, out T2 impl2, out T3 impl3, out T4 impl4)
    {
        var scope = _scopeFactory.CreateScope();
        try
        {
            impl1 = scope.ServiceProvider.GetService<T1>();
            impl2 = scope.ServiceProvider.GetService<T2>();
            impl3 = scope.ServiceProvider.GetService<T3>();
            impl4 = scope.ServiceProvider.GetService<T4>();
        }
        catch
        {
            scope.Dispose();
            throw;
        }
        return scope;
    }

    public static IDisposable GetImplementation<T1, T2, T3, T4, T5>(out T1 impl1, out T2 impl2, out T3 impl3, out T4 impl4, out T5 impl5)
    {
        var scope = _scopeFactory.CreateScope();
        try
        {
            impl1 = scope.ServiceProvider.GetService<T1>();
            impl2 = scope.ServiceProvider.GetService<T2>();
            impl3 = scope.ServiceProvider.GetService<T3>();
            impl4 = scope.ServiceProvider.GetService<T4>();
            impl5 = scope.ServiceProvider.GetService<T5>();
        }
        catch
        {
            scope.Dispose();
            throw;
        }
        return scope;
    }

    #endregion

}
