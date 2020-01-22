using AutoFramework.Base;
using NUnit.Framework;
using ParaBank.Tests.Hooks;
using ParaBank.Tests.Pages;

namespace ParaBank.Tests.Tests
{
    //[TestFixture(DriverContext)]
    public class LoginTests : HookInitializer
    {
        private DriverContext driverContext;
        public LoginTests(DriverContext driverContext)
            : base(driverContext)
        {
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            //driverContext.CurrentPage = new LoginPage(driverContext);
            //driverContext.CurrentPage.As<LoginPage>().Login("danielt", "Password1$");

            //string loggedUSer = driverContext.CurrentPage.As<MenuPage>().GetLoggedUserText();

            //Assert.AreEqual("Daniel T", loggedUSer);
        }
    }
}
