using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using AutomationPracticeTests.Steps.Shared;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding, Scope(Feature = "Customer Service")]
    public sealed class ContactUsSteps : MenuSteps
    {
        public ContactUsSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        [Given(@"I navigated to ContactUs form")]
        public void GivenINavigateToContactUsForm()
        {
            GoToContactUsPage();
        }

        [When(@"I fill the contactUs form for customer service")]
        public void WhenIFillTheContactUsFormForCustomerService(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driverContext.CurrentPage.As<ContactUsPage>().FillContactForm(data.SubjectHeading, data.Email,
                data.OrderReference, data.Product, data.Message);
        }

        [Then(@"The customer service message should be sent")]
        public void ThenTheCustomerServiceMessageShouldBeSent()
        {
            driverContext.CurrentPage.As<ContactUsPage>().ClickSendButton();
        }
        
        [Then(@"I should see the message ""(.*)"" displayed")]
        public void ThenIShouldSeeMessageSendText(string expectedMessage)
        {
            var message = driverContext.CurrentPage.As<ContactUsPage>().GetMessageSendText();
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
