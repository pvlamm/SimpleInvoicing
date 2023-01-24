namespace TransDev.Invoicing.InfrastructureTests.Services;

using FluentAssertions;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;
using TransDev.SimpleInvoicing.TestHelpers;

using static SimpleInvoicing.TestHelpers.Testing;

[TestClass]
public class ClientServiceTests : TestBase
{
    IDisposable _lifetime;
    IApplicationDbContext _applicationDbContext;
    IClientService _clientService;

    [TestInitialize]
    public async Task Initialize()
    {
        _lifetime = GetImplementation(out _applicationDbContext, out _clientService);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _lifetime.Dispose();
        _lifetime = null;
        _applicationDbContext = null;
        _clientService = null;
    }

    [TestMethod]
    public async Task ClientService_AddClient_ClientNameAlreadyExistsCheck_Fails()
    {
        var companyName = "Unit Test";
        var exists = await _clientService.ClientExistsAsync(companyName, default(CancellationToken));
        Assert.IsFalse(exists);
        await CreateDefaultCompanyEntry(companyName);

        exists = await _clientService.ClientExistsAsync(companyName, default(CancellationToken));
        Assert.IsTrue(exists);
    }

    private async Task CreateDefaultCompanyEntry(string companyName)
    {
        var address = new SystemAddress
        {
            Address = "100 East Main St.",
            City = "The City",
            State = new SystemState("NC"),
            SystemStateId = "NC",
            ZipCode = "22222"
        };

        var contactHistory = new ContactHistory
        {
            Address = address,
            EmailAddress = "email@address.org",
            FirstName = "Test",
            LastName = "Test",
            PhoneNumber = "704.555.5555",
        };


        var clientHistory = new ClientHistory
        {
            Name = companyName,
            IsActive = true
        };

        await _clientService.CreateClientAsync(Domain.Enums.ClientType.Commercial, clientHistory,
            contactHistory, contactHistory,
            address, address,
            default(CancellationToken));

        clientHistory.Id.Should().BeGreaterThan(0);
    }
}