using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class TelaAmigo : TelaBase
    {
        private RepositorioAmigo repositorioAmigo = new();
        public TelaAmigo(RepositorioAmigo repositorioA) : base("Amigo", repositorioA)
        {
            repositorioAmigo = repositorioA;
        }
        public override void VisualizarRegistro()
        {
            Console.WriteLine("Amigos Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Nome", "Responsável", "Telefone"
            );
            EntidadeBase[] amigos = repositorioAmigo.SelecionarRegistros();

            for(int i = 0; i < amigos.Length; i++)
            {
                Amigo a = (Amigo)amigos[i];

                if (a == null) 
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                a.id, a.nome, a.responsavel, a.telefone
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        public override Amigo ObterDados()
        {
            Console.Write("Insira o nome do amigo: ");
            string nome = Console.ReadLine();
            Console.Write("Insira o nome do resposavel: ");
            string responsavel = Console.ReadLine();
            Console.Write("Insira o número de telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new(nome, responsavel, telefone);
            
            return amigo;
        }
    }
}
