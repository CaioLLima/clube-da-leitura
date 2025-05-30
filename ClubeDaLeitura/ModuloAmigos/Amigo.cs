using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class Amigo : EntidadeBase
    {
        public int id;
        public string nome;
        public string responsavel;
        public string telefone;

        public Amigo(string nome, string responsavel, string telefone)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
        }
        public override void Validar()
        {

        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigo amigoAtualizado = (Amigo)registroAtualizado;

            this.nome = amigoAtualizado.nome;
            this.responsavel = amigoAtualizado.responsavel;
            this.telefone = amigoAtualizado.telefone;

        }

        public void ObterEmprestimos()
        {

        }
    }
}
