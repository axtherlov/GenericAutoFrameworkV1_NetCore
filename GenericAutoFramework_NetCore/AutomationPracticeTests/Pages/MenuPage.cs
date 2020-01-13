using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public abstract class MenuPage : BasePage
    {
        protected MenuPage(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        //[FindsBy(How = How.XPath, Using = "//a[@title='Log in to your customer account']")]
        private IWebElement _signInButton => parallelConfig.Driver.FindByXPath("//a[@title='Log in to your customer account']");

        //[FindsBy(How = How.XPath, Using = "//a[@title='View my customer account']")]
        private IWebElement _accountLink => parallelConfig.Driver.FindElement(By.XPath("//a[@title='View my customer account']"));

        //[FindsBy(How = How.XPath, Using = "//a[@title='Contact Us']")]
        private IWebElement _contactUsLink => parallelConfig.Driver.FindElement(By.XPath("//a[@title='Contact Us']"));

        public LoginPage ClickSignButton()
        {
            _signInButton.Click();
            //return GetInstance<LoginPage>();
            return new LoginPage(parallelConfig);
        }

        public ContactUsPage ClickContactUsButton()
        {
            _contactUsLink.Click();
            //return GetInstance<ContactUsPage>();
            return new ContactUsPage(parallelConfig);
        }

        public AccountPage ClickAccountLink()
        {
            _accountLink.Click();
            //return GetInstance<AccountPage>();
            return new AccountPage(parallelConfig);
        }

        public string GetLoggerUser()
        {
            return _accountLink.GetLinkText();
        }

        public void CheckIfSignInExists()
        {
            _signInButton.AssertElementPresent();
        }
    }
}
