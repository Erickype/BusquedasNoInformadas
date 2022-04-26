using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Nodo
    {
        public Viaje? viaje { get; set; }
        public bool esNodoEsteril { get; set; } //true nodo esteril

        public List<Nodo?>? hijos = null;

        public Nodo? padre = null;

        public Nodo(Viaje viaje)
        {
            this.viaje = viaje;
            esNodoEsteril = false;
        }
        public Nodo()
        {
            esNodoEsteril = true;
        }

        public void setHijos(List<Nodo?>? hijos)
        {
            if (hijos == null)
                return;

            this.hijos = hijos;

            if (this.hijos != null)
            {
                foreach (var item in hijos)
                {
                    if (item == null)
                    {
                        Nodo aux = new();
                        aux.padre = this;
                    }
                    else
                    {
                        item.padre = this;
                    }
                }
            }
        }

        public bool esSolucion()
        {
            if (esNodoEsteril)
            {
                return false;
            }

            if (viaje == null)
                return false;

            return viaje.esSolucion();
        }

        internal List<Nodo?>? getHijos()
        {
            return hijos;
        }

        public void generarHijos()
        {
            if (viaje == null)
                return;

            List<Viaje?>? viajes = viaje.generarViajes();
            List<Nodo?>? hijos = new();

            if (viajes == null)
                return;

            foreach (var item in viajes)
            {
                if (item != null)
                {
                    hijos.Add(new Nodo(item));
                    esNodoEsteril = item.esViajeEsteril;
                }
            }

            if(hijos.Count == 0)
            {
                setHijos(null);
            }
            else
            {
                setHijos(hijos);
            }
        }

        public string imprimirNodo()
        {
            string result = "";

            result += "\nISLA IZQUIERDA\n";
            result += "\tMisioneros: " + viaje.islaIzquierda.misioneros + " Canibales: " + viaje.islaIzquierda.canibales + "\n";
            if(viaje.islaIzquierda.barca != null)
            {
                result += "  *Barca\n";
                result += "\tMisioneros:"+viaje.islaIzquierda.barca.misioneros+ " Canibales:" + viaje.islaIzquierda.barca.canibales+"\n";
            }

            result += "\nISLA DERECHA\n";
            result += "\tMisioneros: " + viaje.islaDerecha.misioneros + " Canibales: " + viaje.islaDerecha.canibales + "\n";
            if (viaje.islaDerecha.barca != null)
            {
                result += "  *Barca\n";
                result += "\tMisioneros: " + viaje.islaDerecha.barca.misioneros + " Canibales: " + viaje.islaDerecha.barca.canibales + "\n";
            }

            return result;
        }

        public int imprimirArbol()
        {
            List<string> nodosS = new();
            Nodo aux = (Nodo)MemberwiseClone();

            while (aux.padre != null)
            {
                nodosS.Add(aux.imprimirNodo());
                aux = aux.padre;
            }

            nodosS.Add(aux.imprimirNodo());
            nodosS.Reverse();

            foreach (var item in nodosS)
            {
                Console.WriteLine(item);
            }

            return nodosS.Count();
        }
    }
}
