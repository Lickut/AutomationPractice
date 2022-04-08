using AutomationPractice.UITests.Pages;
using AutomationPractice.UITests.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.UITests.StepDefinitions
{
    [Binding]
    public sealed class CommonStepDefinition
    {
        private IWebDriver _driver;
        private HomeView _homeView;
        private AuthenticationView _authenticationView;

        public CommonStepDefinition(IWebDriver driver)
        {
            _driver = driver;
            _homeView = new HomeView(_driver);
            _authenticationView = new AuthenticationView(_driver);
        }

        [Given(@"I sign in as User1")]
        public void GivenISignInAsUser1()
        {
            _driver.Navigate().GoToUrl(Settings.HostUrl);
            _homeView.ClickSignInLink();
            _authenticationView.SetEmailAdress(Settings.User1.Email);
            _authenticationView.SetPassword(Settings.User1.Password);
            _authenticationView.ClickSignIn();
        }

        [Given(@"I sign in as User2")]
        public void GivenISignInAsUser2()
        {
            _driver.Navigate().GoToUrl(Settings.HostUrl);
            _homeView.ClickSignInLink();
            _authenticationView.SetEmailAdress(Settings.User2.Email);
            _authenticationView.SetPassword(Settings.User2.Password);
            _authenticationView.ClickSignIn();
        }

        [Given(@"Home page is opened")]
        [When(@"I open home page")]
        public void WhenIOpenhomeView()
        {
            _driver.Navigate().GoToUrl(Settings.HostUrl);
        }
    }
}