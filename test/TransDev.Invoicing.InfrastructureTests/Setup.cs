namespace TransDev.Invoicing.InfrastructureTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
}
