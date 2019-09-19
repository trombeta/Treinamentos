using MyStore.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyStore.Faker
{
    class Gerador
    {
        public string GeraNome(Sexo sexo)
        {
            string nome;

            string path;

            List<string> linhasL = new List<string>();

            var directory = Directory.GetCurrentDirectory();

            var nomesMasculinos = @"\NomesMasculinos.txt";

            var nomesFemininos = @"\NomesFemininos.txt";

            if (sexo == Sexo.Masculino)
                path = nomesMasculinos;
            else
                path = nomesFemininos;

            using (StreamReader reader = new StreamReader(directory + path, Encoding.GetEncoding("iso-8859-1")))
            {
                string Linhas = string.Empty;

                while ((Linhas = reader.ReadLine()) != null)
                    linhasL.Add(Linhas);

                Random rand = new Random();
                int aleatorio = rand.Next(0, linhasL.Count);

                nome = linhasL[aleatorio];
            }

            return nome;
        }

        public string GerarAleatorio(string arquivo)
        {
            string informacaoAleatoria;

            List<string> linhasL = new List<string>();

            var directory = Directory.GetCurrentDirectory();

            using (StreamReader reader = new StreamReader(directory + arquivo, Encoding.GetEncoding("iso-8859-1")))
            {
                string Linhas = string.Empty;

                while ((Linhas = reader.ReadLine()) != null)
                    linhasL.Add(Linhas);

                Random rand = new Random();
                int aleatorio = rand.Next(0, linhasL.Count);

                informacaoAleatoria = linhasL[aleatorio];
            }

            return informacaoAleatoria;
        }
    }
}