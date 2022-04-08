using OpenQA.Selenium;

namespace AutomationPractice.UITests.Pages
{
    public class ProductView
    {
        private IWebDriver _driver;

        public ProductView(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement AddToCartButton => _driver.FindElement(By.XPath("//p[@id='add_to_cart']/button"));

        public void ClickAddToCart()
        {
            AddToCartButton.Click();
        }
    }
}