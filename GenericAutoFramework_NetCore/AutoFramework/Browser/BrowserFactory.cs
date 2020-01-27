using System;
using AutoFramework.Helpers;
using OpenQA.Selenium;

namespace AutoFramework.Browser
{
    public class BrowserFactory
    {
        public IWebDriver OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            IWebDriver browser;
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    browser = new InternetExplorer().Init();
                    Logger.LogInfo("Internet Explorer Opened");
                    break;
                case BrowserType.Chrome:
                    browser = new Chrome().Init();
                    Logger.LogInfo("Chrome Opened");
                    break;
                case BrowserType.Firefox:
                    browser = new Firefox().Init();
                    Logger.LogInfo("Firefox Opened");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
            return browser;
        }
    }
}