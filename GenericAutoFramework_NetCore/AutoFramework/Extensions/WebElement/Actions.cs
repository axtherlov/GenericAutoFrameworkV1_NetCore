using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoFramework.Extensions.WebElement
{
    public static class Actions
    {
        public static string GetSelectedDropDown(this IWebElement element)
        {
            var select = new SelectElement(element);
            return select.AllSelectedOptions.First().ToString();
        }
        
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            var select = new SelectElement(element);
            return select.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        public static void SelectDropDownList(this IWebElement element, string value)
        {
            var select = new SelectElement(element);
            select.SelectByText(value);
        }

        public static void Hover(this IWebElement element)
        {
            //var actions = new Actions(DriverContext.Driver);
            //actions.MoveToElement(element).Perform();
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if(!IsElementPresent(element))
                throw new Exception("Element not present exception");
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool isPresent = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
