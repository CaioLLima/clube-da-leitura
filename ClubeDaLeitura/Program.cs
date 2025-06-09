using ClubeDaLeitura.Compartilhado;
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
            TelaPrincipal telaPrincipal = new();

            Console.WriteLine("Trabalho 02 - Clube da leitura");

            while (true)
            {
                telaPrincipal.ApresentarMenuPrincipal();

                TelaBase telaEscolhida = telaPrincipal.ObterTela();

                if (telaEscolhida == null)
                    break;

                char opcaoEscolhida = telaEscolhida.SelecionarOperacao();

                if (opcaoEscolhida == 'S' || opcaoEscolhida == 's')
                    break;

                if (telaEscolhida is TelaEmprestimo)
                {
                    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaEscolhida;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaEmprestimo.CadastrarEmprestimo();
                            break;

                        case '2':
                            telaEmprestimo.DevolverEmprestimo();
                            break;

                        case '3':
                            telaEmprestimo.VisualizarRegistro();
                            break;
                    }
                }
                else
                {
                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaEscolhida.CadastrarRegistro();
                            break;

                        case '2':
                            telaEscolhida.VisualizarRegistro();
                            break;

                        case '3':
                            telaEscolhida.EditarRegistro();
                            break;

                        case '4':
                            telaEscolhida.ExcluirRegistro();
                            break;
                    }
                }
            }
        }
    }
}
