using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Isla
    {
        public byte misioneros { get; set; }
        public byte canibales { get; set; }
        public Barca? barca { get; set; }
        public bool estaLaBarca { get; set; }
        public Operaciones operaciones { get; set; }

        public Isla(byte misioneros, byte canibales)
        {
            this.misioneros = misioneros;
            this.canibales = canibales;
            estaLaBarca = true;
            operaciones = new();
        }

        public List<Isla>? embarcar()
        {
            List<Isla> islas = new();

            if (!estaLaBarca)
                return null;

            //1M

            

            //2M
            

            //1C
            if (barca.canibales + 1 <= 2)
                barca.canibales++;

            //2C
            if (barca.canibales + 1 <= 2)
                barca.canibales++;

            //1M 1C
            if (barca.canibales + 1 <= 2 )
                barca.canibales++;

            return islas;
        }

        public bool esEstadoPermitido()
        {
            if (misioneros >= canibales)
                return true;
            return false;
        }
    }
}
