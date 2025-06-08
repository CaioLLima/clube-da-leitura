using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using Microsoft.Win32;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class TelaAmigo : TelaBase
    {
        public TelaAmigo(RepositorioAmigo repositorio) : base("Amigo", repositorio)
        {
        }
        public override void CadastrarRegistro()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de novo {nomeEntidade}");
            Console.WriteLine();
            Amigo novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                CadastrarRegistro();

                return;
            }

            EntidadeBase[] registros = repositorio.SelecionarRegistros();

            for (int i = 0; i < registros.Length; i++)
            {
                Amigo amigoRegistrado = (Amigo)registros[i];

                if (amigoRegistrado == null)
                    continue;

                if (amigoRegistrado.Nome == novoRegistro.Nome || amigoRegistrado.Telefone == novoRegistro.Telefone)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    CadastrarRegistro();
                    return;
                }
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }
        public override void EditarRegistro()
        {

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistro();

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Amigo registroAtualizado = (Amigo)ObterDados();

            string erros = registroAtualizado.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                EditarRegistro();

                return;
            }

            EntidadeBase[] registros = repositorio.SelecionarRegistros();

            for (int i = 0; i < registros.Length; i++)
            {
                Amigo amigoRegistrado = (Amigo)registros[i];

                if (amigoRegistrado == null)
                    continue;

                if (
                    amigoRegistrado.Id != idSelecionado &&
                    (amigoRegistrado.Nome == registroAtualizado.Nome ||
                    amigoRegistrado.Telefone == registroAtualizado.Telefone)
                )
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    EditarRegistro();

                    return;
                }
            }

            repositorio.EditarRegistro(registroAtualizado, idSelecionado);

            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ReadLine();
        }

        public override void VisualizarRegistro()
        {
            Console.WriteLine("Amigos Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Nome", "Responsável", "Telefone"
            );
            EntidadeBase[] amigos = repositorio.SelecionarRegistros();

            for(int i = 0; i < amigos.Length; i++)
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
