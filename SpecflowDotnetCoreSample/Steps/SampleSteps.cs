using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowDotnetCoreSample.Steps
{
    [Binding]
    public class SampleSteps
    {
        private ScenarioContext _scenarioContext;
        private const string NumbersKey = "numbers";
        private const string SumKey = "sum";

        public SampleSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            if (!_scenarioContext.ContainsKey(NumbersKey))
            {
                _scenarioContext.Add(NumbersKey, new List<int>());
            }

            _scenarioContext.Get<List<int>>(NumbersKey).Add(number);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _scenarioContext.TryGetValue(NumbersKey, out List<int> numbersList);
            _scenarioContext.Add(SumKey, numbersList.Sum());
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expected)
        {
            _scenarioContext.TryGetValue(SumKey, out int actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
