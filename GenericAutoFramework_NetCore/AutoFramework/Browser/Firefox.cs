using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutoFramework.Browser
{
    public class Firefox : IBrowser
    {
        public FirefoxDriver Init()
        {
            SetupDriver();
            return new FirefoxDriver(GetOptions());
        }

        public void SetupDriver() => new DriverManager().SetUpDriver(new FirefoxConfig());

        private FirefoxOptions GetOptions()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--incognito");
            return options;
        }
    }
}