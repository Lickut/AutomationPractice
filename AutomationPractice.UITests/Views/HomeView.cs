using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.UITests.Pages
{
    public class HomeView
    {
        private IWebDriver _driver;

        public HomeView(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement SearchBox => _driver.FindElement(By.Id("searchbox"));
        private IWebElement SignInLink => _driver.FindElement(By.ClassName("login"));
        private IWebElement HeaderLogo => _driver.FindElement(By.Id("header_logo"));
        private IWebElement ShoppingCartLink => _driver.FindElement(By.XPath("//div[@class='shopping_cart']/a"));
        private IWebElement SearchInput => _driver.FindElement(By.Id("search_query_top"));
        private IWebElement SubmitSearchButton => _driver.FindElement(By.XPath("//button[@name='submit_search']"));
        private IWebElement CartQuantity => _driver.FindElement(By.ClassName("ajax_cart_quantity"));

        private IWebElement GetMenu(string name) => _driver.FindElement(By.XPath($"//ul[contains(@class,'menu-content')]/li[./a[normalize-space()='{name}']]"));
        private IWebElement GetSubMenu(string name) => _driver.FindElement(By.XPath($"//ul[contains(@class,'submenu-container')]/li[./a[normalize-space()='{name}']]"));
        private IWebElement GetCategory(string subMenuName, string category) => GetSubMenu(subMenuName).FindElement(By.XPath($".//a[normalize-space()='{category}']"));

        public bool IsSearhBoxDisplayed()
        {
            return SearchBox.Displayed;
        }

        public bool IsSignInLinkDisplayed()
        {
            return SignInLink.Displayed;
        }

        public bool IsHeaderLogoDisplayed()
        {
            return HeaderLogo.Displayed;
        }

        public bool IsShoppingCartLinkDisplayed()
        {
            return ShoppingCartLink.Displayed;
        }

        public void HoverOverMenu(string name)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(GetMenu(name)).Perform();
        }

        public void SelectCategory(string subMenuName, string category)
        {
            GetCategory(subMenuName, category).Click();
        }

        public void SearchText(string text)
        {
            SearchInput.SendKeys(text);
            SubmitSearchButton.Click();
        }

        public void ClickSignInLink()
        {
            SignInLink.Click();
        }

        public string GetCartQuantity()
        {
            return CartQuantity.Text.Trim();
        }
    }
}