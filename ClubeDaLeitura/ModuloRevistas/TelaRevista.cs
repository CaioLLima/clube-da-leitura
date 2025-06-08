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
        private RepositorioRevista repositorioRevista = new();
        private RepositorioCaixa repositorioCaixa = new();
        public TelaRevista(RepositorioRevista repositorioR, RepositorioCaixa repositorioC) : base("Revista", repositorioR)
        {
            repositorioRevista = repositorioR;
            repositorioCaixa = repositorioC;
        }
        public override void VisualizarRegistro()
        {
            Console.WriteLine("Revistas Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -10} | {5 -10}",
                "ID", "Titulo", "Numero de Serie", "Data de publicação", "Status", "Caixa"
            );
            EntidadeBase[] revistas = repositorioRevista.SelecionarRegistros();

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista a = (Revista)revistas[i];

                if (a == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -10} | {5, -10}",
                a.id, a.titulo, a.numEdicao, a.dataPublicacao,a.statusEmprestimo, a.caixa.Etiqueta
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        public void VisualizarCaixas()
        {
            Console.WriteLine("Caixas Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Etiqueta", "Cor", "Data de Empréstimo"
            );
            EntidadeBase[] caixas = repositorioCaixa.SelecionarRegistros();

            for (int i = 0; i < caixas.Length; i++)
            {
                Caixa a = (Caixa)caixas[i];

                if (a == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                a.Id, a.Etiqueta, a.Cor, a.DiasEmprestimo
            );
            }
           
        }
        public override Revista ObterDados()
        {
            Console.Write("Insira o Titulo: ");
            string titulo = Console.ReadLine();
            Console.Write("Insira a numero de edição: ");
            string numEdicao = Console.ReadLine();
            Console.Write("Insira a data da publicação: ");
            string dataPublicacao = Console.ReadLine();
            Console.Write("Insira a data da publicação: ");

            VisualizarCaixas();

            Console.Write("Digite o ID do caixa que deseja inserir a revista: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            EntidadeBase  caixaSelecionada = repositorioCaixa.SelecionarRegistroPorID(idCaixa);

            Revista revista = new(titulo, numEdicao, dataPublicacao, (Caixa)caixaSelecionada);

            return revista;
        }
    }
}
