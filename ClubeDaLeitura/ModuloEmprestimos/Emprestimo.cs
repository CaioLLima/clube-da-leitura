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

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, string situacao)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.situacao = situacao;
        }
        public override string Validar()
        {
            return "";
        }
        public void ObterDataDevolucao()
        {

        }
        public void RegistrarDevolucao()
        {

        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {

        }
    }
}
