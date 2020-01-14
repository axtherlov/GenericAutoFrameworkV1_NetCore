using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class LoginPage : MenuPage
    {
        private IWebElement _emailInput => driverContext.Driver.FindElement(By.Id("email"));
        private IWebElement _passwordInput => driverContext.Driver.FindElement(By.Id("passwd"));
        private IWebElement _submitLoginButton => driverContext.Driver.FindElement(By.Id("SubmitLogin"));

        public LoginPage(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        public void Login(string userName, string password)
        {
            _emailInput.SendKeys(userName);
            _passwordInput.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            _submitLoginButton.Click();
           // return GetInstance<HomePage>(parallelConfig);
           return new HomePage(driverContext);
        }
    }
}
