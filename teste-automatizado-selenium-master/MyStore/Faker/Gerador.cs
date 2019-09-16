using MyStore.Enums;
using MyStore.Helper;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyStore.Faker
{
    class Gerador
    {
        public string GeraNome(Sexo sexo)
        {
            string path;

            var nomesMasculinos = "NomesMasculinos.txt";

            var nomesFemininos = "NomesFemininos.txt";

            if (sexo == Sexo.Masculino)
                path = nomesMasculinos;
            else
                path = nomesFemininos;

            string nome = GeraDadosAleatorios(path);

            return nome;
        }

        public string GeraDadosAleatorios(string path)
        {
            string valorGerado;

            List<string> linhasL = new List<string>();

            var directory = $@"{Directory.GetCurrentDirectory()}\MyStore\Arquivos\";

            using (StreamReader reader = new StreamReader(directory + path, Encoding.GetEncoding("iso-8859-1")))
            {
                string Linhas = string.Empty;

                while ((Linhas = reader.ReadLine()) != null)
                    linhasL.Add(Linhas);

                valorGerado = linhasL[IntegerHelper.Random(0, linhasL.Count)];
            }

            return valorGerado;
        }
    }
}