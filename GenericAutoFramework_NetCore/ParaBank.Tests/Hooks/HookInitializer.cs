using AutoFramework.Base;
using AutoFramework.Config;
using NUnit.Framework;
using ParaBank.Tests.Steps.Shared;

namespace ParaBank.Tests.Hooks
{
    public class HookInitializer : BaseHook
    {
       // protected BaseHook baseHook;
        protected NavigationSteps navigationSteps;

        protected HookInitializer(DriverContext driverContext) 
            : base (driverContext)
        {
            
        }

        public HookInitializer()
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
