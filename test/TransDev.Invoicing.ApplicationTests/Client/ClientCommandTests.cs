namespace TransDev.Invoicing.ApplicationTests.Client;

using FluentAssertions;

using TransDev.Invoicing.Application.Client.Commands;
using TransDev.SimpleInvoicing.TestHelpers;

using static SimpleInvoicing.TestHelpers.Testing;

[TestClass]
public class ClientCommandTests : TestBase
{
    [TestMethod]
    public void TestMethod1()
    {
        var command = new CreateClientCommand(){
            
        };

        FluentActions.Invoking(() => SendAsync(command)).Should()
            .ThrowAsync<ValidationException>()
            .Where(e => e.Errors[nameof(UpdateAgenciesCommand.CsvFile)].Contains(UpdateAgenciesCommandValidator.Message_InvalidCsvFormat));

    }
}