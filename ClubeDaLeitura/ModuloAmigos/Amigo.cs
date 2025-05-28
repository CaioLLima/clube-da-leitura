using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class Amigo
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
        public void Validar()
        {

        }

        public void ObterEmprestimos()
        {

        }
    }
}
