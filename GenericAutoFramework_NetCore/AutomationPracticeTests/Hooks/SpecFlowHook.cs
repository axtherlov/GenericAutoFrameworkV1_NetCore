using AutoFramework.Base;
using AutoFramework.Config;
using BoDi;
using TechTalk.SpecFlow;

namespace AutomationPracticeTests.Hooks
{
    //[Binding]
    //public class DriverSetup
    //{
    //    private IObjectContainer _objectContainer;

    //    public DriverSetup(IObjectContainer objectContainer)
    //    {
    //        _objectContainer = objectContainer;
    //    }
    //}

    [Binding]
    public class SpecFlowHook : BaseHook
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

        public SpecFlowHook(DriverContext driverContext)
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
