using AutoFramework.Config;
using AutoFramework.Helpers;

namespace AutoFramework.Base
{
    public abstract class BaseStep : Base
    {
        protected BaseStep(DriverContext driverContext)
            : base(driverContext)
        {
        }

        protected void NavigateToInitialSite()
        {
            driverContext.Driver.Navigate().GoToUrl(Settings.Aut);
            LogHelpers.Write($"Navigated to {Settings.Aut}");
        }
    }
}
