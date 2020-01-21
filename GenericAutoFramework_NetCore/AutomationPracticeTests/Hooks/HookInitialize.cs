using AutoFramework.Base;
using AutoFramework.Config;
using TechTalk.SpecFlow;

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

        public HookInitialize(DriverContext driverContext, FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(driverContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            SetupFrameworkSettings(new ConfigJsonReader());
            SetExtentReportSettings();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitializeBrowser();
            SetCurrentFeatureName(_featureContext);
            SetCurrentScenarioName(_scenarioContext);
        }

        [AfterStep]
        public void AfterStep()
        {
            SetStepResultToReport(_scenarioContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CloseBrowser();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            FlushReport();
        }
    }
}
