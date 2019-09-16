using MyStore.PageObjects;
using OpenQA.Selenium;

namespace MyStore.Builder
{
    public partial class CartBuilder
    {
        private IWebDriver driver;
        private CartPage cartPage;

        public CartBuilder(IWebDriver driver)
        {
            this.driver = driver;
            cartPage = new CartPage(driver);
        }

        public IWebElement CartItens => cartPage.CartItens;

        public IWebElement QuantidadeItens => cartPage.QuantidadeItens;

        public IWebElement ProceedToCheckoutSummaryButton => cartPage.ProceedToCheckoutSummaryButton;

        public CartBuilder ProceedToCheckoutSummaryButtonClick()
        {
            cartPage.ProceedToCheckoutSummaryButton.Click();

            return this;
        }
    }
}