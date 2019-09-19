using OpenQA.Selenium;

namespace MinhaLoja.PageObjects
{
    public class ProdutosPO
    {
        private IWebDriver driver;
        
        public By byTipoBestSellers;
        public By byTabelaBestSellers;
        public By byItemBestSellers;
        public By byBotaoAddToChart;
        public By byBotaoContinuarComprando;
        public By byBotaoFinalizarCompra;
        public By byBotaoFinalizarCheckout;
        public By byNomeProduto;
        public By byPrecoProduto;
        public By byUrlDetalhesProduto;
        public By byQuantidadeItens;

        public ProdutosPO(IWebDriver driver)
        {
            this.driver = driver;
            byTipoBestSellers = By.ClassName("blockbestsellers");
            byTabelaBestSellers = By.Id("blockbestsellers");
            byItemBestSellers = By.ClassName("product-container");
            byBotaoAddToChart = By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default");
            byBotaoContinuarComprando = By.CssSelector("span.continue.btn.btn-default.button.exclusive-medium");
            byBotaoFinalizarCompra = By.CssSelector("a.btn.btn-default.button.button-medium");
            byBotaoFinalizarCheckout = By.CssSelector("a.button.btn.btn-default.standard-checkout.button-medium");
            byNomeProduto = By.CssSelector("a.product-name");
            byPrecoProduto = By.CssSelector("span.price.product-price");
            byUrlDetalhesProduto = By.CssSelector("a.button.lnk_view.btn.btn-default");
            byQuantidadeItens = By.CssSelector("span.ajax_cart_quantity");
        }
    }
}