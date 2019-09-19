using MyStore.Builder;
using MyStore.Enums;
using MyStore.Extension;
using MyStore.Faker;
using MyStore.Helper;
using MyStore.Json;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace MyStore.TestUI
{
    [TestFixture]
    public class MyStoreTestUI
    {
        private IWebDriver driver;
        private BestSellersBuilder bestSellersBuilder;
        private AddToCartBuilder addToCartBuilder;
        private CartBuilder cartBuilder;
        private WebDriverWait wait;
        private EnumHelper enumHelper = new EnumHelper();

        [SetUp]
        public void Inicialize()
        {
            driver = new ChromeDriver();

            this.bestSellersBuilder = new BestSellersBuilder(driver);
            this.addToCartBuilder = new AddToCartBuilder(driver);
            this.cartBuilder = new CartBuilder(driver);
            this.enumHelper = new EnumHelper();
            this.wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://automationpractice.com");

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Finalize()
        {
            Thread.Sleep(3000);

            driver.Quit();
        }

        [Test]
        public void Deve_adicionar_todos_best_sellers_no_carrinho_e_realizar_payment()
        {
            SelecionarItensBestSellers();
            CriarContaUsuario();
            AcessaAbaEndereco();
            AcessaAbaShipping();
            AcessaAbaPayment();
        }

        public void SelecionarItensBestSellers()
        {
            bestSellersBuilder.AbaBestSellers();

            int linhas = bestSellersBuilder.RowsBestSellers.Count;

            IList<BestSellers> dados = new List<BestSellers>();

            for (int i = 0; i < linhas; i++)
            {
                IWebElement Nome = bestSellersBuilder
                    .RowsBestSellers[i]
                    .FindElement(By.CssSelector("a.product-name"));

                new Actions(driver).MoveToElement(Nome).Perform();

                IWebElement Preco = bestSellersBuilder
                    .RowsBestSellers[i]
                    .FindElement(By.CssSelector("span.price.product-price"));

                IWebElement UrlDetalhes = bestSellersBuilder
                    .RowsBestSellers[i]
                    .FindElement(By.CssSelector("a.button.lnk_view.btn.btn-default"));

                dados.Add(new BestSellers(Nome.Text, 
                    Preco.GetAttribute("textContent").Trim(),
                    UrlDetalhes.GetAttribute("href")));

                IWebElement addToCartButton = bestSellersBuilder
                    .RowsBestSellers[i]
                    .FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));

                wait.Until(t => addToCartButton.Displayed);

                addToCartButton.Click();

                if (i != bestSellersBuilder.RowsBestSellers.Count - 1)
                {
                    wait.Until(t => addToCartBuilder.ContinueShoppingButton.Displayed);
                    addToCartBuilder.ContinueShoppingButton.Click();
                }
                else
                {
                    wait.Until(t => addToCartBuilder.ProceedToCheckoutButton.Displayed);
                    addToCartBuilder.ProceedToCheckoutButton.Click();
                }
            }

            ExportaDadosJsonParaArquivoTxt(dados);

            Assert.AreEqual(linhas, int.Parse(cartBuilder.QuantidadeItens.Text));
        }

        public void ExportaDadosJsonParaArquivoTxt(IList<BestSellers> bestSellers)
        {
            string result = JsonConvert.SerializeObject(bestSellers, Formatting.Indented);

            using (var tw = new StreamWriter(Environment.CurrentDirectory + @"\dadosJson.txt", false))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
        }

        public void CriarContaUsuario()
        {
            Sexo sexo = enumHelper.EnumAleatorio<Sexo>();

            Gerador gera = new Gerador();

            string firsName = gera.GeraNome(sexo);
            string lastName = gera.GeraDadosAleatorios("Sobrenomes.txt");
            string email = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic")
                .GetBytes($"{firsName}.{lastName}.{IntegerHelper.Random(111,999)}@hotmail.com")).ToLower().Trim();
            string password = IntegerHelper.Random(11111, 99999).ToString();
            string monthOfBirth = enumHelper.EnumAleatorio<MesesAno>().ObterDescricao();
            int dayOfBirth = IntegerHelper.Random(1,29);
            int yearOfBirth = IntegerHelper.Random(1980, 2000);
            int zipPostalCode = IntegerHelper.Random(11111, 99999);
            string phoneNumber = $"({IntegerHelper.Random(44, 47)}) {IntegerHelper.Random(1111,9999)}-{IntegerHelper.Random(1111, 9999)}";
            string city = gera.GeraDadosAleatorios("Cidades.txt");
            string state = gera.GeraDadosAleatorios("Estados.txt");
            string address = $"{gera.GeraDadosAleatorios("Logradouros.txt")} {lastName}, nº {IntegerHelper.Random(10,999)}";

            cartBuilder
                .ProceedToCheckoutSummaryButtonClick()
                    .EmailCreate(email)
                    .CreateAccountButtonClick();

            Thread.Sleep(2000);

            if (sexo == Sexo.Masculino)
                cartBuilder
                    .Mr.Click();
            else
                cartBuilder
                    .Mrs.Click();

            cartBuilder
                .FirstName(firsName)
                .LastName(lastName)
                .Password(password)
                .DayOfBirth(dayOfBirth)
                .MonthOfBirth(monthOfBirth)
                .YearOfBirth(yearOfBirth)
                .FirstLineAddress(address)
                .City(city)
                .State(state)
                .ZipPostalCode(zipPostalCode.ToString())
                .MobilePhone(phoneNumber)
            .RegisterButtonClick();

            Assert.IsTrue(wait.Until(t => cartBuilder.ProceedToCheckoutAddressButton.Displayed));
        }

        public void AcessaAbaEndereco()
        {
            wait.Until(t => cartBuilder.ProceedToCheckoutAddressButton.Displayed);

            cartBuilder
                .ProceedToCheckoutAddressButtonClick();

            Assert.IsTrue(wait.Until(t => cartBuilder.ProceedToCheckoutShippingButton.Displayed));
        }

        public void AcessaAbaShipping()
        {
            cartBuilder
                .TermsOfService()
                .ProceedToCheckoutShippingButtonClick();

            Assert.IsTrue(wait.Until(t => cartBuilder.PayByBankWireButton.Displayed));
        }

        public void AcessaAbaPayment()
        {
            wait.Until(t => cartBuilder.PayByBankWireButton.Displayed);

            cartBuilder
                .PayByBankWireButtonClick();

            wait.Until(t => cartBuilder.ConfirmOrderButton.Displayed);

            cartBuilder
                .ConfirmOrderButtonClick();

            AjustaScrollPagina();

            Screenshot print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(Environment.CurrentDirectory + @"\Evidencia.jpeg");

            var confirmationMessage = "Your order on My Store is complete.";

            Assert.AreEqual(cartBuilder.BankWireConfirmationMessage.GetAttribute("textContent").Trim(), confirmationMessage);
        }

        public void AjustaScrollPagina()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Home).Perform();
            actions.MoveToElement(cartBuilder.BackToOrdersButton).Perform();
        }
    }
}