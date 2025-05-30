using ClubeDaLeitura.ModuloAmigos;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new();
            TelaAmigo telaAmigo = new(repositorioAmigo);
            Console.WriteLine("Trabalho 02 - Clube da leitura");

            while (true)
            {
                char opcaoMenuPrincipal = ApresentarMenuPrincipal();

                if (opcaoMenuPrincipal == 'S') break;

                switch (opcaoMenuPrincipal)
                {
                    case '1':
                        char opcaoEscolhida = telaAmigo.SelecionarOperacao();

                        switch (opcaoEscolhida)
                        {
                            case '1':
                                telaAmigo.CadastrarRegistro();
                                break;
                            case '2':
                                telaAmigo.EditarRegistro();
                                break;
                            case '3':
                                telaAmigo.VisualizarRegistro();
                                break;
                            case '4':
                                telaAmigo.ExcluirRegistro();
                                break;
                            case 'S':     
                                break;
                        }
                        break;
                }
            }
        }

        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Qual opção deseja selecionar?");
            Console.WriteLine("1 - Controle de Amigos");
            Console.WriteLine("2 - Controle de Revistas");
            Console.WriteLine("3 - Controle de Caixas");
            Console.WriteLine("4 - Controle de Empréstimos");
            Console.WriteLine("S - Sair");
            char opcao = Console.ReadLine().ToUpper()[0];
            return opcao;
        }
    }
}
