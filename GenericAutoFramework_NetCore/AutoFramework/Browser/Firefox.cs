using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutoFramework.Browser
{
    public class Firefox : IBrowser
    {
        public FirefoxDriver Init()
        {
            SetupDriverManager();
            return new FirefoxDriver(GetOptions());
        }

        public void SetupDriverManager() => new DriverManager().SetUpDriver(new FirefoxConfig());

        private FirefoxOptions GetOptions()
        {
            //var profile = new FirefoxProfile();
            //var profileManager = new FirefoxProfileManager();
            //profile =  profileManager.GetProfile("Default");
            var options = new FirefoxOptions();
            options.AddArgument("--incognito");
            return options;
        }
    }
}