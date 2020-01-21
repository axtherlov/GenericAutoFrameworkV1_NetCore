using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutoFramework.Browser
{
    public class InternetExplorer : IBrowser
    {
        public InternetExplorerDriver Init()
        {
            SetupDriver();
            return new InternetExplorerDriver(GetOptions());
        }

        public void SetupDriver() => new DriverManager().SetUpDriver(new InternetExplorerConfig());

        private InternetExplorerOptions GetOptions()
        {
            var options = new InternetExplorerOptions();
            return options;
        }
    }
}