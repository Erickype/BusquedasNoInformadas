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

        public Isla(byte misioneros, byte canibales, bool estaLaBarca)
        {
            this.misioneros = misioneros;
            this.canibales = canibales;
            this.estaLaBarca = estaLaBarca;
            if (estaLaBarca)
            {
                barca = new(0, 0);
            }
            operaciones = new();
        }

        public List<Isla?>? embarcar()
        {
            List<Isla?>? islas = new();            

            if (!estaLaBarca)
                return null;

            if (barca == null)
                return null;

            for (int i = 0; i < 6; i++)
            {
                Isla? aux = new(misioneros, canibales, true);
                aux.barca = new Barca(barca.misioneros, barca.canibales);

                switch (i)
                {
                    case 0:
                        aux = operaciones.sumar1M(aux);
                        break;
                    case 1:
                        aux = operaciones.sumar2M(aux);
                        break;
                    case 2:
                        aux = operaciones.sumar1C(aux);
                        break;
                    case 3:
                        aux = operaciones.sumar2C(aux);
                        break;
                    case 4:
                        aux = operaciones.sumar1M1C(aux);
                        break;
                    default:
                        aux = operaciones.noSumar(aux);
                        break;
                }

                if(aux != null)
                {
                    if (aux.esEstadoPermitido())
                    {
                        islas.Add(aux);
                    }
                    else
                    {
                        islas.Add(item: null);
                    }
                }
                else
                {
                    islas.Add(item: null);
                }                
            }

            return islas;
        }

        public List<Isla?>? desembarcar()
        {
            List<Isla?>? islas = new();

            if (!estaLaBarca)
                return null;

            if (barca == null)
                return null;

            for (int i = 0; i < 5; i++)
            {
                Isla? aux = new(misioneros, canibales, true);
                aux.barca = new Barca(barca.misioneros, barca.canibales);

                switch (i)
                {
                    case 0:
                        aux = operaciones.restar1M(aux);
                        break;
                    case 1:
                        aux = operaciones.restar2M(aux);
                        break;
                    case 2:
                        aux = operaciones.restar1C(aux);
                        break;
                    case 3:
                        aux = operaciones.restar2C(aux);
                        break;
                    case 4:
                        aux = operaciones.restar1M1C(aux);
                        break;
                }

                if (aux != null)
                {
                    if (aux.esEstadoPermitido())
                    {
                        islas.Add(aux);
                    }
                    else
                    {
                        islas.Add(item: null);
                    }
                }
                else
                {
                    islas.Add(item: null);
                }
            }

            return islas;
        }

        public bool esEstadoPermitido()
        {
            if (misioneros >= canibales || (misioneros == 0 && canibales != 0 ))
                return true;
            return false;
        }
    }
}
