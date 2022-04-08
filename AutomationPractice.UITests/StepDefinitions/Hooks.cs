using AutomationPractice.UITests.Support;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.UITests.StepDefinitions
{
    [Binding]
    class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [BeforeTestRun]
        public static void TestSetup()
        {
        }

        [BeforeScenario]
        public void BeforeEveryScenario()
        {
            var driver = DriverFactory.CreateWebDriver();
            _objectContainer.RegisterInstanceAs(driver, typeof(IWebDriver));
        }

        [AfterScenario]
        public void AfterEveryScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            DriverFactory.CloseDriver(driver);
        }

        [AfterTestRun]
        public static void Teardown()
        {
        }
    }
}
