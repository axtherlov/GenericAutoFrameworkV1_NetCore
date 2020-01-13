using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutoFramework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(x =>
            {
                string state = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, timeOut:20);
        }

        public static void WaitForCondition<T>(this T obj, Func<T,bool> condition, int timeOut)
        {
            Func<T, bool> execute = 
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        public static IWebElement FindById(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElementById(element).IsElementPresent())
                    return remoteWebDriver.FindElementById(element);
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException($"Error: element not found {element}");
            }
            return null;
        }

        public static IWebElement FindByXPath(this IWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElement(By.XPath(element)).IsElementPresent())
                    return remoteWebDriver.FindElement(By.XPath(element));
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException($"Error: element not found {element}");
            }
            return null;
        }
    }
}
