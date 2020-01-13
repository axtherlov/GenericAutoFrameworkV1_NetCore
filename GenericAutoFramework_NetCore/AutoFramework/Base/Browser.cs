using OpenQA.Selenium;

namespace AutoFramework.Base
{
    public class Browser
    {
        protected const string webDriverPath = @"C:\WebDrivers";
        private DriverContext _driverContext;

        public Browser(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        //public BrowserType Type { get; set; }
    }

    public enum BrowserType
    {
        InternetExplorer,
        Chrome,
        Firefox
    }
}
