using OpenQA.Selenium;

namespace MinhaLoja.PageObjects
{
    public class SumarioPO
    {
        private IWebDriver driver;

        public By byQuantidadeItens;

        public SumarioPO(IWebDriver driver)
        {
            this.driver = driver;
            byQuantidadeItens = By.ClassName("input.cart_quantity_input.form-control.grey");
        }
    }
}
