using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AppiumAndroidStudioProject.Steps
{
    [Binding]
    public sealed class AppiumTestDefination
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public AppiumTestDefination(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am on NHS login page")]
        public void GivenIAmOnNHSLoginPage()
        {
            
        }

        [When(@"I enter user credential")]
        public void WhenIEnterUserCredential()
        {
            
        }

    }
}
