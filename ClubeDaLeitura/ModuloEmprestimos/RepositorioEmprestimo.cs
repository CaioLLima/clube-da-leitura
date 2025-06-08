using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    public class RepositorioEmprestimo : RepositorioBase
    {
        public Emprestimo[] SelecionarEmprestimosAtivos()
        {
            int contadorEmprestimosAtivos = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo emprestimoAtual = (Emprestimo)registros[i];

                if (emprestimoAtual == null)
                    continue;

                if (emprestimoAtual.Status == "Aberto" || emprestimoAtual.Status == "Atrasado")
                    contadorEmprestimosAtivos++;
            }

            Emprestimo[] emprestimosAtivos = new Emprestimo[contadorEmprestimosAtivos];

            int contadorAuxiliar = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo emprestimoAtual = (Emprestimo)registros[i];

                if (emprestimoAtual == null)
                    continue;

                if (emprestimoAtual.Status == "Aberto" || emprestimoAtual.Status == "Atrasado")
                {
                    emprestimosAtivos[contadorAuxiliar++] = (Emprestimo)registros[i];
                }
            }

            return emprestimosAtivos;
        }
    }
}
