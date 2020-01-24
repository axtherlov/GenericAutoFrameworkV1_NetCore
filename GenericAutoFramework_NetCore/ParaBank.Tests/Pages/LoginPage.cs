using AutoFramework.Base;
using AutoFramework.Extensions.WebDriver;
using OpenQA.Selenium;

namespace ParaBank.Tests.Pages
{
    public class LoginPage : MenuPage
    {
        private IWebElement _usernameInput => driverContext.Driver.FindElement(By.Name("username"));
        private IWebElement _passwordInput => driverContext.Driver.FindElement(By.Name("password"));
        private IWebElement _loginInButton => driverContext.Driver.FindElement(By.XPath("//input[@value='Log In']"));
        private IWebElement _registerLink => driverContext.Driver.FindByXPath("//a[text()='Register']");

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

        public void ClickRegisterLink()
        {
            _registerLink.Click();
            driverContext.CurrentPage = new RegisterUserPage(driverContext);
        }
    }

    public class RegisterUserPage : MenuPage
    {
        private IWebElement _firstNameInput => driverContext.Driver.FindById("customer.firstName");
        private IWebElement _lastNameInput => driverContext.Driver.FindById("customer.lastName");
        private IWebElement _addressInput => driverContext.Driver.FindById("customer.address.street");
        private IWebElement _cityInput => driverContext.Driver.FindById("customer.address.city");
        private IWebElement _stateInput => driverContext.Driver.FindById("customer.address.state");
        private IWebElement _zipCodeInput => driverContext.Driver.FindById("customer.address.zipCode");
        private IWebElement _phoneInput => driverContext.Driver.FindById("customer.phoneNumber");
        private IWebElement _ssnInput => driverContext.Driver.FindById("customer.ssn");
        private IWebElement _usernameInput => driverContext.Driver.FindById("customer.username");
        private IWebElement _passwordInput => driverContext.Driver.FindById("customer.password");
        private IWebElement _confirmPasswordInput => driverContext.Driver.FindById("repeatedPassword");
        private IWebElement _registerButton => driverContext.Driver.FindByXPath("//input[@value='Register']");
        private IWebElement _userRegisteredMessage => driverContext.Driver.FindByXPath("//p[text()='Your account was created successfully. You are now logged in.']");

        public RegisterUserPage(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        public void RegisterUser(User user)
        {
            _firstNameInput.SendKeys(user.FirstName);
            _lastNameInput.SendKeys(user.LastName);
            _addressInput.SendKeys(user.Address);
            _cityInput.SendKeys(user.City);
            _stateInput.SendKeys(user.State);
            _zipCodeInput.SendKeys(user.ZipCode);
            _phoneInput.SendKeys(user.Phone);
            _ssnInput.SendKeys(user.Ssn);
            _usernameInput.SendKeys(user.Username);
            _passwordInput.SendKeys(user.Password);
            _confirmPasswordInput.SendKeys(user.Password);

            _registerButton.Click();
        }

        public string GetUserRegisteredMessage()
        {
            return _userRegisteredMessage.Text;
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Ssn { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
