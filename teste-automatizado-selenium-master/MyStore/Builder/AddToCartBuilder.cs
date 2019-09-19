using MyStore.PageObjects;
using OpenQA.Selenium;

namespace MyStore.Builder
{
    public class AddToCartBuilder
    {
        private IWebDriver driver;
        private AddToCartPage addToCartPage;

        public AddToCartBuilder(IWebDriver driver)
        {
            this.driver = driver;
            addToCartPage = new AddToCartPage(driver);
        }

        public IWebElement ContinueShoppingButton => addToCartPage.ContinueShoppingButton;

        public IWebElement ProceedToCheckoutButton => addToCartPage.ProceedToCheckoutButton;
    }
}