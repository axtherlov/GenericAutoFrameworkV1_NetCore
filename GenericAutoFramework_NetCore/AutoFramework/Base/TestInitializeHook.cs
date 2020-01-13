using System;
using AutoFramework.Config;
using AutoFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace AutoFramework.Base
{
    public abstract class TestInitializeHook : Steps
    {
        private readonly ParallelConfig _parallelConfig;
        private const string WEB_DRIVERS_PATH = @"C:\WebDrivers";

        protected TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        protected void InitializeSettings()
        {
            ConfigReader.SetFrameworkSettings();
            LogHelpers.CreateLogFile();
            OpenBrowser(Settings.BrowserType);
        }
        
        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    var ieOptions = new InternetExplorerOptions();
                    _parallelConfig.Driver = new InternetExplorerDriver(WEB_DRIVERS_PATH, ieOptions);
                    break;
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--incognito");
                    _parallelConfig.Driver = new ChromeDriver(WEB_DRIVERS_PATH, chromeOptions);
                    break;
                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--incognito");
                    _parallelConfig.Driver = new FirefoxDriver(WEB_DRIVERS_PATH, firefoxOptions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
            
            LogHelpers.Write("Opened the browser");
        }

        public virtual void NavigateSite()
        {
           // DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write($"Navigated to {Settings.AUT}");
        }
    }

    public class Chrome : Browser
    {
        private readonly ParallelConfig _parallelConfig;

           public Chrome(DriverContext driverContext) 
               : base(driverContext)
           {
               _parallelConfig.Driver = new ChromeDriver(webDriverPath, GetOptions());
           }

           public ChromeOptions GetOptions()
           {
               var options = new ChromeOptions();
               options.AddArgument("--incognito");
               return options;
           }
    }
    
}
