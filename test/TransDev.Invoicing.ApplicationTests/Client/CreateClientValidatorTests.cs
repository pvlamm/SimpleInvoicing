namespace TransDev.Invoicing.ApplicationTests.Client;

using FluentValidation.TestHelper;

using Moq;

using TransDev.Invoicing.Application.Client.Commands;
using TransDev.Invoicing.Application.Common.Interfaces;

[TestClass]
public class CreateClientValidatorTests
{
    private readonly Mock<IClientService> _clientService = new Mock<IClientService>();

    public CreateClientValidatorTests()
    {

    }

    [TestMethod]
    public async Task CreateClientValidator_NullObjectProperties_PreValidation_ShouldHaveMultipleErrors()
    {
        var command = new CreateClientCommand(){
            
        };

        _clientService.Setup(service => 
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        Assert.IsTrue(result.Errors.Count > 0);
    }

    [TestMethod]
    public async Task CreateClientValidator_PrimaryContact_FirstName_NotPresent()
    {
        var command = new CreateClientCommand()
        {
            CompanyName = "Yor Folger's Needles",
            PrimaryContact = new Application.Common.Dtos.ContactDto { },
            PrimaryAddress = new Application.Common.Dtos.AddressDto { },
            BillingContact = new Application.Common.Dtos.ContactDto { },
            BillingAddress = new Application.Common.Dtos.AddressDto { }
        };

        _clientService.Setup(service =>
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.PrimaryContact.FirstName);

    }

    [TestMethod]
    public async Task CreateClientValidator_PrimaryContact_FirstName_TooShort()
    {
        var command = new CreateClientCommand()
        {
            CompanyName = "Yor Folger's Needles",
            PrimaryContact = new Application.Common.Dtos.ContactDto { 
                FirstName = "A"
            },
            PrimaryAddress = new Application.Common.Dtos.AddressDto { },
            BillingContact = new Application.Common.Dtos.ContactDto { },
            BillingAddress = new Application.Common.Dtos.AddressDto { }
        };

        _clientService.Setup(service =>
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.PrimaryContact.FirstName);

    }

    [TestMethod]
    public async Task CreateClientValidator_PrimaryContact_LastName_NotPresent()
    {
        var command = new CreateClientCommand()
        {
            CompanyName = "Yor Folger's Needles",
            PrimaryContact = new Application.Common.Dtos.ContactDto { },
            PrimaryAddress = new Application.Common.Dtos.AddressDto { },
            BillingContact = new Application.Common.Dtos.ContactDto { },
            BillingAddress = new Application.Common.Dtos.AddressDto { }
        };

        _clientService.Setup(service =>
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.PrimaryContact.LastName);

    }

    [TestMethod]
    public async Task CreateClientValidator_BillingContact_FirstName_TooShort()
    {
        var command = new CreateClientCommand()
        {
            CompanyName = "Yor Folger's Needles",
            PrimaryContact = new Application.Common.Dtos.ContactDto
            {
            },
            PrimaryAddress = new Application.Common.Dtos.AddressDto { },
            BillingContact = new Application.Common.Dtos.ContactDto
            {
                FirstName = "A"
            },
            BillingAddress = new Application.Common.Dtos.AddressDto { }
        };

        _clientService.Setup(service =>
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.BillingContact.FirstName);

    }
    [TestMethod]
    public async Task CreateClientValidator_PrimaryContact_EmailAddress_Is_Invalid()
    {
        var command = new CreateClientCommand()
        {
            CompanyName = "Yor Folger's Needles",
            PrimaryContact = new Application.Common.Dtos.ContactDto {
                EmailAddress = "Not Valid Email Address"
            },
            PrimaryAddress = new Application.Common.Dtos.AddressDto { },
            BillingContact = new Application.Common.Dtos.ContactDto { },
            BillingAddress = new Application.Common.Dtos.AddressDto { }
        };

        _clientService.Setup(service =>
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.PrimaryContact.EmailAddress);

    }

    [TestMethod]
    public async Task CreateClientValidator_CreateClient_DuplicateCompanyName_ThrowsValidationException()
    {
        _clientService.Setup(service =>
            service.ClientExistsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true));

        var command = new CreateClientCommand() { 
            CompanyName = "Steve's HVAC",
            PrimaryContact = new Application.Common.Dtos.ContactDto
            {
                FirstName= "Test",
                LastName= "Test",
                EmailAddress= "Test",
                PhoneNumber= "Test",
            },
            BillingContact = new Application.Common.Dtos.ContactDto { 
                FirstName = "Test",
                LastName= "Test",
                EmailAddress= "Test",
                PhoneNumber= "Test",
            },
            PrimaryAddress = new Application.Common.Dtos.AddressDto
            {
                Address = "100 Any St",
                City = "Test",
                State = "TN",
                ZipCode = "28310"
            },
            BillingAddress = new Application.Common.Dtos.AddressDto
            {
                Address = "100 Any St",
                City = "Test",
                State = "TN",
                ZipCode = "28310"
            }
        };

        CreateClientValidator val = new CreateClientValidator(_clientService.Object);
        var result = await val.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(cmd => cmd.CompanyName);
    }
}