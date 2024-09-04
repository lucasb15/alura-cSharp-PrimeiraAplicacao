using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenSounder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Screen Sound
            string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
            /*List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };*/

            Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
            bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
            bandasRegistradas.Add("The Beatles", new List<int> { 10, 10, 10});

            void ExibirLogo()
            {
                Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
                Console.WriteLine(mensagemDeBoasVindas);
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite -1 para sair");

                Console.Write("\nDigite a sua opção: ");
                string opcaoEscolhida = Console.ReadLine();
                int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        RegistrarBandas();
                        break;
                    case 2:
                        MostrarBandasRegistradas();
                        break;
                    case 3:
                        AvaliarUmaBanda();
                        break;
                    case 4:
                        ExibirMedia();
                        break;
                    case -1:
                        Console.WriteLine("Tchau tchau :)");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

            void RegistrarBandas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Registro de bandas");
                Console.Write("Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine();
                bandasRegistradas.Add(nomeDaBanda, new List<int>());

                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void MostrarBandasRegistradas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

                foreach(string banda in bandasRegistradas.Keys) {
                    Console.WriteLine($"Banda: {banda}");
                }
                
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal\n");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }


            void ExibirTituloDaOpcao(string titulo)
            {
                int quantidadeDeLetras = titulo.Length;
                string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '*');
                Console.WriteLine(asterisco);
                Console.WriteLine(titulo);
                Console.WriteLine(asterisco + "\n");
            }

            void AvaliarUmaBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Avaliar banda");
                Console.Write("Digite o nome da banda que quer avaliar: ");
                string nomeDaBanda = Console.ReadLine();

                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"\nQual a nota que a banda merece? ");
                    int nota = int.Parse(Console.ReadLine());
                    bandasRegistradas[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                    Thread.Sleep(4000);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
                    Console.WriteLine($"Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey(true);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
            }

            void ExibirMedia()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibir média da banda");
                Console.Write("Digite o nome da banda que quer ver as notas: ");
                string nomeDaBanda = Console.ReadLine();

                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
                    Console.WriteLine($"\nA média da {nomeDaBanda} é {notasDaBanda.Average()}");
                    Console.WriteLine($"Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                } else
                {
                    Console.WriteLine("A banda não foi encontrada");
                    Console.WriteLine($"Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey(true);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
            }

            ExibirOpcoesDoMenu();
        }
    }
}
