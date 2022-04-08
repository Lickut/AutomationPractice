using OpenQA.Selenium;

namespace AutomationPractice.UITests.Pages
{
    public class MyAccountView
    {
        private IWebDriver _driver;

        public MyAccountView(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement MyWishlistsLink => _driver.FindElement(By.ClassName("myaccount-link-list"));

        public bool IsMyWishlistsLinkDisplayed()
        {
            return MyWishlistsLink.Displayed;
        }
    }
}