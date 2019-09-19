using OpenQA.Selenium;

namespace MyStore.PageObjects
{
    public partial class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CartItens => driver.FindElement(By.ClassName("shopping_cart"));

        public IWebElement QuantidadeItens => CartItens.FindElement(By.CssSelector("span.ajax_cart_quantity"));

        public IWebElement ProceedToCheckoutSummaryButton => 
            driver.FindElement(By.CssSelector("a.button.btn.btn-default.standard-checkout.button-medium"));
    }
}