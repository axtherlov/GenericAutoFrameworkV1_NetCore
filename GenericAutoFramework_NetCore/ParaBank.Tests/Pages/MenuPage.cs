using AutoFramework.Base;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ParaBank.Tests.Pages
{
    public class MenuPage : BasePage
    {
        private const string USERNAME_TEXT = "//p[@class='smallText']";
        private IWebElement _usernameText => driverContext.Driver.FindElement(By.XPath(USERNAME_TEXT));

        protected MenuPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public string GetLoggedUserText()
        {
            var result = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(USERNAME_TEXT)));
            return _usernameText.Text;
        }
    }
}
