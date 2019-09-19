using OpenQA.Selenium;

namespace MyStore.PageObjects
{
    public partial class CartPage
    {
        public IWebElement PayByBankWireButton => driver.FindElement(By.ClassName("bankwire"));

        public IWebElement PayByCheckButton => driver.FindElement(By.ClassName("cheque"));

        public IWebElement BankWireConfirmationMessage => driver.FindElement(By.ClassName("cheque-indent"));

        public IWebElement CheckConfirmationMessage => driver.FindElement(By.CssSelector("p.alert.alert-success"));

        public IWebElement ConfirmOrderButton => 
            driver.FindElement(By.CssSelector("button.button.btn.btn-default.button-medium"));

        public IWebElement BackToOrdersButton =>
            driver.FindElement(By.CssSelector("a.button-exclusive.btn.btn-default"));
    }
}