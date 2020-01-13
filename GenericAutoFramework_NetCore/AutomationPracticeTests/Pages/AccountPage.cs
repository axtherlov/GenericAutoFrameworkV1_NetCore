using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class AccountPage : MenuPage
    {
        public AccountPage(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        //[FindsBy(How = How.XPath, Using = "//a[@title='Orders']")]
        private IWebElement _orderHistoryAndDetailsLink => parallelConfig.Driver.FindElement(By.XPath("//a[@title='Orders']"));

        //[FindsBy(How = How.XPath, Using = "//a[@title='Addresses']")]
        private IWebElement _myAddressesLink => parallelConfig.Driver.FindElement(By.XPath("//a[@title='Addresses']"));

        public OrderHistoryPage ClickOrderHistoryAndDetailsLink()
        {
            _orderHistoryAndDetailsLink.Click();
            //return GetInstance<OrderHistoryPage>();
            return new OrderHistoryPage(parallelConfig);
        }

        public MyAddresses ClickMyAddressesLink()
        {
            _myAddressesLink.Click();
            //return GetInstance<MyAddresses>();
            return new MyAddresses(parallelConfig);
        }
    }
}