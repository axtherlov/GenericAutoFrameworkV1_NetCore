﻿using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public abstract class MenuPage : BasePage
    {
        private IWebElement _signInButton => driverContext.Driver.FindByXPath("//a[@title='Log in to your customer account']");
        private IWebElement _accountLink => driverContext.Driver.FindElement(By.XPath("//a[@title='View my customer account']"));
        private IWebElement _contactUsLink => driverContext.Driver.FindElement(By.XPath("//a[@title='Contact Us']"));

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
