using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.UITests.Pages
{
    public class SearchView
    {
        private IWebDriver _driver;

        public SearchView(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement GetProduct(string productName) =>
            _driver.FindElement(By.XPath($"//div[.//a[@class='product-name' and normalize-space()='{productName}'] and @class='product-container']"));

        private IWebElement GetAddToCartButton(string productName)
        {
            return GetProduct(productName).FindElement(By.XPath("//a[contains(@class, 'add_to_cart_button')]"));
        }

        private IWebElement GetViewMoreButton(string productName)
        {
            return GetProduct(productName).FindElement(By.XPath("//a[contains(@class, 'lnk_view')]"));
        }

        public void HoverOverProduct(string productName)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(GetProduct(productName)).Perform();
        }

        public void AddProductToCart(string productName)
        {
            GetAddToCartButton(productName).Click();
        }

        public void ViewMore(string productName)
        {
            GetViewMoreButton(productName).Click();
        }
    }
}