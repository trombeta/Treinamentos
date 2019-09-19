using OpenQA.Selenium;

namespace MinhaLoja.PageObjects
{
    public class EnderecoPO
    {
        private IWebDriver driver;
        public By byBotaoProsseguirCheckout;
        public By byEnderecoEntrega;

        public EnderecoPO(IWebDriver driver)
        {
            this.driver = driver;
            byBotaoProsseguirCheckout = By.CssSelector("button.button.btn.btn-default.button-medium");
            byEnderecoEntrega = By.Id("id_address_delivery");
        }
    }
}
