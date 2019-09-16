using OpenQA.Selenium;

namespace MyStore.Builder
{
    public partial class CartBuilder
    {
        public IWebElement ProceedToCheckoutAddressButton => cartPage.ProceedToCheckoutAddressButton;

        public CartBuilder Message(string message)
        {
            cartPage.Message.SendKeys(message);

            return this;
        }

        public CartBuilder ProceedToCheckoutAddressButtonClick()
        {
            cartPage.ProceedToCheckoutAddressButton.Click();

            return this;
        }
    }
}