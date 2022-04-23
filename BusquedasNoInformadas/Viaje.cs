using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Viaje
    {
        public Isla islaIzquierda { get; set; }
        public Isla islaDerecha { get; set; }

        public bool estadoImposibleViaje { get; set; }

        public Viaje(Isla islaIzquierda)
        {
            this.islaIzquierda = islaIzquierda;
            islaDerecha = new Isla(0, 0);
            islaDerecha.estaLaBarca = false;
            estadoImposibleViaje = false;
        }

        internal bool esSolucion()
        {
            if (islaDerecha.canibales == 3 && islaDerecha.misioneros == 3)
                return true;

            return false;
        }

        public List<Viaje> generarViajes()
        {
            List<Viaje> viajes = new ();

            if(islaIzquierda.estaLaBarca)
            {   
                islaIzquierda.embarcar();
            }
            else
            {
                islaDerecha.embarcar();
            }

            return viajes;
        }

        public bool estanMisionerosASalvo()
        {
            if (islaDerecha.esEstadoPermitido() && islaIzquierda.esEstadoPermitido())
                return true;
            return false;
        }
    }
}
