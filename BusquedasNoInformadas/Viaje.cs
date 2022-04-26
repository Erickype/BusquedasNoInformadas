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
        public bool esViajeEsteril { get; set; }
        public bool seDesembarco { get; set; }

        public Viaje(Isla islaIzquierda, Isla islaDerecha, bool seDesembarco)
        {
            this.islaIzquierda = islaIzquierda;
            this.islaDerecha = islaDerecha;
            this.seDesembarco = seDesembarco;

            esViajeEsteril = false;
        }

        internal bool esSolucion()
        {
            if (islaDerecha.canibales == 3 && islaDerecha.misioneros == 3)
                return true;

            return false;
        }

        public List<Viaje?>? generarViajes()
        {
            List<Viaje?>? viajes = new ();
            List<Isla?>? posibilidadesIslas;

            if (estanMisionerosASalvo())
                return null;

            if(islaIzquierda.estaLaBarca)
            {
                if (seDesembarco)
                {
                    posibilidadesIslas = islaIzquierda.embarcar();

                    if (posibilidadesIslas != null)
                    {
                        viajes = viajar(posibilidadesIslas, true);
                        //seDesembarco = false;
                    }
                }
                else
                {
                    posibilidadesIslas = islaIzquierda.desembarcar();

                    if (posibilidadesIslas != null)
                    {
                        viajes = desembarcar(posibilidadesIslas, true);
                        //seDesembarco = true;
                    }
                }
                
            }
            else
            {
                if (seDesembarco)
                {
                    posibilidadesIslas = islaDerecha.embarcar();

                    if (posibilidadesIslas != null)
                    {
                        viajes = viajar(posibilidadesIslas, false);
                        //seDesembarco = false;
                    }
                }
                else
                {
                    posibilidadesIslas = islaDerecha.desembarcar();

                    if (posibilidadesIslas != null)
                    {
                        viajes = desembarcar(posibilidadesIslas, false);
                        //seDesembarco = true;
                    }
                }

            }            

            return viajes;
        }

        private List<Viaje?> desembarcar(List<Isla?> posibilidadesIslas, bool islaActual)
        {
            List<Viaje?>? viajes = new();
            Viaje aux;

            if (posibilidadesIslas == null)
                return viajes;

            foreach (var item in posibilidadesIslas)
            {
                if (item == null)
                {
                    viajes.Add(null);
                }
                else
                {
                    if (islaActual)
                    {
                        aux = new Viaje(item, new(islaDerecha.misioneros, islaDerecha.canibales, false), false);
                        aux.seDesembarco = true;
                    }
                    else
                    {
                        aux = new Viaje(new(islaIzquierda.misioneros, islaIzquierda.canibales, false), item, true);
                        aux.seDesembarco = true;
                    }

                    viajes.Add(aux);
                }
            }

            return viajes;
        }

        public List<Viaje?>? viajar(List<Isla?>? posibilidadesIslas, bool islaActual) //true izquierda, false derecha
        {
            List<Viaje?>? viajes = new();
            Viaje aux;

            if (posibilidadesIslas == null)
                return viajes;

            foreach (var item in posibilidadesIslas)
            {
                if (item == null)
                {
                    viajes.Add(null);
                }
                else
                {
                    item.estaLaBarca = false;

                    if (islaActual)
                    {
                        aux = new Viaje(item, new(islaDerecha.misioneros, islaDerecha.canibales, true), false);
                        if(aux.islaDerecha.barca != null && item.barca != null)
                        {
                            aux.islaDerecha.barca.canibales = item.barca.canibales;
                            aux.islaDerecha.barca.misioneros = item.barca.misioneros;
                            aux.islaIzquierda.barca = null;
                        }                        
                    }
                    else
                    {
                        aux = new Viaje(new(islaIzquierda.misioneros, islaIzquierda.canibales, true), item, false);

                        if (aux.islaIzquierda.barca != null && item.barca != null)
                        {
                            aux.islaIzquierda.barca.canibales = item.barca.canibales;
                            aux.islaIzquierda.barca.misioneros = item.barca.misioneros;
                            aux.islaDerecha.barca = null;
                        }                            
                    }

                    viajes.Add(aux);
                }
            }

            return viajes;
        }
        public bool estanMisionerosASalvo()
        {
            esViajeEsteril = true;

            if (islaDerecha.esEstadoPermitido() && islaIzquierda.esEstadoPermitido())
            {
                esViajeEsteril = false;
            }

            return esViajeEsteril;
        }
    }
}
