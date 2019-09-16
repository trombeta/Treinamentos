using MinhaLoja.ExportaJson;
using MinhaLoja.Fixtures;
using MinhaLoja.PageObjects;
using MyStore.Enums;
using MyStore.Faker;
using MyStore.Helper;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;

namespace MinhaLoja.TesteUI
{
    [Collection("Chrome Driver")]
    public class MinhasComprasTestUI
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MinhasComprasTestUI(TestFixture fixture)
        {
            driver = fixture.driver;
            this.wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
        }

        [Fact]
        public void DeveEfetuarComprasERealizarPagamento()
        {
            SelecionarAbaBestSellers();
            AdicionarItensCarrinho();
            FinalizarCompras();
            CriarConta();
            FinalizarEndereco();
            AceitarRemessa();
            RealizarPagamento();

            Thread.Sleep(2000);
        }

        public void SelecionarAbaBestSellers()
        {
            var produtosPO = new ProdutosPO(driver);

            driver.FindElement(produtosPO.byTipoBestSellers).Click();
        }

        public void AdicionarItensCarrinho()
        {
            var produtosPO = new ProdutosPO(driver);

            IList<DetalhesProdutos> detalhesProduto = new List<DetalhesProdutos>();

            var produtosTabela = driver.FindElement(produtosPO.byTabelaBestSellers);
            produtosTabela.Click();
            Thread.Sleep(1000);
            var opcoes = produtosTabela
                .FindElements(By.CssSelector("li>div>div>div[class=product-image-container]"))
                .ToList();

            var nomeProduto = produtosTabela.FindElements(produtosPO.byNomeProduto).ToList();
            var precoProduto = produtosTabela.FindElements(produtosPO.byPrecoProduto).ToList();
            var urlDetalhes = produtosTabela.FindElements(produtosPO.byUrlDetalhesProduto).ToList();

            for (int i = 0; i < opcoes.Count(); i++)
            {
                var Botao = produtosTabela
                .FindElements(produtosPO.byBotaoAddToChart)
                .ToList();
                new Actions(driver).MoveToElement(opcoes[i]).Perform();

                wait.Until(t => Botao[i].Displayed);

                detalhesProduto.Add(new DetalhesProdutos(
                    nomeProduto[i].GetAttribute("title").ToString(),
                    precoProduto[i].GetAttribute("textContent").Trim().ToString(),
                    urlDetalhes[i].GetAttribute("href").ToString()
                    ));

                Botao[i].Click();

                wait.Until(t => driver.FindElement(produtosPO.byBotaoContinuarComprando).Displayed);

                driver.FindElement(produtosPO.byBotaoContinuarComprando).Click();
            }

            driver.FindElement(produtosPO.byBotaoFinalizarCompra).Click();

            ExportaDetalhesProdutoJson(detalhesProduto);

            wait.Until(t => driver.FindElement(produtosPO.byQuantidadeItens).Displayed);
            string quantidadesSelecionada = opcoes.Count().ToString();

            Assert.Equal(quantidadesSelecionada, driver.FindElement(produtosPO.byQuantidadeItens).Text);
        }

        public void ExportaDetalhesProdutoJson(IList<DetalhesProdutos> produto)
        {
            string result = JsonConvert.SerializeObject(produto, Formatting.Indented);

            using (var tw = new StreamWriter(Environment.CurrentDirectory + @"\DetalhesProdutosJson.txt", false))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
        }

        public void FinalizarCompras()
        {
            var produtosPO = new ProdutosPO(driver);
            var signInPO = new SignInPO(driver);

            driver.FindElement(produtosPO.byBotaoFinalizarCheckout).Click();

            Assert.True(driver.FindElement(signInPO.byBotaoCadastrar).Displayed);
        }

        public void CriarConta()
        {
            var signInPO = new SignInPO(driver);
            Gerador gera = new Gerador();
            EnumHelper enumHelper = new EnumHelper();

            Random random = new Random();
            Sexo sexo = enumHelper.EnumAleatorio<Sexo>();

            string primeiroNome = gera.GeraNome(sexo);
            string ultimoNome = gera.GerarAleatorio(@"\Sobrenomes.txt");
            string senha = random.Next(11111, 99999).ToString();
            string email = $"{senha}.{DateTime.Today.ToString("ddMMyyyy")}@email.com";
            string diaAniversario = random.Next(1, 29).ToString();
            string mesAniversario = gera.GerarAleatorio(@"\Meses.txt");
            string anoAniversario = random.Next(1970, 2000).ToString();
            string cep = random.Next(11111, 99999).ToString();
            string telefone = $"({Convert.ToInt32(random.Next(41, 45).ToString())})" +
                $" {Convert.ToInt32(random.Next(1111, 9999).ToString())}-" +
                $"{Convert.ToInt32(random.Next(1111, 9999).ToString())}";
            string cidade = gera.GerarAleatorio(@"\Cidades.txt");
            string estado = gera.GerarAleatorio(@"\Estados.txt");
            string endereco = $"{gera.GerarAleatorio(@"\Logradouros.txt")} {ultimoNome}, nº {cep}";

            driver.FindElement(signInPO.byImputemail).SendKeys(email);
            driver.FindElement(signInPO.byBotaoCadastrar).Click();

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(signInPO.byRadioMr));

            if (sexo == Sexo.Masculino)
                driver.FindElement(signInPO.byRadioMr).Click();
            else
                driver.FindElement(signInPO.byRadioMrs).Click();

            driver.FindElement(signInPO.byPrimeiroNome).SendKeys(primeiroNome);
            driver.FindElement(signInPO.byUltimoNome).SendKeys(ultimoNome);
            driver.FindElement(signInPO.bySenha).SendKeys(senha);
            driver.FindElement(signInPO.byDiaAniversario).SendKeys(diaAniversario);
            driver.FindElement(signInPO.byMesAniversario).SendKeys(mesAniversario);
            driver.FindElement(signInPO.byAnoAniversario).SendKeys(anoAniversario);
            driver.FindElement(signInPO.byNewsletter).Click();
            driver.FindElement(signInPO.byReceive).Click();
            driver.FindElement(signInPO.byEndereco).SendKeys(endereco);
            driver.FindElement(signInPO.byCidade).SendKeys(cidade);
            driver.FindElement(signInPO.byEstado).SendKeys(estado);
            driver.FindElement(signInPO.byCep).SendKeys(cep);
            driver.FindElement(signInPO.byCelular).SendKeys(telefone);
            driver.FindElement(signInPO.byReferencia).SendKeys("Meu Endereço");
            driver.FindElement(signInPO.byBotaoRegistrar).Click();

            var enderecoPO = new EnderecoPO(driver);
            Assert.True(driver.FindElement(enderecoPO.byBotaoProsseguirCheckout).Displayed);
        }

        public void FinalizarEndereco()
        {
            var enderecoPO = new EnderecoPO(driver);

            driver.FindElement(enderecoPO.byBotaoProsseguirCheckout).Click();

            var remessaPO = new RemessaPO(driver);
            Assert.True(driver.FindElement(remessaPO.byBotaoProsseguirCheckout).Displayed);
        }

        public void AceitarRemessa()
        {
            var remessaPO = new RemessaPO(driver);

            driver.FindElement(remessaPO.byTermoDeServico).Click();
            driver.FindElement(remessaPO.byBotaoProsseguirCheckout).Click();

            var pagamentoPO = new PagamentoPO(driver);
            Assert.True(driver.FindElement(pagamentoPO.byFormaPagamentoTransferencia).Displayed);
        }

        public void RealizarPagamento()
        {
            var pagamentoPO = new PagamentoPO(driver);
            var randon = new Random();

            var formaPagamento = randon.Next(2);
            
            if(formaPagamento == 0)
                driver.FindElement(pagamentoPO.byFormaPagamentoTransferencia).Click();
            else
                driver.FindElement(pagamentoPO.byFormaPagamentoCheck).Click();

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(pagamentoPO.byBotaoConfirmarOrdem));

            driver.FindElement(pagamentoPO.byBotaoConfirmarOrdem).Click();

            Assert.True(driver.FindElement(pagamentoPO.byBotaoVoltarParaOrdens).Displayed);

            driver.FindElement(pagamentoPO.byBotaoVoltarParaOrdens).Click();

            Screenshot _shot = ((ITakesScreenshot)driver).GetScreenshot();
            _shot.SaveAsFile(Environment.CurrentDirectory + @"\ResumoCompras.png");
        }
    }
}