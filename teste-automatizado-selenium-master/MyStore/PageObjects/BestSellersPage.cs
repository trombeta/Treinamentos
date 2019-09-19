using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStore.PageObjects
{
    public class BestSellersPage
    {
        private IWebDriver driver;

        public BestSellersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AbaBestSellers => driver.FindElement(By.ClassName("blockbestsellers"));

        public IWebElement TabelaBestSellers => driver.FindElement(By.Id("blockbestsellers"));

        public IList<IWebElement> RowsBestSellers => TabelaBestSellers.FindElements(By.ClassName("product-container"));
    }
}