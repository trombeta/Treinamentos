using TechTalk.SpecFlow;

namespace SpecFLow
{
    [Binding]
    public class LoginSiteDeComprasSteps
    {
        public string Email;
        public string Senha;
        public string ResultadoEsperado;

        [Given(@"um e-mail (.*)")]
        public void DadoUmEMail(string email)
        {
            Email = email;
        }
        
        [Given(@"uma senha (.*)")]
        public void DadoUmaSenha(string senha)
        {
            Senha = senha;
        }
        
        [When(@"clico em logar")]
        public void QuandoClicoEmLogar()
        {
            
        }
        
        [Then(@"login é realizado com (.*)")]
        public void EntaoLoginERealizadoComSucesso(string resultadoEsperado)
        {
            ScenarioContext.Current.Pending();
        }
    }
}