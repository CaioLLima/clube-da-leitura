using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;

namespace ClubeDaLeitura.ModuloCaixas
{
    public class TelaCaixa : TelaBase
    {
        private RepositorioCaixa repositorioCaixa = new();
        public TelaCaixa(RepositorioCaixa repositorioC) : base("Caixa", repositorioC)
        {
            repositorioCaixa = repositorioC;
        }
        public override void VisualizarRegistro()
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
                a.id, a.etiqueta, a.cor, a.diasEmprestimo
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        public override Caixa ObterDados()
        {
            Console.Write("Insira a Etiqueta: ");
            string etiqueta = Console.ReadLine();
            Console.Write("Insira a cor: ");
            string cor = Console.ReadLine();
            Console.Write("Insira os dias de empréstimo: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = new(etiqueta, cor, diasEmprestimo);

            return caixa;
        }
    }
}
