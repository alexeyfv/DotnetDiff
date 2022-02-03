using System;
using TechTalk.SpecFlow;

namespace DotnetDiff.Specs.StepDefinitions
{
    [Binding]
    public class DotNetCoreProjectSearcherStepDefinitions
    {
        [Given(@"the <files>")]
        public void GivenTheFiles()
        {
            throw new PendingStepException();
        }

        [When(@"searcher returns project")]
        public void WhenSearcherReturnsProject()
        {
            throw new PendingStepException();
        }

        [Then(@"the projects should be ""([^""]*)""")]
        public void ThenTheProjectsShouldBe(string p0)
        {
            throw new PendingStepException();
        }
    }
}
