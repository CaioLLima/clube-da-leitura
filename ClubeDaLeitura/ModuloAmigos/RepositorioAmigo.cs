using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class RepositorioAmigo
    {
        public int contador = 0;
        public Amigo[] amigos = new Amigo[100];

        public void CadastrarRegistro(Amigo amigo)
        {
            amigo.id = contador;
            amigos[contador] = amigo;
            contador++;
        }
        public bool EditarRegistro(Amigo amigoAtualizado, int idSelecionado)
        {
            Amigo amigo = SelecionarRegistroPorID(idSelecionado);

            if (amigo == null)
            {
                return false;
            }
            amigo.AtualizarRegistro(amigoAtualizado);
            return true;
        }
        public bool ExcluirRegistro(int idSelecionado)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                if (amigos[i].id == idSelecionado)
                {
                    amigos[i] = null;

                    return true;
                }
            }

            return false;
        }
        public Amigo[] SelecionarRegistros()
        {

            return amigos;
        }
        public Amigo SelecionarRegistroPorID(int idSlecionado)
        {
            return amigos[idSlecionado];
        }
    }
}
