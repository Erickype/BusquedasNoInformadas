using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Nodo
    {
        public Viaje viaje { get; set; }
        public bool esNodoEsteril { get; set; } //true nodo esteril

        public List<Nodo>? hijos = null;

        public Nodo? padre = null;

        public Nodo(Viaje viaje)
        {
            this.viaje = viaje;
            esNodoEsteril = false;
        }

        public void setHijos(List<Nodo> hijos)
        {
            this.hijos = hijos;

            if (this.hijos != null)
            {
                foreach (Nodo nodo in this.hijos)
                {
                    nodo.padre = this;
                }
            }
        }

        public bool esSolucion()
        {
            if (esNodoEsteril)
            {
                return false;
            }

            return viaje.esSolucion();
        }

        public void generarHijos()
        {
            List<Viaje> viajes = viaje.generarViajes();
            List<Nodo> hijos = new ();

            foreach (var item in viajes)
            {
                hijos.Add(new Nodo(item));
                esNodoEsteril = item.estadoImposibleViaje;
            }

            setHijos(hijos);
        }
    }
}
