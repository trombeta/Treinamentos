namespace MyStore.Json
{
    public class BestSellers
    {
        public string Nome { get; set; }

        public string Valor { get; set; }

        public string Url { get; set; }

        public BestSellers(string nome, string valor, string url)
        {
            Nome = nome;
            Valor = valor;
            Url = url;
        }        
    }
}