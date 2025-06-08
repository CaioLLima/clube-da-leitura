using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }

        public Amigo(string nome, string nomeResponsavel, string telefone)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
        }
        public override string Validar()
        {
            string erros = string.Empty;

            if (Nome.Length <= 3 || Nome.Length >= 100)
                erros += "O campo \"Nome\" precisa conter no mínimo 3 caracteres.\n";

            if (NomeResponsavel.Length <= 3 || NomeResponsavel.Length >= 100)
                erros += "O campo \"Responsavel\" precisa conter no mínimo 3 caracteres.\n";

            if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
                erros += "O campo \"Telefone\" deve seguir o padrão (DDD) 90000-0000.";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigo amigoAtualizado = (Amigo)registroAtualizado;

            Nome = amigoAtualizado.Nome;
            NomeResponsavel = amigoAtualizado.NomeResponsavel;
            Telefone = amigoAtualizado.Telefone;

        }

        public void ObterEmprestimos()
        {

        }
    }
}
