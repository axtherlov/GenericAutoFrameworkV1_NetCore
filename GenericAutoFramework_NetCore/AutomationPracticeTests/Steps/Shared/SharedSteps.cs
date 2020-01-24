using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using TechTalk.SpecFlow;

namespace AutomationPracticeTests.Steps.Shared
{
    [Binding]
    public class SharedSteps : MenuSteps
    {
        public SharedSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        [Given(@"I am logged in the application with any user")]
        public void GivenIAmLoggedInTheApplication()
        {
            NavigateToInitialSite();
            GoToLoginPage();
            driverContext.CurrentPage.As<LoginPage>().Login("daniel.terceros@test.com", 
                                                            "Password1$");
        }
    }
}
