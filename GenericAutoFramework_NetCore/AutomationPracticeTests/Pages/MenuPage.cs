using AutoFramework.Base;
using AutoFramework.Extensions;
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

        public LoginPage ClickSignButton()
        {
            _signInButton.Click();
            //return GetInstance<LoginPage>();
            return new LoginPage(driverContext);
        }

        public ContactUsPage ClickContactUsButton()
        {
            _contactUsLink.Click();
            //return GetInstance<ContactUsPage>();
            return new ContactUsPage(driverContext);
        }

        public AccountPage ClickAccountLink()
        {
            _accountLink.Click();
            //return GetInstance<AccountPage>();
            return new AccountPage(driverContext);
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
