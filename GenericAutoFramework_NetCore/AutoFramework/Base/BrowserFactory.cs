using System;
using AutoFramework.Browser;
using AutoFramework.Helpers;
using OpenQA.Selenium;

namespace AutoFramework.Base
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
}