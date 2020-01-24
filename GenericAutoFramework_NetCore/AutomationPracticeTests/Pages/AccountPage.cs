using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class AccountPage : MenuPage
    {
        private IWebElement _orderHistoryAndDetailsLink => driverContext.Driver.FindElement(By.XPath("//a[@title='Orders']"));
        private IWebElement _myAddressesLink => driverContext.Driver.FindElement(By.XPath("//a[@title='Addresses']"));

        public AccountPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void ClickOrderHistoryAndDetailsLink()
        {
            _orderHistoryAndDetailsLink.Click();
            driverContext.CurrentPage = new OrderHistoryPage(driverContext);
        }

        public void ClickMyAddressesLink()
        {
            _myAddressesLink.Click();
            driverContext.CurrentPage = new MyAddresses(driverContext);
        }
    }
}