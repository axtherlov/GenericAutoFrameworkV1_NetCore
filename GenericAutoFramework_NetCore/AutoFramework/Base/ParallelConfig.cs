using OpenQA.Selenium;

namespace AutoFramework.Base
{
    public class ParallelConfig
    {
        //public RemoteWebDriver Driver { get; set; }
        public IWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
    }
}