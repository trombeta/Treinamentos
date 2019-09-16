using System;
using System.Collections.Generic;

namespace BDD
{
    public class Login
    {
        public List<string> Email { get; set; }

        public List<string> Senha { get; set; }

        public List<string> Resultado { get; set; }

        public Tuple<int, int> QuantidadeItens(List<string> email, List<string> senha)
        {
            return new Tuple<int, int>(email.Count, senha.Count);
        }
    }
}