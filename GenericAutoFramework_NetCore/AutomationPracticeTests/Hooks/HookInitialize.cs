using AutoFramework.Base;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

namespace AutomationPracticeTests.Hooks
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        /*  [BeforeTestRun]
            [BeforeFeature]
            [BeforeScenario]
            [BeforeScenarioBlock]
            [BeforeStep]
            [AfterStep]
            [AfterScenarioBlock]
            [AfterScenario]
            [AfterFeature]
            [AfterTestRun] */

        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName; // should not be static otherwise scenario steps will overstep each other in case of parallel testing

        private static ExtentReport extentReport;
        private static ExtentTest featureName;
        
        private static ExtentKlovReporter klov;

        public HookInitialize(DriverContext driverContext, FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(driverContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void TestInitialize()
        {
            //Settings.AppConnectionString = Settings.AppConnectionString.DBConnect(Settings.AppConnectionString);

            var htmlreporter = new ExtentHtmlReporter(@"C:\Reports\ExtentReport\ExtentReport.html");
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
            extentReport = new ExtentReport();
            klov = new ExtentKlovReporter();
            extentReport.AttachReporter(htmlreporter);
        }

        //[BeforeFeature]
        //public void BeforeFeature()
        //{
        //    featureName = extentReport.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        //}

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitializeSettings();
            featureName = extentReport.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

    

        [AfterTestRun]
        public static void TestEnd()
        {
            extentReport.Flush();
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step definition pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail("Step definition pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail("Step definition pending");
            }
            //var featureTitle = FeatureContext.Current.FeatureInfo.Title;
            //var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            CloseBrowser();
            extentReport.Flush(); //create report
        }
    }
}
