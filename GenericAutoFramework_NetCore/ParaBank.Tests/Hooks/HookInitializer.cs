using AutoFramework.Base;
using AutoFramework.Config;
using NUnit.Framework;
using ParaBank.Tests.Steps.Shared;

namespace ParaBank.Tests.Hooks
{
    public class HookInitializer : BaseHook
    {
        protected NavigationSteps navigationSteps;

        protected HookInitializer(DriverContext driverContext) 
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
