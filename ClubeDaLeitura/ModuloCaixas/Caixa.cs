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
        public int id;
        public string etiqueta;
        public string cor;
        public string diasEmprestimo;

        public Caixa(string etiqueta, string cor, string diasEmprestimo)
        {
            this.etiqueta = etiqueta;
            this.cor = cor;
            this.diasEmprestimo = diasEmprestimo;
        }
        public override void Validar()
        {

        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Caixa amigoAtualizado = (Caixa)registroAtualizado;

            this.etiqueta = amigoAtualizado.etiqueta;
            this.cor = amigoAtualizado.cor;
            this.diasEmprestimo = amigoAtualizado.diasEmprestimo;

        }

        public void ObterEmprestimos()
        {

        }
    }
}
