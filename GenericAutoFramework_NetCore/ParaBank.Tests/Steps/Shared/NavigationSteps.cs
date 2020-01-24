using AutoFramework.Base;

namespace ParaBank.Tests.Steps.Shared
{
    public class NavigationSteps : BaseStep
    {
        public NavigationSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void NavigateToSite()
        {
            NavigateToInitialSite();
        }
    }
}
