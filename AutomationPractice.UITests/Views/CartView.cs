using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.UITests.Pages
{
    public class CartView
    {
        private IWebDriver _driver;

        public CartView(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ProductElement => _driver.FindElement(By.CssSelector("div.layer_cart_product"));

        public void WaitUntilCartViewDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("layer_cart")));
        }

        public bool IsProductDisplayed()
        {
            return ProductElement.Displayed;
        }
    }
}