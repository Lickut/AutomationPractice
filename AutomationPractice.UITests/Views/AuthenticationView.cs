using OpenQA.Selenium;

namespace AutomationPractice.UITests.Pages
{
    public class AuthenticationView
    {
        private IWebDriver _driver;

        public AuthenticationView(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement EmailAdressInput => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("passwd"));
        private IWebElement SignInButton => _driver.FindElement(By.Id("SubmitLogin"));

        public void SetEmailAdress(string emailAdress)
        {
            EmailAdressInput.SendKeys(emailAdress);
        }

        public void SetPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public void ClickSignIn()
        {
            SignInButton.Click();
        }
    }
}