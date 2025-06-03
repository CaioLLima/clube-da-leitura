using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    public class Emprestimo : EntidadeBase
    {
        public int id;
        public Amigo amigo;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public string situacao;

        public Emprestimo(Amigo amigo, Revista revista, string situacao)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.situacao = situacao;
        }
        public override void Validar()
        {

        }
        public void ObterDataDevolucao()
        {

        }
        public void RegistrarDevolucao()
        {

        }
    }
}
