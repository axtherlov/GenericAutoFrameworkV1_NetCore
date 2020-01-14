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
        
        public OrderHistoryPage ClickOrderHistoryAndDetailsLink()
        {
            _orderHistoryAndDetailsLink.Click();
            //return GetInstance<OrderHistoryPage>(driverContext);
            return new OrderHistoryPage(driverContext);
        }

        public MyAddresses ClickMyAddressesLink()
        {
            _myAddressesLink.Click();
            //return GetInstance<MyAddresses>();
            return new MyAddresses(driverContext);
        }
    }
}