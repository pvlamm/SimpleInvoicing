namespace TransDev.Invoicing.ApplicationTests;

using TransDev.SimpleInvoicing.TestHelpers;

[TestClass]
public class Setup
{
    [AssemblyInitialize]
    public static void RunBeforeAnyTests(TestContext context)
    {
        Testing.RunBeforeAnyTests(context);
    }

    [AssemblyCleanup]
    public static void RunAfterAnyTests()
    {
        Testing.RunAfterAnyTests();
    }
}
