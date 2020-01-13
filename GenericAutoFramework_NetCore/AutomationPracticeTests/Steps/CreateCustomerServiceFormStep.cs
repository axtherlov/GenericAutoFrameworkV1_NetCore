using AutoFramework.Base;
using AutomationPracticeTests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeTests.Steps
{
    [Binding]
    class CreateCustomerServiceFormStep : BaseStep
    {
        public CreateCustomerServiceFormStep(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        [Then(@"I Fill the contactUs form for customer service")]
        public void ThenIFillTheContactUsFormForCustomerService(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            parallelConfig.CurrentPage.As<ContactUsPage>().FillContactForm(data.SubjectHeading,  
                data.EmailAddress, data.OrderReference, data.Product, data.Message);
        }

      
    }
}
