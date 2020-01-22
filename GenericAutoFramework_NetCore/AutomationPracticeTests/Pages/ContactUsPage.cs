using AutoFramework.Base;
using AutoFramework.Extensions.WebDriver;
using AutoFramework.Extensions.WebElement;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class ContactUsPage : MenuPage
    {
        private const string MESSAGE_SEND_TEXT= "//p[@class='alert alert-success']";
        private IWebElement _subjectHeadingDropdown => driverContext.Driver.WaitToBeClickable(By.Id("id_contact1"));
        private IWebElement _emailInput => driverContext.Driver.FindElement(By.Id("email"));
        private IWebElement _orderReferenceDropDown => driverContext.Driver.FindElement(By.Name("id_order"));
        private IWebElement _productDropDown => driverContext.Driver.FindElement(By.Name("id_product"));
        private IWebElement _messageInput => driverContext.Driver.FindElement(By.Id("message"));
        private IWebElement _sendButton => driverContext.Driver.FindElement(By.Id("submitMessage"));
        private IWebElement _messageSendText => driverContext.Driver.FindByXPath(MESSAGE_SEND_TEXT);
        private IWebElement _messageSentText2 => driverContext.Driver.WaitToExists(By.XPath(MESSAGE_SEND_TEXT));

        public ContactUsPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void FillContactForm(string subjectHeading, string email, string orderReference, string product, string message)
        {
            _subjectHeadingDropdown.SelectDropDownList(subjectHeading);
            _emailInput.Clear();
            _emailInput.SendKeys(email);
            _orderReferenceDropDown.SelectDropDownList(orderReference);
            _productDropDown.SelectDropDownList(product);
            _messageInput.SendKeys(message);
        }

        public void ClickSendButton()
        {
            _sendButton.Click();
        }

        public string GetMessageSendText()
        {
            return _messageSentText2.Text;
        }
    }
}