using OpenQA.Selenium;

namespace MinhaLoja.PageObjects
{
    public class RemessaPO
    {
        private IWebDriver driver;
        public By byTermoDeServico;
        public By byBotaoProsseguirCheckout;

        public RemessaPO(IWebDriver driver)
        {
            this.driver = driver;
            byTermoDeServico = By.Id("cgv");
            byBotaoProsseguirCheckout = By.CssSelector("button.button.btn.btn-default.standard-checkout.button-medium");
        }
    }
}
