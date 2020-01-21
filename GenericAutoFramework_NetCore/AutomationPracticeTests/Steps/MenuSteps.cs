using AutoFramework.Base;
using AutomationPracticeTests.Pages;

namespace AutomationPracticeTests.Steps
{
    public class MenuSteps : NavigationSteps
    {
        protected MenuSteps(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        protected void GoToContactUsPage()
        {
            driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickContactUsButton();
        }

        protected void GoToAddressCreationForm()
        {
            driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickAccountLink();
            driverContext.CurrentPage = driverContext.CurrentPage.As<AccountPage>().ClickMyAddressesLink();
            driverContext.CurrentPage.As<MyAddresses>().ClickAddNewAddressLink();
        }

        protected LoginPage GoToLoginPage()
        {
            driverContext.CurrentPage = new HomePage(driverContext);
            driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickSignButton();
            return driverContext.CurrentPage.As<LoginPage>();
        }
    }

    public class NavigationSteps : BaseStep
    {
        protected NavigationSteps(DriverContext driverContext) 
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
