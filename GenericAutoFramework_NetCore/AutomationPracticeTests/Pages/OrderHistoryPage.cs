using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class OrderHistoryPage : MenuPage
    {
        public OrderHistoryPage(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        //[FindsBy(How = How.Id, Using = "order-list")]
        private IWebElement _orderListTable => parallelConfig.Driver.FindElement(By.Id("order-list"));

        public IWebElement GetOrderHistoryList()
        {
            return _orderListTable;
        }
    }
}