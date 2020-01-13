using AutoFramework.Base;
using AutoFramework.Config;
using AutoFramework.Helpers;
using AutomationPracticeTests.Pages;
using TechTalk.SpecFlow;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    public class ExtendedSteps : BaseStep
    {
        public ExtendedSteps(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        public virtual void NavigateSite()
        {
            //parallelConfig..Browser.GoToUrl(Settings.AUT);
            parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            LogHelpers.Write($"Navigated to {Settings.AUT}");
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateSite();
            //CurrentPage = GetInstance<HomePage>();
            parallelConfig.CurrentPage = new HomePage(parallelConfig);
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if(linkName == "login")
                parallelConfig.CurrentPage = parallelConfig.CurrentPage.As<HomePage>().ClickSignButton();
            else if(linkName== "ContactUs")
                parallelConfig.CurrentPage = parallelConfig.CurrentPage.As<HomePage>().ClickContactUsButton();
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if(buttonName=="login")
                parallelConfig.CurrentPage = parallelConfig.CurrentPage.As<LoginPage>().ClickLoginButton();
            if (buttonName == "Send")
                parallelConfig.CurrentPage.As<ContactUsPage>().ClickSendButton();
        }
    }
}
