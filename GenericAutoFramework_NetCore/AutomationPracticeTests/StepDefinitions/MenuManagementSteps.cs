using TechTalk.SpecFlow;

namespace AutomationPracticeTests.Steps
{   
    [Binding]
    public class MenuManagementSteps
    {
        [Given(@"I have a menu item with name ""(.*)"" and price ([$]*)([0-9]+)")]
        public void GivenIHaveAMenuItemWithNameAndPrice(string menuItem, int currency, string price)
        {
            ScenarioContext.StepIsPending();
        }
        
        [When(@"I add that menu item")]
        public void WhenIAddThatMenuItem()
        {
            ScenarioContext.StepIsPending();
        }
        
        [Then(@"Menu item with name ""(.*)"" should be added")]
        public void ThenMenuItemWithNameShouldBeAdded(string p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}
