using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class TelaAmigo //: TelaBase
    {
        private RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

        public void CadastrarAmigo()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de novo Amigo");
            Console.WriteLine();
            Amigo amigo = ObterDados();

            repositorioAmigo.CadastrarRegistro(amigo);
        }

        public Amigo ObterDados()
        {
            Console.WriteLine("Insira o nome do amigo: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o nome do resposavel: ");
            string responsavel = Console.ReadLine();
            Console.WriteLine("Insira o número de telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new(nome, responsavel, telefone);
            
            return amigo;
        }
    }
}
