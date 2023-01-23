namespace TransDev.Invoicing.InfrastructureTests
{
    using TransDev.SimpleInvoicing.TestHelpers;

    using static SimpleInvoicing.TestHelpers.Testing;

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
}
