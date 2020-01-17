using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding, Scope(Feature = "Login")]
    public sealed class LoginSteps : MenuSteps
    {
        public LoginSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        #region Given

        [Given(@"I navigated to the login page")]
        public void GivenINavigatedToTheLoginPage()
        {
            NavigateToInitialSite();
            driverContext.CurrentPage = new HomePage(driverContext);
            driverContext.CurrentPage = driverContext.CurrentPage.As<HomePage>().ClickSignButton();
        }

        #endregion

        #region When

        [When(@"I Try to login with valid credentials (.*) and (.*)")]
        public void WhenITryToLoginWithTheCredentials(string username, string password)
        {
            driverContext.CurrentPage.As<LoginPage>().FillCredentials(username, password);
            driverContext.CurrentPage.As<LoginPage>().ClickSignInButton();
        }

        [When(@"I try to login with invalid credentials")]
        public void WhenITryToLoginWithInvalidCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driverContext.CurrentPage.As<LoginPage>().FillCredentials(data.Username, data.Password);
            driverContext.CurrentPage.As<LoginPage>().ClickSignInButton();
        }

        #endregion

        #region Then

        [Then(@"I should see the home page with user (.*) logged")]
        public void ThenIShouldSeeTheHomePageWithUserLogged(string userLogged)
        {
            var loggedUser = driverContext.CurrentPage.As<MenuPage>().GetLoggedUser();
            Assert.AreEqual(userLogged, loggedUser);
        }

        [Then(@"I should not login the application")]
        public void ThenIShouldNotLoginTheApplication()
        {
            bool result = driverContext.CurrentPage.As<MenuPage>().LoggedUserIsNotVisible();
            Assert.IsTrue(result);
        }

        [Then(@"I should see the message ""(.*)"" displayed")]
        public void ThenIShouldSeeMessage(string message)
        {
            string expectedMessage = driverContext.CurrentPage.As<LoginPage>().GetErrorMessageText();
            Assert.AreEqual(expectedMessage, message);
        }

        #endregion
    }
}
