using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutoFramework.Extensions.WebDriver
{
    public static class WebDriverWaitExtensions
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

        public static IWebElement WaitToExists(this IWebDriver webDriver, By by, int timeout = 3)
        {
            IWebElement foundElement = null;
            try
            {
                foundElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout))
                    .Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return foundElement;
        }

        public static IWebElement WaitToBeClickable(this IWebDriver webDriver, By by, int timeout = 3)
        {
            IWebElement foundElement = null;
            try
            {
                foundElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout))
                    .Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (TimeoutException e)
            {
                Console.WriteLine($"Exception: {e}");
            }

            return foundElement;
        }
    }
}
