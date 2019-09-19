using MyStore.Faker;
using MyStore.Helper;
using OpenQA.Selenium;

namespace MinhaLoja.PageObjects
{
    public class SignInPO
    {
        private IWebDriver driver;

        private EnumHelper enumHelper = new EnumHelper();
        Gerador gera = new Gerador();

        public By byBotaoSignIn;
        public By byImputemail;
        public By byBotaoCadastrar;
        public By byRadioMr;
        public By byRadioMrs;
        public By byPrimeiroNome;
        public By byUltimoNome;
        public By byEmail;
        public By bySenha;
        public By byDiaAniversario;
        public By byMesAniversario;
        public By byAnoAniversario;
        public By byNewsletter;
        public By byReceive;
        public By byPrimeiroNomeEndereco;
        public By byUltimoNomeEndereco;
        public By byCompania;
        public By byEndereco;
        public By byCidade;
        public By byEstado;
        public By byCep;
        public By byCelular;
        public By byReferencia;
        public By byBotaoRegistrar;
        public By byFormCadastroConta;

        public SignInPO(IWebDriver driver)
        {
            this.driver = driver;
            byBotaoSignIn = By.ClassName("login");
            byImputemail = By.Id("email_create");
            byBotaoCadastrar = By.Id("SubmitCreate");
            byRadioMr = By.Id("id_gender1");
            byRadioMrs = By.Id("id_gender2");
            byPrimeiroNome = By.Id("customer_firstname");
            byUltimoNome = By.Id("customer_lastname");
            byEmail = By.Id("email");
            bySenha = By.Id("passwd");
            byDiaAniversario = By.Id("days");
            byMesAniversario = By.Id("months");
            byAnoAniversario = By.Id("years");
            byNewsletter = By.Id("newsletter");
            byReceive = By.Id("optin");
            byPrimeiroNomeEndereco = By.Id("firstname");
            byUltimoNomeEndereco = By.Id("lastname");
            byCompania = By.Id("company");
            byEndereco = By.Id("address1");
            byCidade = By.Id("city");
            byEstado = By.Id("id_state");
            byCep = By.Id("postcode");
            byCelular = By.Id("phone_mobile");
            byReferencia = By.Id("alias");
            byBotaoRegistrar = By.Id("submitAccount");
            byFormCadastroConta = By.Id("account-creation_form");
        }
    }
}
