using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigos;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class RepositorioBase
    {
        public int contadorRegistros = 0;
        public EntidadeBase[] registros = new EntidadeBase[100];

        public void CadastrarRegistro(EntidadeBase registro)
        {
            registro.Id = contadorRegistros;
            registros[contadorRegistros] = registro;
            contadorRegistros++;
        }
        public bool EditarRegistro(EntidadeBase registroAtualizado, int idSelecionado)
        {
            EntidadeBase registro = SelecionarRegistroPorID(idSelecionado);

            if (registro == null)
            {
                return false;
            }
            registro.AtualizarRegistro(registroAtualizado);
            return true;
        }
        public bool ExcluirRegistro(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].Id == idSelecionado)
                {
                    registros[i] = null;

                    return true;
                }
            }

            return false;
        }
        public EntidadeBase[] SelecionarRegistros()
        {
            return registros;
        }
        public EntidadeBase SelecionarRegistroPorID(int idSlecionado)
        {
            return registros[idSlecionado];
        }
    }
}
