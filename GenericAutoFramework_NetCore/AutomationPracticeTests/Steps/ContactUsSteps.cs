using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    public sealed class ContactUsSteps : BaseStep
    {
        public ContactUsSteps(DriverContext driverContext)
            : base(driverContext)
        {
        }

        //[Then(@"I fill the contactUs form for customer service")]
        //public void ThenIShouldSeeMessageSendText(Table table)
        //{
        //    dynamic data = table.CreateDynamicInstance();
        //    driverContext.CurrentPage.As<ContactUsPage>().FillContactForm(data.SubjectHeading, data.Email,
        //        data.OrderReference, data.Product, data.Message);
        //}

        [When(@"I fill the contactUs form for customer service")]
        public void WhenIFillTheContactUsFormForCustomerService(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driverContext.CurrentPage.As<ContactUsPage>().FillContactForm(data.SubjectHeading, data.Email,
                data.OrderReference, data.Product, data.Message);
        }


        
        [Then(@"I should see the message (.*) displayed")]
        public void ThenIShouldSeeMessageSendText(string expectedMessage)
        {
            var message = driverContext.CurrentPage.As<ContactUsPage>().GetMessageSendText();
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
