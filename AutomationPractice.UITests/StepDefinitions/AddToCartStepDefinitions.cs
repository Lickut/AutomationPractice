using AutomationPractice.UITests.Pages;
using AutomationPractice.UITests.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.UITests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Add To Cart")]
    public sealed class AddToCartStepDefinitions
    {
        private IWebDriver _driver;
        private HomeView _homeView;
        private ProductView _productView;
        private SearchView _searchVIew;
        private CartView _cartView;

        public AddToCartStepDefinitions(IWebDriver driver, Settings settings)
        {
            _driver = driver;
            _homeView = new HomeView(_driver);
            _productView = new ProductView(_driver);
            _searchVIew = new SearchView(_driver);
            _cartView = new CartView(_driver);
        }

        [When(@"I search for product using search query")]
        public void WhenISearchForProductUsingSearchQuery()
        {
            _homeView.SearchText(TestData.Blouses.Blouse);
        }

        [When(@"I add product to cart from search page")]
        public void WhenIAddProductToCartFromsearchVIew()
        {
            _searchVIew.HoverOverProduct(TestData.Blouses.Blouse);
            _searchVIew.AddProductToCart(TestData.Blouses.Blouse);
        }

        [When(@"I open category page using navigation")]
        public void WhenIOpenCategoryPageUsingNavigation()
        {
            _homeView.HoverOverMenu(TestData.Categories.Women);
            _homeView.SelectCategory(TestData.WomenCategories.Tops,
                TestData.TopsCategories.Blouses);
        }

        [When(@"I open product page using view more button")]
        public void WhenIOpenproductViewUsingViewMoreButton()
        {
            _searchVIew.HoverOverProduct(TestData.Blouses.Blouse);
            _searchVIew.ViewMore(TestData.Blouses.Blouse);
        }

        [When(@"I add product to cart from product page")]
        public void WhenIAddProductToCartFromproductView()
        {
            _productView.ClickAddToCart();
        }

        [Then(@"Product is added to the cart")]
        public void ThenProductIsAddedToTheCart()
        {
            _cartView.WaitUntilCartViewDisplayed();
            Assert.That(_cartView.IsProductDisplayed(), Is.True);
        }
    }
}