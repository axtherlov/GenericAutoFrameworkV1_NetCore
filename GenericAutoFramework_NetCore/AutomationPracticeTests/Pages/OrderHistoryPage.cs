using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class OrderHistoryPage : MenuPage
    {
        private IWebElement _orderListTable => driverContext.Driver.FindElement(By.Id("order-list"));

        public OrderHistoryPage(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        public IWebElement GetOrderHistoryList()
        {
            return _orderListTable;
        }
    }
}