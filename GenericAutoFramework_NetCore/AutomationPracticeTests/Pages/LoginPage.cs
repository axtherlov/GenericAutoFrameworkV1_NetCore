using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class LoginPage : MenuPage
    {
        private IWebElement _emailInput => driverContext.Driver.FindElement(By.Id("email"));
        private IWebElement _passwordInput => driverContext.Driver.FindElement(By.Id("passwd"));
        private IWebElement _submitLoginButton => driverContext.Driver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _errorText => driverContext.Driver.FindElement(By.XPath("//div[@class='alert alert-danger']/ol/li"));

        public LoginPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void FillCredentials(string userName, string password)
        {
            _emailInput.SendKeys(userName);
            _passwordInput.SendKeys(password);
        }

        public void Login(string userName, string password)
        {
            FillCredentials(userName, password);
            _submitLoginButton.Click();
            driverContext.CurrentPage = new HomePage(driverContext);
        }

        public void FailedLogin(string userName, string password)
        {
            FillCredentials(userName, password);
            _submitLoginButton.Click();
        }

        public string GetErrorMessageText()
        {
            return _errorText.Text;
        }
    }
}
