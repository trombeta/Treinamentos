using OpenQA.Selenium;

namespace MinhaLoja.PageObjects
{
    public class PagamentoPO
    {
        private IWebDriver driver;
        public By byFormaPagamentoTransferencia;
        public By byFormaPagamentoCheck;
        public By byBotaoConfirmarOrdem;
        public By byBotaoVoltarParaOrdens;

        public PagamentoPO(IWebDriver driver)
        {
            this.driver = driver;
            byFormaPagamentoTransferencia = By.ClassName("bankwire");
            byFormaPagamentoCheck = By.ClassName("cheque");
            byBotaoConfirmarOrdem = By.CssSelector("button.button.btn.btn-default.button-medium");
            byBotaoVoltarParaOrdens = By.CssSelector("a.button-exclusive.btn.btn-default");
        }
    }
}