using OpenQA.Selenium;

namespace MyStore.Builder
{
    public partial class CartBuilder
    {
        public IWebElement PayByBankWireButton => cartPage.PayByBankWireButton;

        public IWebElement PayByCheckButton => cartPage.PayByCheckButton;

        public IWebElement ConfirmOrderButton => cartPage.ConfirmOrderButton;

        public IWebElement BankWireConfirmationMessage => cartPage.BankWireConfirmationMessage;

        public IWebElement CheckConfirmationMessage => cartPage.CheckConfirmationMessage;

        public IWebElement BackToOrdersButton => cartPage.BackToOrdersButton;

        public CartBuilder PayByBankWireButtonClick()
        {
            cartPage.PayByBankWireButton.Click();

            return this;
        }

        public CartBuilder PayByCheckButtonClick()
        {
            cartPage.PayByCheckButton.Click();

            return this;
        }

        public CartBuilder ConfirmOrderButtonClick()
        {
            cartPage.ConfirmOrderButton.Click();

            return this;
        }
    }
}