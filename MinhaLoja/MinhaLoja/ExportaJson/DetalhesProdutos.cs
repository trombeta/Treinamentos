namespace MinhaLoja.ExportaJson
{
    public class DetalhesProdutos
    {
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string UrlDetalhes { get; set; }

        public DetalhesProdutos(string nome, string valor, string urlDetalhes)
        {
            Nome = nome;
            Valor = valor;
            UrlDetalhes = urlDetalhes;
        }
    }
}