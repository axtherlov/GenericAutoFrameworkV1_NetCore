using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        public LoginSteps(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        [Given(@"I see the application opened")]
        public void GivenISeeTheApplicationOpened()
        {
            parallelConfig.CurrentPage.As<HomePage>().CheckIfSignInExists();
        }
        
        //[Then(@"I click (.*) link")]
        //public void ThenIClickLink(string linkName)
        //{
        //    if(linkName == "Login")
        //        CurrentPage = CurrentPage.As<HomePage>().ClickSignButton();
        //    else if(linkName== "ContactUs")
        //        CurrentPage = CurrentPage.As<HomePage>().ClickContactUsButton();
        //}
        
        [When(@"I enter the username and password")]
        public void WhenIEnterTheUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            parallelConfig.CurrentPage.As<LoginPage>().Login(data.Username, data.Password);
        }
        
        //[Then(@"I click (.*) button")]
        //public void ThenIClickButton(string buttonName)
        //{
        //    if(buttonName=="Login")
        //        CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
        //    if (buttonName == "Send")
        //        CurrentPage.As<ContactUsPage>().ClickSendButton();
        //}
        
        [Then(@"I should see the home page with user logged")]
        public void ThenIShouldSeeTheHomePageWithUserLogged()
        {
            var loggedUser = parallelConfig.CurrentPage.As<HomePage>().GetLoggerUser();
            //if(loggedUser.Contains("daniel"))
        }

       
    }
}
