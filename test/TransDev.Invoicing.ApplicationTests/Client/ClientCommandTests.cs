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
    public void ClientCommand_CreateClient_NullFields_ThrowValidationException()
    {
        var command = new CreateClientCommand(){
            
        };

        FluentActions.Invoking(() => SendAsync(command)).Should()
            .ThrowAsync<ValidationException>()
            .Where(e => e.Errors[nameof(CreateClientCommand)]
                .Contains(CreateClientValidator.Message_InvalidPrimaryContact));

    }
}