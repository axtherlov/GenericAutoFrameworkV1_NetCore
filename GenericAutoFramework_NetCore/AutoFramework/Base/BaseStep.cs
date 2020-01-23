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
            Logger.LogInfo($"Navigated to {Settings.Aut}"); 
        }
    }
}
