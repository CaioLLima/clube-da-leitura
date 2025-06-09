using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class TelaRevista : TelaBase
    {
        private RepositorioCaixa repositorioCaixa;
        public TelaRevista(RepositorioRevista repositorio, RepositorioCaixa repositorioCaixa) : base("Revista", repositorio)
        {
            this.repositorioCaixa = repositorioCaixa;
        }
        public override void VisualizarRegistro()
        {
            Console.WriteLine("Revistas Cadastrados");
            Console.WriteLine(
                "{0, -5} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                "ID", "Titulo", "Numero de Serie", "Data de publicação", "Status", "Caixa"
            );
            EntidadeBase[] revistas = repositorio.SelecionarRegistros();

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista a = (Revista)revistas[i];

                if (a == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -5} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                a.Id, a.Titulo, a.NumeroEdicao, a.AnoPublicacao,a.Status, a.Caixa.Etiqueta
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        public void VisualizarCaixas()
        {
            Console.WriteLine("Caixas Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                "ID", "Etiqueta", "Cor", "Dias de Empréstimo"
            );
            EntidadeBase[] caixas = repositorioCaixa.SelecionarRegistros();

            for (int i = 0; i < caixas.Length; i++)
            {
                Caixa c = (Caixa)caixas[i];

                if (c == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                c.Id, c.Etiqueta, c.Cor, c.DiasEmprestimo
            );
            }
           
        }
        public override Revista ObterDados()
        {
            Console.Write("Digite o título da revista: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o número da edição da revista: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o ano da publicação da revista: ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

        VisualizarCaixas();

        Console.Write("\nDigite o ID da caixa selecionada: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarRegistroPorID(idCaixa);

        Revista revista = new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);

        return revista;
        }
    }
}
