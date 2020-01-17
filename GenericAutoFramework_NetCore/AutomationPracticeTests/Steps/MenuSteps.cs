using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using AventStack.ExtentReports.Model;

namespace AutomationPracticeTests.Steps
{
    public class MenuSteps : BaseStep
    {
        protected MenuSteps(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        protected MyAddresses NavigateToAddressCreationForm()
        {
            driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickAccountLink();
            driverContext.CurrentPage = driverContext.CurrentPage.As<AccountPage>().ClickMyAddressesLink();
            driverContext.CurrentPage.As<MyAddresses>().ClickAddNewAddressLink();
            return driverContext.CurrentPage.As<MyAddresses>();
        }

        protected LoginPage NavigateToLoginPage()
        {
            driverContext.CurrentPage = new HomePage(driverContext);
            driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickSignButton();
            return driverContext.CurrentPage.As<LoginPage>();
        }
    }
}
