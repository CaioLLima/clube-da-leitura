using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class TelaAmigo
    {
        public char SelecionarOpcao()
        {
            Console.WriteLine("");
            char opcao = Console.ReadLine().ToUpper()[0];
            return opcao;
        }
    }
}
