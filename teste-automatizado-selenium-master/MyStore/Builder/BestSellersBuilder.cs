using MyStore.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MyStore.Builder
{
    public class BestSellersBuilder
    {
        private IWebDriver driver;
        private BestSellersPage bestSellers;

        public BestSellersBuilder(IWebDriver driver)
        {
            this.driver = driver;
            bestSellers = new BestSellersPage(driver);
        }

        public IWebElement TabelaBestSellers => bestSellers.TabelaBestSellers;

        public IList<IWebElement> RowsBestSellers => bestSellers.RowsBestSellers;

        public BestSellersBuilder AbaBestSellers()
        {
            bestSellers.AbaBestSellers.Click();

            return this;
        }
    }
}