using OpenQA.Selenium;

namespace AutoFramework.Base
{
    public class DriverContext
    {
        public IWebDriver Driver { get; set; }
        
        public BasePage CurrentPage { get; set; }

        public void GoToUrl(string url)
        {
            Driver.Url = url;
        }
    }
}
