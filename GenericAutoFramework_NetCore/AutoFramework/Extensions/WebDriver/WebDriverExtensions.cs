using System;
using AutoFramework.Extensions.WebElement;
using OpenQA.Selenium;

namespace AutoFramework.Extensions.WebDriver
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindById(this IWebDriver webDriver, string element)
        {
            try
            {
                if (webDriver.FindElement(By.Id(element)).IsElementPresent())
                    return webDriver.FindElement(By.Id(element));
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException($"Error: element not found {element}");
            }
            return null;
        }

        public static IWebElement FindByXPath(this IWebDriver webDriver, string element)
        {
            try
            {
                if (webDriver.FindElement(By.XPath(element)).IsElementPresent())
                    return webDriver.FindElement(By.XPath(element));
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException($"Error: element not found {element}");
            }
            return null;
        }
    }
}
