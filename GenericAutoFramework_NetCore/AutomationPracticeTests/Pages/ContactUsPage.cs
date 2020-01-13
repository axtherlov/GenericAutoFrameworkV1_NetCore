using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class ContactUsPage : MenuPage
    {
        public ContactUsPage(ParallelConfig parallelConfig)
            : base(parallelConfig)
        {
        }
        //[FindsBy(How = How.Id, Using = "id_contact")]
        private IWebElement _subjectHeadingDropdown => parallelConfig.Driver.FindElement(By.Id("id_contact"));

        //[FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailInput => parallelConfig.Driver.FindElement(By.Id("email"));

        //[FindsBy(How = How.Name, Using = "id_order")]
        private IWebElement _orderReferenceDropDown => parallelConfig.Driver.FindElement(By.Id("id_order"));
        
        //[FindsBy(How = How.Name, Using = "id_product")]
        private IWebElement _productDropDown => parallelConfig.Driver.FindElement(By.Id("id_product"));

        //FindsBy(How = How.Id, Using = "message")]
        private IWebElement _messageInput => parallelConfig.Driver.FindElement(By.Id("message"));

        //[FindsBy(How = How.Id, Using = "submitMessage")]
        private IWebElement _sendButton => parallelConfig.Driver.FindElement(By.Id("submitMessage"));

        public void FillContactForm(string subjectHeading, string email, string orderReference, string product, string message)
        {
            _subjectHeadingDropdown.SelectDropDownList(subjectHeading);
            _emailInput.Clear();
            _emailInput.SendKeys(email);
            _orderReferenceDropDown.SelectDropDownList(orderReference);
            _productDropDown.SelectDropDownList(product);
            _messageInput.SendKeys(message);
        }

        internal void ClickSendButton()
        {
            _sendButton.Click();
        }
    }
}