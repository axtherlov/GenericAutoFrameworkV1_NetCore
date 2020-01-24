using AutoFramework.Base;
using AutomationPracticeTests.Pages;

namespace AutomationPracticeTests.Steps.Shared
{
    public class NavigationSteps : BaseStep
    {
        public NavigationSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        protected LoginPage NavigateToLoginPage()
        {
            driverContext.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            driverContext.CurrentPage = new LoginPage(driverContext);
            return driverContext.CurrentPage.As<LoginPage>();
        }

        protected HomePage GoToHomePage()
        {
            driverContext.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driverContext.CurrentPage = new HomePage(driverContext);
            return driverContext.CurrentPage.As<HomePage>();
        }
    }
}