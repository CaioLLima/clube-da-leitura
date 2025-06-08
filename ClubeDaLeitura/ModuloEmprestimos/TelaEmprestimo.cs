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
        private RepositorioAmigo repositorioAmigo = new();
        public TelaEmprestimo(RepositorioEmprestimo repositorio, RepositorioAmigo repositorioAmigo,
            RepositorioRevista repositorioRevista) : base("Empréstimos", repositorio)
        {
            repositorioEmprestimo = repositorio;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
        }
        public override char SelecionarOperacao()
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
        public override EntidadeBase ObterDados()
        {
            VisualizarAmigos();

            Console.Write("Digite o ID do amigo que irá receber a revista: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorID(idAmigo);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nAmigo selecionado com sucesso!");
            Console.ResetColor();

            VisualizarRevistasDisponiveis();

            Console.Write("Digite o ID da revista que irá ser emprestada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorID(idRevista);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nRevista selecionada com sucesso!");
            Console.ResetColor();

            Emprestimo emprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

            return emprestimo;
        }
        public override void VisualizarRegistro()
        {
            Console.WriteLine("Empréstimos Cadastrados");
            Console.WriteLine(
           "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
           "Id", "Amigo", "Revista", "Data do Empréstimo", "Data Prev. Devolução", "Status"
            );
            EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarRegistros();

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = (Emprestimo)emprestimos[i];

                if (e == null)
                {
                    continue;
                }

                if (e.Status == "Atrasado")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo.ToShortDateString(), e.DataDevolucao.ToShortDateString(), e.Status
                );
                Console.ResetColor();
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        public void VisualizarAmigos()
        {
            Console.WriteLine("Amigos Cadastrados");
            Console.WriteLine(
            "{0, -5} | {1, -30} | {2, -30} | {3, -20}",
            "Id", "Nome", "Responsável", "Telefone"
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
                "{0, -5} | {1, -30} | {2, -30} | {3, -20}",
                a.Id, a.Nome, a.NomeResponsavel, a.Telefone
            );
            }

        }
        public void VisualizarRevistasDisponiveis()
        {
            Console.WriteLine("Revistas Cadastrados");
            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -15} | {5, -15}",
                "Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status"
            );
            EntidadeBase[] revistas = repositorioRevista.SelecionarRegistros();

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista r = (Revista)revistas[i];

                if (r == null)
                {
                    continue;
                }
                Console.WriteLine(
                    "{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -15} | {5, -15}",
                     r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status
                    );
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        private void VisualizarEmprestimosAtivos()
        {
            Console.WriteLine("Visualização de Empréstimos Ativos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                "Id", "Amigo", "Revista", "Data do Empréstimo", "Data Prev. Devolução", "Status"
            );

            EntidadeBase[] emprestimosAtivos = repositorioEmprestimo.SelecionarEmprestimosAtivos();

            for (int i = 0; i < emprestimosAtivos.Length; i++)
            {
                Emprestimo e = (Emprestimo)emprestimosAtivos[i];

                if (e == null)
                    continue;

                if (e.Status == "Atrasado")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                 "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                    e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo.ToShortDateString(), e.DataDevolucao.ToShortDateString(), e.Status
                );

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}
