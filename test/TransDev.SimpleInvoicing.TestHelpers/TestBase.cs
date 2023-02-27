namespace TransDev.SimpleInvoicing.TestHelpers;

using System.Linq.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TransDev.Invoicing.Application.Common.Interfaces;

using static Testing;

[TestClass]
public class TestBase
{
    [TestInitialize]
    public async Task TestSetup()
    {
        await ResetState();
    }

    protected async Task SeedDBAsync(params Expression<Func<IApplicationDbContext, IQueryable>>[] requiredFields)
    {
        using var _ = GetImplementation(out IApplicationDbContext context);
        //await TestApplicationDbContextSeed.SeedDefaultValuesAsync(context, requiredFields);
    }
}