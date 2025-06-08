using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;

namespace ClubeDaLeitura.ModuloCaixas
{
    public class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }
        public override string Validar()
        {
            return "";
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Caixa amigoAtualizado = (Caixa)registroAtualizado;

            this.Etiqueta = amigoAtualizado.Etiqueta;
            this.Cor = amigoAtualizado.Cor;
            this.DiasEmprestimo = amigoAtualizado.DiasEmprestimo;

        }

    }
}
