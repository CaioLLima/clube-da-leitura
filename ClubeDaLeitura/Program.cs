using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmprestimos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new();
            RepositorioRevista repositorioRevista = new();
            RepositorioCaixa repositorioCaixa = new();
            RepositorioEmprestimo repositorioEmprestimo = new();

            TelaAmigo telaAmigo = new(repositorioAmigo);
            TelaCaixa telaCaixa = new(repositorioCaixa);
            TelaRevista telaRevista = new(repositorioRevista, repositorioCaixa);
            TelaEmprestimo telaEmprestimo = new(repositorioEmprestimo, repositorioAmigo, repositorioRevista, repositorioCaixa);
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
                    case '2':
                        opcaoEscolhida = telaCaixa.SelecionarOperacao();

                        switch (opcaoEscolhida)
                        {
                            case '1':
                                telaCaixa.CadastrarRegistro();
                                break;
                            case '2':
                                telaCaixa.EditarRegistro();
                                break;
                            case '3':
                                telaCaixa.VisualizarRegistro();
                                break;
                            case '4':
                                telaCaixa.ExcluirRegistro();
                                break;
                            case 'S':
                                break;
                        }
                        break;
                    case '3':
                        opcaoEscolhida = telaRevista.SelecionarOperacao();

                        switch (opcaoEscolhida)
                        {
                            case '1':
                                telaRevista.CadastrarRegistro();
                                break;
                            case '2':
                                telaRevista.EditarRegistro();
                                break;
                            case '3':
                                telaRevista.VisualizarRegistro();
                                break;
                            case '4':
                                telaRevista.ExcluirRegistro();
                                break;
                            case 'S':
                                break;
                        }
                        break;
                    case '4':
                        opcaoEscolhida = telaEmprestimo.SelecionarOperacaoEmprestimo();

                        switch (opcaoEscolhida)
                        {
                            case '1':
                                telaEmprestimo.RegistrarEmprestimo();
                                break;
                            case '2':
                                telaRevista.EditarRegistro();
                                break;
                            case '3':
                                telaEmprestimo.VisualizarRegistro();
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
            Console.WriteLine("2 - Controle de Caixas");
            Console.WriteLine("3 - Controle de Revistas");
            Console.WriteLine("4 - Controle de Empréstimos");
            Console.WriteLine("S - Sair");
            char opcao = Console.ReadLine().ToUpper()[0];
            return opcao;
        }
    }
}
