using OpenQA.Selenium;

namespace MyStore.PageObjects
{
    public class AddToCartPage
    {
        private IWebDriver driver;

        public AddToCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ContinueShoppingButton => 
            driver.FindElement(By.CssSelector("span.continue.btn.btn-default.button.exclusive-medium"));

        public IWebElement ProceedToCheckoutButton => 
            driver.FindElement(By.CssSelector("a.btn.btn-default.button.button-medium"));
    }
}