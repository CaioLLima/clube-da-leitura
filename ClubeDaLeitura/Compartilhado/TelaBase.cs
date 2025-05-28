using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class TelaBase
    {
        protected string nomeEntidade;
        protected RepositorioBase repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }
        protected char SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine($"1 - Registrar {nomeEntidade}");
            Console.WriteLine($"2 - Editar {nomeEntidade}");
            Console.WriteLine($"3 - Visualizar {nomeEntidade}");
            Console.WriteLine($"4 - Excluir {nomeEntidade}");
            Console.WriteLine("S - Sair");

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }
    }
}
