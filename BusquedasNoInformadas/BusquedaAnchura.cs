using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class BusquedaAnchura
    {
        public Nodo nodoRaiz { get; set; }
        public Arbol arbol;

        public BusquedaAnchura(Isla islaIzquierda)
        {      
            nodoRaiz = new(new Viaje(islaIzquierda));
            arbol = new Arbol(nodoRaiz);
        }

        public Arbol busquedaAnchura()
        {
            Nodo nodoActual;
            Queue<Nodo> nodosFrontera = new(); //Nodos por visitar
            List<Nodo> nodosVisitados = new();

            nodosFrontera.Enqueue(nodoRaiz);
            nodoActual = nodoRaiz;

            while (nodosFrontera.Count > 0 && !esSolucion(nodoActual))
            {
                nodoActual = nodosFrontera.Peek();

                nodosVisitados.Add(nodoActual);

                nodoActual.generarHijos();
            }

            return arbol;
        }

        private bool esSolucion(Nodo nodoActual)
        {
            return nodoActual.esSolucion();
        }
    }
}
