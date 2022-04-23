using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Arbol
    {
        public Nodo Raiz { get; set; }

        public Arbol(Nodo padre)
        {
            Raiz = padre;
        }
    }
}
