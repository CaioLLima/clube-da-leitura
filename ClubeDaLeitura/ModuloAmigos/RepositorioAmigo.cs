using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
