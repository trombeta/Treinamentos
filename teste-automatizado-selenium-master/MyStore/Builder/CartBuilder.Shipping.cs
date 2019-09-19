using OpenQA.Selenium;

namespace MyStore.Builder
{
    public partial class CartBuilder
    {
        public IWebElement ProceedToCheckoutShippingButton => cartPage.ProceedToCheckoutShippingButton;

        public CartBuilder ProceedToCheckoutShippingButtonClick()
        {
            cartPage.ProceedToCheckoutShippingButton.Click();

            return this;
        }

        public CartBuilder TermsOfService()
        {
            cartPage.TermsOfService.Click();

            return this;
        }
    }
}