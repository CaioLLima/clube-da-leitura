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
        public TelaCaixa(RepositorioCaixa repositorio) : base("Caixa", repositorio)
        {
        }
        public override void VisualizarRegistro()
        {
            Console.WriteLine("Caixas Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                "ID", "Etiqueta", "Cor", "Dias de Empréstimo"
            );
            EntidadeBase[] caixas = repositorio.SelecionarRegistros();

            for (int i = 0; i < caixas.Length; i++)
            {
                Caixa a = (Caixa)caixas[i];

                if (a == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                a.Id, a.Etiqueta, a.Cor, a.DiasEmprestimo
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
            Console.Write("Dias de Empréstimo (opcional): ");
            bool conseguiuConverter = int.TryParse(Console.ReadLine(), out int diasEmprestimo);

            Caixa caixa;

            if (conseguiuConverter)
                caixa = new Caixa(etiqueta, cor, diasEmprestimo);
            else
                caixa = new Caixa(etiqueta, cor);


            return caixa;
        }
    }
}
