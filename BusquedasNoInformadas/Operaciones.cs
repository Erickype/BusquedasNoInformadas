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

        public Isla? sumar1M(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if ((isla.barca.canibales + isla.barca.misioneros + 1) <= 2 && isla.misioneros >= 1)
            {
                isla.barca.misioneros++;
                isla.misioneros--;
            }
            else
            {
                isla = null;
            }

            return isla;
        }
        public Isla? sumar2M(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if ((isla.barca.canibales + isla.barca.misioneros + 2) <= 2 && isla.misioneros >= 2)
            {
                isla.barca.misioneros += 2;
                isla.misioneros -= 2;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? sumar1C(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if ((isla.barca.canibales + isla.barca.misioneros + 1) <= 2  && isla.canibales >= 1)
            {
                isla.barca.canibales++;
                isla.canibales--;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? sumar2C(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if ((isla.barca.canibales + isla.barca.misioneros + 2) <= 2 && isla.canibales >= 2)
            {
                isla.barca.canibales += 2;
                isla.canibales -= 2;
            }
            else
            {
                isla = null;
            }
            return isla;
        }

        internal Isla? noSumar(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if ((isla.barca.canibales + isla.barca.misioneros) < 1)
            {
                isla = null;
            }
    
            return isla;
        }

        public Isla? sumar1M1C(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if (isla.barca.misioneros == 0 && isla.barca.canibales == 0 && isla.misioneros >= 1 && isla.canibales >= 1)
            {
                isla.barca.misioneros++;
                isla.barca.canibales++;
                isla.misioneros--;
                isla.canibales--;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? restar1M(Isla? isla) 
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if (isla.barca.misioneros >= 1)
            {
                isla.barca.misioneros--;
                isla.misioneros++;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? restar2M(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if (isla.barca.misioneros == 2)
            {
                isla.barca.misioneros -= 2;
                isla.misioneros += 2;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? restar1C(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if (isla.barca.canibales >= 1)
            {
                isla.barca.canibales--;
                isla.canibales++;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? restar2C(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if (isla.barca.canibales == 2)
            {
                isla.barca.canibales -= 2;
                isla.canibales += 2;
            }
            else
            {
                isla = null;
            }
            return isla;
        }
        public Isla? restar1M1C(Isla? isla)
        {
            if (isla == null)
                return isla;

            if (isla.barca == null)
                return isla;

            if (isla.barca.misioneros == 1 && isla.barca.canibales == 1)
            {
                isla.barca.misioneros--;
                isla.barca.canibales--;
                isla.misioneros++;
                isla.canibales++;
            }
            else
            {
                isla = null;
            }
            return isla;
        }

    }
}
