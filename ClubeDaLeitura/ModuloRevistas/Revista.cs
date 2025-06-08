using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class Revista : EntidadeBase
    {
        public int id;
        public string titulo;
        public string numEdicao;
        public string dataPublicacao;
        public Caixa caixa;
        public string statusEmprestimo;

        public Revista(string titulo, string numEdicao, string dataPublicacao, Caixa caixa)
        {
            this.titulo = titulo;
            this.numEdicao = numEdicao;
            this.dataPublicacao = dataPublicacao;
            this.caixa = caixa;
        }
        public override string Validar()
        {

            return "";
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Revista revistaAtualizado = (Revista)registroAtualizado;

            this.titulo = revistaAtualizado.titulo;
            this.numEdicao = revistaAtualizado.numEdicao;
            this.dataPublicacao = revistaAtualizado.dataPublicacao;
            this.caixa = revistaAtualizado.caixa;
            this.statusEmprestimo = "Disponível";

        }
        public void Emprestar()
        {
            statusEmprestimo = "Emprestada";
        }

    }
}
