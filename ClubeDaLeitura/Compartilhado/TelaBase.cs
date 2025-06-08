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
        public char SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine($"Controle de {nomeEntidade}");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine($"1 - Registrar {nomeEntidade}");
            Console.WriteLine($"2 - Editar {nomeEntidade}");
            Console.WriteLine($"3 - Visualizar {nomeEntidade}");
            Console.WriteLine($"4 - Excluir {nomeEntidade}");
            Console.WriteLine("S - Sair");

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }
        public void CadastrarRegistro()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de novo {nomeEntidade}");
            Console.WriteLine();
            EntidadeBase novoRegistro = ObterDados();

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

            repositorio.CadastrarRegistro(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }
        public void EditarRegistro()
        {
            Console.Clear();
            Console.WriteLine($"Edição de {nomeEntidade}");
            Console.WriteLine();

            VisualizarRegistro();

            Console.Write($"Insira o ID do {nomeEntidade} que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            EntidadeBase registroAtualizado = ObterDados();

            bool conseguiuEditar = repositorio.EditarRegistro(registroAtualizado, idSelecionado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ReadLine();
        }
        public void ExcluirRegistro()
        {
            Console.WriteLine($"Exclusão de {nomeEntidade}\n");

            VisualizarRegistro();

            Console.Write($"Insira o ID do {nomeEntidade} que deseja deletar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            repositorio.ExcluirRegistro(idSelecionado);
        }
        public abstract void VisualizarRegistro();
        public abstract EntidadeBase ObterDados();

    }
}
