using AutoFramework.Base;
using NUnit.Framework;
using ParaBank.Tests.Hooks;
using ParaBank.Tests.Pages;

namespace ParaBank.Tests.Tests
{
    //[TestFixture(typeof(DriverContext))]
    [TestFixture]
    public class LoginTests : HookInitializer
    {
        protected LoginTests(DriverContext driverContext) 
            : base(driverContext)
        {
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            driverContext.CurrentPage = new LoginPage(driverContext);
            driverContext.CurrentPage.As<LoginPage>().Login("testUser", "Password1$");

            string loggedUSer = driverContext.CurrentPage.As<MenuPage>().GetLoggedUserText();

            Assert.AreEqual("Daniel T", loggedUSer);
        }

        
    }
}
