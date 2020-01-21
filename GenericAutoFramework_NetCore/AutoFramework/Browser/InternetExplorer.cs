using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutoFramework.Browser
{
    public class InternetExplorer : IBrowser
    {
        public InternetExplorerDriver Init()
        {
            SetupDriverManager();
            return new InternetExplorerDriver(GetOptions());
        }

        public void SetupDriverManager() => new DriverManager().SetUpDriver(new InternetExplorerConfig());

        private InternetExplorerOptions GetOptions()
        {
            var options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true
            };
            return options;
        }
    }
}