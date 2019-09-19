using OpenQA.Selenium;

namespace MyStore.PageObjects
{
    public partial class CartPage
    {
        public IWebElement ProceedToCheckoutAddressButton =>
           driver.FindElement(By.CssSelector("button.button.btn.btn-default.button-medium"));

        public IWebElement Message => driver.FindElement(By.Name("message"));
    }
}