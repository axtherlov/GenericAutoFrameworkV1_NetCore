using System;
using AutoFramework.Config;
using AutoFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace AutoFramework.Base
{
    public abstract class TestInitializeHook : Steps
    {
        private readonly DriverContext _driverContext;

        protected TestInitializeHook(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        protected void InitializeSettings()
        {
            ConfigReader.SetFrameworkSettings();
            LogHelpers.CreateLogFile();
            OpenBrowser();
        }

        private void OpenBrowser()
        {
            _driverContext.Driver = new BrowserFactory().OpenBrowser(Settings.BrowserType);
        }

        protected void CloseBrowser()
        {
            _driverContext.Driver.Close();
            _driverContext.Driver.Quit();
        }

        public virtual void NavigateSite()
        {
            // DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write($"Navigated to {Settings.AUT}");
        }
    }

    public class BrowserFactory
    {
        public IWebDriver OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            IWebDriver browser = null;
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    browser = new InternetExplorer().Init();
                    LogHelpers.Write("Internet Explorer Opened");
                    break;
                case BrowserType.Chrome:
                    browser = new Chrome().Init();
                    LogHelpers.Write("Chrome Opened");
                    break;
                case BrowserType.Firefox:
                    browser = new Firefox().Init();
                    LogHelpers.Write("Firefox Opened");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
            return browser;
        }
    }

    public abstract class Browser
    {
        protected const string WEB_DRIVERS_PATH = @"C:\WebDrivers";
    }

    public class InternetExplorer : Browser
    {
        public InternetExplorerDriver Init()
        {
            return new InternetExplorerDriver(WEB_DRIVERS_PATH, GetOptions());
        }

        private InternetExplorerOptions GetOptions()
        {
            var options = new InternetExplorerOptions();
            return options;
        }
    }

    public class Firefox : Browser
    {
        public FirefoxDriver Init()
        {
            return new FirefoxDriver(WEB_DRIVERS_PATH, GetOptions());
        }

        private FirefoxOptions GetOptions()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--incognito");
            return options;
        }
    }

    public class Chrome : Browser
    {
        public ChromeDriver Init()
        {
            return new ChromeDriver(WEB_DRIVERS_PATH, GetOptions());
        }

        private ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            return options;
        }
    }

}
