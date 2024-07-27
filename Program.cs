using Course.Entities;
using System;
using System.Globalization;
using System.IO;

namespace Course {
    class Program {
        static void Main(string[] args) {

            Console.Write("Entre com pagina de busca:  ");
            string sourceFilePath = Console.ReadLine();

            try {
                string[] Linha = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\saida";
                string targetFilePath = targetFolderPath + @"\sumario.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath)) {
                    foreach (string linha in Linha) {

                        string[] fields = linha.Split(',');
                        string nome = fields[0];
                        double preço = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantidade = int.Parse(fields[2]);

                        Produto prod = new Produto(nome, preço, quantidade);

                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine("Erro Inesperado!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
