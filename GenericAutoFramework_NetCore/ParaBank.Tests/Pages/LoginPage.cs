using AutoFramework.Base;
using OpenQA.Selenium;

namespace ParaBank.Tests.Pages
{
    public class LoginPage : MenuPage
    {
        private IWebElement _usernameInput => driverContext.Driver.FindElement(By.Name("username"));
        private IWebElement _passwordInput => driverContext.Driver.FindElement(By.Name("password"));
        private IWebElement _loginInButton => driverContext.Driver.FindElement(By.XPath("//input[@value='Log In']"));

        public LoginPage(DriverContext driverContext)
            : base(driverContext)
        {
        }


        public HomePage Login(string username, string password)
        {
            _usernameInput.SendKeys(username);
            _passwordInput.SendKeys(password);
            _loginInButton.Click();
            return new HomePage(driverContext);
        }
    }
}
