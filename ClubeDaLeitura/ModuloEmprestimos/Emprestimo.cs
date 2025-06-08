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
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Status { get; set; }

        public Emprestimo(Amigo amigo, Revista revista)
        {
            this.Amigo = amigo;
            this.Revista = revista;
            this.DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
            this.Status = "Aberto";
        }
        public override string Validar()
        {
            string erros = string.Empty;

            if (Amigo == null)
                erros += "O campo \"Amigo\" é obrigatório.";

            if (Revista == null)
                erros += "O campo \"Revista\" é obrigatório.";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Status = "Concluído";
        }
    }
}
