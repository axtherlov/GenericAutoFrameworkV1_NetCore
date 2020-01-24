using AutoFramework.Base;
using AutoFramework.Config;
using TechTalk.SpecFlow;

namespace AutomationPracticeTests.Hooks
{
    [Binding]
    public class HookInitialize : BaseHook
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

        public HookInitialize(DriverContext driverContext)
            : base(driverContext)
        {
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            SetupFrameworkSettings(new ConfigJsonReader());
            SetExtentReportSettings();
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            InitializeBrowser();
            SetCurrentFeatureName(featureContext);
            SetCurrentScenarioName(scenarioContext);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            SetStepResultToReport(scenarioContext);
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
