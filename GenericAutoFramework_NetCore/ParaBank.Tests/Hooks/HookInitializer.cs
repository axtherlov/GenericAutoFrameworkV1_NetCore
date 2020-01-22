using AutoFramework.Base;
using AutoFramework.Config;
using NUnit.Framework;
using ParaBank.Tests.Steps.Shared;

namespace ParaBank.Tests.Hooks
{
    //[TestFixture]
    public class HookInitializer : TestFrameworkHook
    {
        protected NavigationSteps navigationSteps;
        public HookInitializer(DriverContext driverContext) 
            : base(driverContext)
        {
            navigationSteps = new NavigationSteps(driverContext);
        }

        [SetUp]
        public void Setup()
        {
            SetupFrameworkSettings(new ConfigJsonReader());
            InitializeBrowser();
            navigationSteps.NavigateToSite();
        }

        [TearDown]
        public void TearDown()
        {
            CloseBrowser();
        }

    }
}
