namespace TransDev.Invoicing.InfrastructureTests.Services;

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
        var auditTrail = new AuditTrail
        {
            CreatedDate = DateTime.UtcNow,
            Note = "ClientServiceTests/ClientNameAlreadyExistsCheck"
        };

        var client = new Client
        {

        };

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
            AuditTrail = auditTrail,
            Address = address,
            EmailAddress = "email@address.org",
            FirstName = "Test",
            LastName = "Test",
            PhoneNumber = "704.555.5555",
        };

        var contact = new Contact
        {
            Client = client,
            History = new HashSet<ContactHistory> { contactHistory }
        };

        var clientHistory = new ClientHistory
        {
            Parent = client,
            AuditTrail = auditTrail,
            PrimaryContact = contact,
            PrimaryBillingContact = contact,
            PrimaryAddress = address,
            BillingAddress = address,
            Name = companyName,
            IsActive = true
        };

        client.History = new HashSet<ClientHistory> { clientHistory };

        await _clientService.CreateClientAsync(client, default(CancellationToken));
    }
}