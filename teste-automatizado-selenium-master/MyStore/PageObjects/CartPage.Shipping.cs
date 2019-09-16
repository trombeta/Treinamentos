using OpenQA.Selenium;

namespace MyStore.PageObjects
{
    public partial class CartPage
    {
        public IWebElement TermsOfService => driver.FindElement(By.Name("cgv"));

        public IWebElement ProceedToCheckoutShippingButton =>
            driver.FindElement(By.CssSelector("button.button.btn.btn-default.standard-checkout.button-medium"));
    }
}