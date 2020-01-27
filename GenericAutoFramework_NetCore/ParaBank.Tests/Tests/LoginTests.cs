using System;
using NUnit.Framework;
using ParaBank.Tests.Hooks;
using ParaBank.Tests.Pages;

namespace ParaBank.Tests.Tests
{
    [TestFixture]
    public class LoginTests : HookInitializer
    {
        
        [Test]
        public void LoginWithValidCredentials()
        {
            var random = new Random();
            var firstName = "Daniel";
            var lastName = "Terceros";

            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = "Test Address",
                City = "Test city",
                State = "Test state",
                ZipCode = "123456",
                Phone = "70516354",
                Ssn = "123456",
                Username = $"Danielt{random.Next(0,999999):D6}",
                Password = "Password1$"
            };
            string expectedMessage = "Your account was created successfully. You are now logged in.";

            driverContext.CurrentPage = new LoginPage(driverContext);
            driverContext.CurrentPage.As<LoginPage>().ClickRegisterLink();
            driverContext.CurrentPage.As<RegisterUserPage>().RegisterUser(user);
            string loggedUSer = driverContext.CurrentPage.As<MenuPage>().GetLoggedUserText();

            Assert.AreEqual($"Welcome {firstName} {lastName}", loggedUSer);
        }
    }
}
