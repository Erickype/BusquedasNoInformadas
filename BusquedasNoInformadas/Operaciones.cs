using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class Operaciones
    {
        public Operaciones()
        {
        }

        public void sumar1M(Isla isla)
        {
            if (isla.barca == null)
                return;

            if (isla.barca.misioneros + 1 < 2 && isla.barca.canibales <= 1 && isla.misioneros >= 1)
            {
                isla.barca.misioneros++;
                isla.misioneros--;
            }
        }
        public void sumar2M(Isla isla)
        {
            if (isla.barca == null)
                return;

            if (isla.barca.misioneros == 0 && isla.barca.canibales == 0 && isla.misioneros >= 2)
            {
                isla.barca.misioneros += 2;
                isla.misioneros -= 2;
            }
        }
        public void sumar1C(Isla isla)
        {
            if (isla.barca == null)
                return;

            if (isla.barca.canibales + 1 < 2 && isla.barca.misioneros <= 1 && isla.canibales >= 1)
            {
                isla.barca.canibales++;
                isla.canibales--;
            }
        }
        public void sumar2C(Isla isla)
        {
            if (isla.barca == null)
                return;

            if (isla.barca.canibales == 0 && isla.barca.misioneros == 0 && isla.canibales >= 2)
            {
                isla.barca.canibales += 2;
                isla.canibales -= 2;
            }
        }
        public void sumar1M1C(Isla isla)
        {
            if (isla.barca == null)
                return;

            if (isla.barca.misioneros == 0 && isla.barca.canibales == 0 && isla.misioneros >= 1 && isla.canibales >= 1)
            {
                isla.barca.misioneros++;
                isla.barca.canibales++;
                isla.misioneros--;
                isla.canibales--;
            }
        }
        public void restar1M(Isla isla) { }
        public void restar2M(Isla isla) { }
        public void restar1C(Isla isla) { }
        public void restar2C(Isla isla) { }
        public void restar1M1C(Isla isla) { }

    }
}
