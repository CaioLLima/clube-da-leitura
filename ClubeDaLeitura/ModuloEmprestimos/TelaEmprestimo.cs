using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    public class TelaEmprestimo : TelaBase
    {
        private RepositorioEmprestimo repositorioEmprestimo = new();
        private RepositorioRevista repositorioRevista = new();
        private RepositorioCaixa repositorioCaixa = new();
        private RepositorioAmigo repositorioAmigo = new();
        public TelaEmprestimo(RepositorioEmprestimo repositorioE, RepositorioAmigo repositorioA, 
            RepositorioRevista repositorioR, RepositorioCaixa repositorioC) : base("Empréstimos", repositorioE)
        {
            repositorioEmprestimo = repositorioE;
            repositorioRevista = repositorioR;
            repositorioCaixa = repositorioC;
            repositorioAmigo = repositorioA;
        }
        public char SelecionarOperacaoEmprestimo()
        {
            Console.Clear();
            Console.WriteLine($"Controle de {nomeEntidade}");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine($"1 - Registrar um empréstimo");
            Console.WriteLine($"2 - Registrar uma devolução");
            Console.WriteLine($"3 - Visualizar empréstimos em aberto");
            Console.WriteLine("S - Sair");

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }
        public override void VisualizarRegistro()
        {
            Console.WriteLine("Empréstimos Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -10} | {5 -10}",
                "ID", "Amigo", "Revista", "Data Empréstimo", "Data Devolução", "Status"
            );
            EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarRegistros();

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo a = (Emprestimo)emprestimos[i];

                if (a == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -10} | {5, -10}",
                a.id, a.amigo.Nome, a.revista.titulo, a.dataEmprestimo, a.dataDevolucao, a.revista.statusEmprestimo
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        public void VisualizarAmigos()
        {
            Console.WriteLine("Amigos Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Nome", "Responsável", "Telefone"
            );
            EntidadeBase[] amigos = repositorioAmigo.SelecionarRegistros();

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = (Amigo)amigos[i];

                if (a == null)
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                a.Id, a.Nome, a.NomeResponsavel, a.Telefone
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        public void VisualizarRevistas()
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
                a.id, a.titulo, a.numEdicao, a.dataPublicacao, a.statusEmprestimo, a.caixa.Etiqueta
            );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        public Emprestimo RegistrarEmprestimo()
        {
            Console.WriteLine("Lista de Amigos");
            VisualizarAmigos();
            Console.Write("Insira o ID do Amigo que pegará a revista: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lista de revistas");
            VisualizarRevistas();
            Console.Write("Insira o ID da revista que será emprestada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insira o dia do empréstimo: ");
            DateTime dataEmprestimo = DateTime.Today;

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorID(idAmigo);
            Revista revistaSelecionado = (Revista)repositorioRevista.SelecionarRegistroPorID(idRevista);

            revistaSelecionado.Emprestar();

            Emprestimo emprestimo = new(amigoSelecionado, revistaSelecionado, dataEmprestimo, "Aberto");

            return emprestimo;
        }
        public Emprestimo RegistrarDevolucao()
        {
            return null;
        }
        public override Emprestimo ObterDados()
        {
            return null;
        }
    }
}
