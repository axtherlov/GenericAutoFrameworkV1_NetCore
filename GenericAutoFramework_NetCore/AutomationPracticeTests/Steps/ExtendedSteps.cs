using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using TechTalk.SpecFlow;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    public class ExtendedSteps : BaseStep
    {
        public ExtendedSteps(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateToInitialSite();
            driverContext.CurrentPage = new HomePage(driverContext);
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "login")
            {
                driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickSignButton();
            }
            else if (linkName == "ContactUs")
            {
                driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickContactUsButton();
            }
            else if (linkName == "AccountName")
            {
                driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickAccountLink();
            }
            else if (linkName == "MyAddresses")
            {
                driverContext.CurrentPage = driverContext.CurrentPage.As<AccountPage>().ClickMyAddressesLink();
            }
            else if (linkName == "AddNewAddress")
            {
                driverContext.CurrentPage.As<MyAddresses>().ClickAddNewAddressLink();
            }
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if (buttonName == "login")
            {
                driverContext.CurrentPage = driverContext.CurrentPage.As<LoginPage>().ClickLoginButton();
            }
            if (buttonName == "Send")
            {
                driverContext.CurrentPage.As<ContactUsPage>().ClickSendButton();
            }
        }

        [When(@"I click (.*) button")]
        public void WhenIClickSendButton(string buttonName)
        {
            if (buttonName == "Save")
            {
                driverContext.CurrentPage.As<MyAddresses>().ClickSaveAddress();
            }
        }

    }
}
