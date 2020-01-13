using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutomationPracticeTests.Pages
{
    public class LoginPage : MenuPage
    {
        public LoginPage(ParallelConfig parallelConfig) 
            : base(parallelConfig)
        {
        }

        //[FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailInput => parallelConfig.Driver.FindElement(By.Id("email"));

        //[FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement _passwordInput => parallelConfig.Driver.FindElement(By.Id("passwd"));

        //[FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement _submitLoginButton => parallelConfig.Driver.FindElement(By.Id("SubmitLogin"));

        public void Login(string userName, string password)
        {
            _emailInput.SendKeys(userName);
            _passwordInput.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            _submitLoginButton.Click();
           // return GetInstance<HomePage>(parallelConfig);
           return new HomePage(parallelConfig);
        }
    }
}
