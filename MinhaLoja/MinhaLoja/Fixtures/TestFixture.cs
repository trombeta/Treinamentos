using MinhaLoja.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MinhaLoja.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver driver { get; private set; }

        //setup
        public TestFixture()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutaval);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com");
        }

        //TearDown
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
