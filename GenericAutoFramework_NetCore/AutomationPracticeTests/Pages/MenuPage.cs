using AutoFramework.Base;
using AutoFramework.Extensions.WebDriver;
using AutoFramework.Extensions.WebElement;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPracticeTests.Pages
{
    public abstract class MenuPage : BasePage
    {
        private const string ACCOUNT_LINK = "//a[@title='View my customer account']";
        private const string SIGN_IN_BUTTON = "//a[@title='Log in to your customer account']";
        private const string CONTACT_US_LINK = "//a[@title='Contact Us']";

        private IWebElement _signInButton => driverContext.Driver.FindByXPath(SIGN_IN_BUTTON);
        private IWebElement _accountLink => driverContext.Driver.FindByXPath(ACCOUNT_LINK);
        private IWebElement _contactUsLink => driverContext.Driver.FindByXPath(CONTACT_US_LINK);

        protected MenuPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void ClickSignButton()
        {
            _signInButton.Click();
            driverContext.CurrentPage = new LoginPage(driverContext);
        }

        public void ClickContactUsButton()
        {
            _contactUsLink.Click();
            driverContext.CurrentPage = new ContactUsPage(driverContext);
        }

        public void ClickAccountLink()
        {
            _accountLink.Click();
            driverContext.CurrentPage = new AccountPage(driverContext);
        }

        public string GetLoggedUser()
        {
            return _accountLink.GetLinkText();
        }

        public bool LoggedUserIsNotVisible()
        {
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(ACCOUNT_LINK)));
        }
    }
}
