using ClubeDaLeitura.ModuloAmigos;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new();

            Console.WriteLine("Trabalho 02 - Clube da leitura");

            while(true)
            {
                char opcaoMenuPrincipal = ApresentarMenuPrincipal();

                if (opcaoMenuPrincipal == 'S') break;

                switch (opcaoMenuPrincipal)
                {
                    case '1': telaAmigo.SelecionarOperacao(); break;
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
