using System;
using AutoFramework.Base;
using NUnit.Framework;
using ParaBank.Tests.Hooks;
using ParaBank.Tests.Pages;

namespace ParaBank.Tests.Tests
{
    [TestFixture]
    public class RegisterUserTests : HookInitializer
    {
        protected RegisterUserTests(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        [Test]
        public void RegisterUserWithValidValues()
        {
            var random = new Random();
            var user = new User()
            {
                FirstName = "Daniel",
                LastName = "Terceros",
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
            string registeredMessage = driverContext.CurrentPage.As<RegisterUserPage>().GetUserRegisteredMessage();
            
            Assert.AreEqual(expectedMessage, registeredMessage);
        }
    }
}
