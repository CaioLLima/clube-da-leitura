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

        public void SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine("Controle de Amigos");
            Console.WriteLine();
            Console.WriteLine("Qual opção deseja selecionar? \n 1 - Cadastrar Amigo\n 2 - Editar Amigo" +
                "\n 3 - Visualização de Amigos\n 4 - Excluir Amigo");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1: CadastrarRegistro(); break;
                case 2: EditarRegistro(); break;
                case 3: VisualizarRegistro(); break;
                case 4: ExcluirRegistro(); break;
            }
        }
        public void CadastrarRegistro()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de novo Amigo");
            Console.WriteLine();
            Amigo amigo = ObterDados();

            repositorioAmigo.CadastrarRegistro(amigo);
        }
        public void EditarRegistro()
        {
            Console.Clear();
            Console.WriteLine("Edição de Amigo");
            Console.WriteLine();

            VisualizarRegistro();

            Console.Write("Insira o ID do amigo que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Amigo amigoAtualizado = ObterDados();

            bool conseguiuEditar = repositorioAmigo.EditarRegistro(amigoAtualizado, idSelecionado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nEquipamento \"{amigoAtualizado.nome}\" editado com sucesso!");
            Console.ReadLine();
        }
        public void VisualizarRegistro()
        {
            Console.WriteLine("Amigos Cadastrados");
            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Nome", "Responsável", "Telefone"
            );
            Amigo[] amigos = repositorioAmigo.SelecionarRegistros();

            for(int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                if (a == null) 
                {
                    continue;
                }
                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                a.id, a.nome, a.responsavel, a.telefone
            );
            }

        }
        public void ExcluirRegistro()
        {
            Console.WriteLine("Exclusão de amigo\n");

            VisualizarRegistro();

            Console.Write("Insira o ID do amigo que deseja deletar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            repositorioAmigo.ExcluirRegistro(idSelecionado);
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
