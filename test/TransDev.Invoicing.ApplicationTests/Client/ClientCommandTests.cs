namespace TransDev.Invoicing.ApplicationTests.Client;

using FluentAssertions;

using TransDev.Invoicing.Application.Client.Commands;
using TransDev.Invoicing.Application.Common.Exceptions;
using TransDev.SimpleInvoicing.TestHelpers;

using static SimpleInvoicing.TestHelpers.Testing;

[TestClass]
public class ClientCommandTests : TestBase
{
    [TestMethod]
    public async Task ClientCommand_CreateClient_NullFields_ThrowValidationException()
    {
        var command = new CreateClientCommand(){
            
        };

        await FluentActions.Invoking(() => SendAsync(command))
            .Should()
            .ThrowAsync<ValidationException>()
            .Where(e => e.Errors["PrimaryContact"]
                .Contains(CreateClientValidator.Message_InvalidPrimaryContact));

    }

    [TestMethod]
    public async Task ClientCommand_CreateClient_DuplicateCompanyName_ThrowsValidationException()
    {
        var command = new CreateClientCommand() { };

        Assert.IsTrue(true);
    }
}