using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    public sealed class LoginSteps : BaseStep
    {
        public LoginSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        [Given(@"I see the application opened")]
        public void GivenISeeTheApplicationOpened()
        {
            driverContext.CurrentPage.As<HomePage>().CheckIfSignInExists();
        }
        
        [When(@"I enter the username and password")]
        public void WhenIEnterTheUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driverContext.CurrentPage.As<LoginPage>().Login(data.Username, data.Password);
        }
        
        [Then(@"I should see the home page with user (.*) logged")]
        public void ThenIShouldSeeTheHomePageWithUserLogged(string userLogged)
        {
            var loggedUser = driverContext.CurrentPage.As<HomePage>().GetLoggerUser();
            Assert.AreEqual(userLogged, loggedUser);
        }
    }
}
