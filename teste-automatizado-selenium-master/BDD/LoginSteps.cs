using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace BDD
{
    [Binding]
    public class LoginSteps
    {
        private readonly Login Login;

        private int ValidaEmail;

        private int ValidaSenha;

        public LoginSteps(Login login)
        {
            this.Login = login;
        }

        [Given(@"o email")]
        public void DadoOEmail(Table table)
        {
            Login.Email = new List<string>();
            PercorreLista(table, Login.Email);
        }

        [Given(@"a senha")]
        public void DadoASenha(Table table)
        {
            Login.Senha = new List<string>();

            PercorreLista(table, Login.Senha);
        }

        [When(@"eu pressionar o botão Login In")]
        public void QuandoEuPressionarOBotaoLoginIn()
        {
            ValidaEmail = Login.QuantidadeItens(Login.Email, Login.Senha).Item1;

            ValidaSenha = Login.QuantidadeItens(Login.Email, Login.Senha).Item2;
        }

        [Then(@"o resultado será")]
        public void EntaoOResultadoSera(Table table)
        {
            Login.Resultado = new List<string>();

            for (int i = 0; i < table.RowCount; i++)
            {
                Login.Resultado.Add(table.Rows[i].Values.FirstOrDefault());

                Assert.IsTrue(Login.Resultado[i].Equals("Sucesso") || Login.Resultado[i].Equals("Falha"));
            }

            Assert.IsTrue(table.RowCount.Equals(ValidaEmail) && table.RowCount.Equals(ValidaSenha));
        }

        private void PercorreLista(Table table, List<string> lista)
        {
            for (int i = 0; i < table.RowCount; i++)
                lista.Add(table.Rows[i].Values.FirstOrDefault());
        }
    }
}