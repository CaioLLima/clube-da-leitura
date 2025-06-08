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

        public Caixa(string etiqueta, string cor)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = 7;
        }
        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }
        public override string Validar()
        {
            string erros = string.Empty;

            if (string.IsNullOrWhiteSpace(Etiqueta) || Etiqueta.Length > 50)
                erros += "O campo \"Etiqueta\" é obrigatório e recebe no máximo 50 caracteres.";

            if (string.IsNullOrWhiteSpace(Cor))
                erros += "O campo \"Cor\" é obrigatório.";

            if (DiasEmprestimo < 1)
                erros += "O campo \"Dias de Empréstimo\" deve conter um valor maior que 0.";

            return erros;
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
