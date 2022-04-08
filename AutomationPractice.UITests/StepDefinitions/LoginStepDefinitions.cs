using AutomationPractice.UITests.Pages;
using AutomationPractice.UITests.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.UITests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Login")]
    public sealed class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private Settings _settings;
        private HomeView _homeView;
        private AuthenticationView _authenticationView;
        private MyAccountView _myAccountView;
        private string _emailAdress;
        private string _password;

        public LoginStepDefinitions(IWebDriver driver, Settings settings)
        {
            _driver = driver;
            _settings = settings;
            _homeView = new HomeView(_driver);
            _authenticationView = new AuthenticationView(_driver);
            _myAccountView = new MyAccountView(_driver);
        }

        [Given(@"User1 is created")]
        public void GivenUser1IsCreated()
        {
            _emailAdress = _settings.User1.Email;
            _password = _settings.User1.Password;
        }

        [Given(@"Home page is opened")]
        [When(@"I open home page")]
        public void WhenIOpenhomeView()
        {
            _driver.Navigate().GoToUrl(_settings.HostUrl);
        }

        [When(@"I click sign in link")]
        public void WhenIClickSignInLink()
        {
            _homeView.ClickSignInLink();
        }

        [When(@"I sign in with valid email adress and password")]
        public void WhenISignInWithValidEmailAdressAndPassword()
        {
            _authenticationView.SetEmailAdress(_emailAdress);
            _authenticationView.SetPassword(_password);
            _authenticationView.ClickSignIn();
        }

        [Then(@"Main home page elements are displayed")]
        public void ThenMainhomeViewElementsAreDisplayed()
        {
            Assert.That(_homeView.IsSearhBoxDisplayed(), Is.True);
            Assert.That(_homeView.IsSignInLinkDisplayed(), Is.True);
            Assert.That(_homeView.IsShoppingCartLinkDisplayed(), Is.True);
            Assert.That(_homeView.IsHeaderLogoDisplayed(), Is.True);
        }

        [Then(@"My Account page is displayed")]
        public void ThenmyAccountViewIsDisplayed()
        {
            Assert.That(_myAccountView.IsMyWishlistsLinkDisplayed(), Is.True);
        }
    }
}