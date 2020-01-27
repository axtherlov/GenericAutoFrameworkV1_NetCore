using AutoFramework.Base;
using AutoFramework.Config;
using NUnit.Framework;
using ParaBank.Tests.Steps.Shared;

namespace ParaBank.Tests.Hooks
{
    public class HookInitializer
    {
        protected NavigationSteps navigationSteps;
        protected DriverContext driverContext;

        public HookInitializer()
        {
            navigationSteps = new NavigationSteps(driverContext);
        }

        [SetUp]
        public void Setup()
        {
            BaseHook.SetupFrameworkSettings(new ConfigJsonReader());
            //driverContext = InitializeBrowser();
            navigationSteps.NavigateToSite();
        }

        [TearDown]
        public void TearDown()
        {
            //CloseBrowser();
        }
    }
}
