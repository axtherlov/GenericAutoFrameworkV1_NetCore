using System;
using AutoFramework.Config;
using AutoFramework.Helpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

namespace AutoFramework.Base
{
    public abstract class TestInitializeHook// : Steps
    {
        private const string SCREENSHOT_PATH = @"C:\Reports\Screenshots\";

        private static ExtentReport _extentReport;
        private static ExtentTest _featureName;
        private static ExtentKlovReporter _klov;
        
        private readonly DriverContext _driverContext;
        private ExtentTest _currentScenarioName; // should not be static otherwise scenario steps will overstep each other in case of parallel testing

        protected TestInitializeHook(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        protected void SetFrameworkSettings()
        {
            ConfigReader.SetFrameworkSettings();
            LogHelpers.CreateLogFile();
        }

        protected static void SetExtentReportSettings()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Reports\ExtentReport\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
            _extentReport = new ExtentReport();
            _klov = new ExtentKlovReporter();
            _extentReport.AttachReporter(htmlReporter);
        }

        protected static void FlushReport()
        {
            _extentReport.Flush();
        }

        protected void InitializeBrowser(int implicitWaitTimeout = 10, int pageLoadTimeout = 30)
        {
            _driverContext.Driver = new BrowserFactory().OpenBrowser(Settings.BrowserType);
            _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTimeout);
            _driverContext.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
        }

        protected void CloseBrowser()
        {
            _driverContext.Driver.Close();
            _driverContext.Driver.Quit();
        }

        protected void SetCurrentFeatureName(FeatureContext featureContext)
        {
            _featureName = _extentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        protected void SetCurrentScenarioName(ScenarioContext scenarioContext)
        {
            _currentScenarioName = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        protected void SetStepResultToReport(ScenarioContext scenarioContext)
        {
            ScenarioBlock scenarioBlock = scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.None:
                    break;
                case ScenarioBlock.Given:
                    CreateNode<Given>(scenarioContext, _currentScenarioName);
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>(scenarioContext, _currentScenarioName);
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>(scenarioContext, _currentScenarioName);
                    break;
            }
        }

        #region Helpers

        private void CreateNode<T>(ScenarioContext scenarioContext, ExtentTest currentScenarioName) where T : IGherkinFormatterModel
        {
            string stepInfo = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError != null)
            {
                string errorMessage = scenarioContext.TestError.Message;
                string stackTrace = scenarioContext.TestError.StackTrace;
                string fileName = $"{SCREENSHOT_PATH}{DateTime.UtcNow:yyyy-MM-dd hh-mm-ss} { scenarioContext.ScenarioInfo.Title}.png";

               // TakeScreenShot(fileName);
               currentScenarioName.CreateNode<T>(stepInfo)
                   .Fail($"Error: {errorMessage}{Environment.NewLine + Environment.NewLine}StackTrace: {stackTrace}");
               //.AddScreenCaptureFromPath(fileName);
            }
            else if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                currentScenarioName.CreateNode<T>(stepInfo)
                    .Skip("Step definition pending");
            }
            else
            {
                currentScenarioName.CreateNode<T>(stepInfo);
            }
        }

        private void TakeScreenShot(string fileName)
        {
            var screenShot = _driverContext.Driver.TakeScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            //Logger.Info($" ScreenShot Taken : {filename}");
        }

        #endregion
    }

    public class BrowserFactory
    {
        public IWebDriver OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            IWebDriver browser;
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    browser = new InternetExplorer().Init();
                    LogHelpers.Write("Internet Explorer Opened");
                    break;
                case BrowserType.Chrome:
                    browser = new Chrome().Init();
                    LogHelpers.Write("Chrome Opened");
                    break;
                case BrowserType.Firefox:
                    browser = new Firefox().Init();
                    LogHelpers.Write("Firefox Opened");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
            return browser;
        }
    }

    public interface IBrowser
    {
        void SetupDriver();
    }

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

    public class Chrome : IBrowser
    {
        public ChromeDriver Init()
        {
            SetupDriver();
            return new ChromeDriver(GetOptions());
        }

        public void SetupDriver() => new DriverManager().SetUpDriver(new ChromeConfig());

        private ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            return options;
        }
    }

}
