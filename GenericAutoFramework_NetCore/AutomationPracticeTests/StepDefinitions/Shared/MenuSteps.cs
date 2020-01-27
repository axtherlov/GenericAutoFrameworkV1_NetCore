using AutoFramework.Base;
using AutomationPracticeTests.Pages;

namespace AutomationPracticeTests.Steps.Shared
{
    public class MenuSteps : NavigationSteps
    {
        protected MenuSteps(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        protected void GoToContactUsPage()
        {
            driverContext.CurrentPage.As<HomePage>().ClickContactUsButton();
        }

        protected void GoToAddressCreationForm()
        {
            driverContext.CurrentPage.As<HomePage>().ClickAccountLink();
            driverContext.CurrentPage.As<AccountPage>().ClickMyAddressesLink();
            driverContext.CurrentPage.As<MyAddresses>().ClickAddNewAddressLink();
        }

        protected LoginPage GoToLoginPage()
        {
            driverContext.CurrentPage = new HomePage(driverContext);
            driverContext.CurrentPage.As<HomePage>().ClickSignButton();
            return driverContext.CurrentPage.As<LoginPage>();
        }
    }
}
