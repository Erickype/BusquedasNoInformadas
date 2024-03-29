﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedasNoInformadas
{
    internal class BusquedaAnchura//niveles 
    {
        public Nodo nodoRaiz { get; set; }
        Queue<Nodo> nodosFrontera = new(); //Nodos por visitar
        List<Nodo> nodosVisitados = new();

        public BusquedaAnchura(Isla islaIzquierda, Isla islaDerecha)
        {      
            nodoRaiz = new(new Viaje(islaIzquierda, islaDerecha, true));
        }

        public Nodo busquedaAnchura()
        {
            Nodo nodoActual;            

            nodoActual = nodoRaiz;
            nodosFrontera.Enqueue(nodoActual);

            while (nodosFrontera.Count > 0 && !esSolucion(nodoActual))
            {
                nodoActual = nodosFrontera.Dequeue();

                nodosVisitados.Add(nodoActual);

                nodoActual.generarHijos();

                encolarHijos(nodoActual);                
            } 

            return nodoActual;
        }

        private void encolarHijos(Nodo nodoActual)
        {
            List<Nodo?>? hijos = nodoActual.getHijos();

            if(hijos != null)
            {
                foreach (var item in hijos)
                {
                    if(item != null)
                    {
                        if(queNoSeRepitaNodo(item))
                        {
                            nodosFrontera.Enqueue(item);
                        }
                        else
                        {
                            item.esNodoEsteril = true;//que no se cicle el arbol
                        }                        
                    }
                }
            }
        }

        private bool queNoSeRepitaNodo(Nodo nodo)
        {
            bool respuesta = true;
            byte c = 0;

            if (nodo.viaje != null)
            {
                foreach (var item in nodosFrontera)
                {
                    if(item.viaje != null)
                    {
                        if (item.viaje.seDesembarco == nodo.viaje.seDesembarco)
                            c++;
                        if (item.viaje.islaIzquierda.misioneros == nodo.viaje.islaIzquierda.misioneros)
                            c++;
                        if (item.viaje.islaIzquierda.canibales == nodo.viaje.islaIzquierda.canibales)
                            c++;
                        if (item.viaje.islaIzquierda.barca != null && nodo.viaje.islaIzquierda.barca != null)
                        {
                            if (item.viaje.islaIzquierda.barca.misioneros == nodo.viaje.islaIzquierda.barca.misioneros)
                                c++;
                            if (item.viaje.islaIzquierda.barca.canibales == nodo.viaje.islaIzquierda.barca.canibales)
                                c++;
                        }

                        if (item.viaje.islaDerecha.misioneros == nodo.viaje.islaDerecha.misioneros)
                            c++;
                        if (item.viaje.islaDerecha.canibales == nodo.viaje.islaDerecha.canibales)
                            c++;
                        if (item.viaje.islaDerecha.barca != null && nodo.viaje.islaDerecha.barca != null)
                        {
                            if (item.viaje.islaDerecha.barca.misioneros == nodo.viaje.islaDerecha.barca.misioneros)
                                c++;
                            if (item.viaje.islaDerecha.barca.canibales == nodo.viaje.islaDerecha.barca.canibales)
                                c++;
                        }

                        if (c == 7)
                        {
                            respuesta = false;
                            return respuesta;
                        }
                        else
                        {
                            c = 0;
                        }
                    }                    
                }

            }

            if (nodo.viaje != null)
            {
                foreach (var item in nodosVisitados)
                {
                    if (item.viaje != null)
                    {
                        if (item.viaje.seDesembarco == nodo.viaje.seDesembarco)
                            c++;
                        if (item.viaje.islaIzquierda.misioneros == nodo.viaje.islaIzquierda.misioneros)
                            c++;
                        if (item.viaje.islaIzquierda.canibales == nodo.viaje.islaIzquierda.canibales)
                            c++;
                        if (item.viaje.islaIzquierda.barca != null && nodo.viaje.islaIzquierda.barca != null)
                        {
                            if (item.viaje.islaIzquierda.barca.misioneros == nodo.viaje.islaIzquierda.barca.misioneros)
                                c++;
                            if (item.viaje.islaIzquierda.barca.canibales == nodo.viaje.islaIzquierda.barca.canibales)
                                c++;
                        }

                        if (item.viaje.islaDerecha.misioneros == nodo.viaje.islaDerecha.misioneros)
                            c++;
                        if (item.viaje.islaDerecha.canibales == nodo.viaje.islaDerecha.canibales)
                            c++;
                        if (item.viaje.islaDerecha.barca != null && nodo.viaje.islaDerecha.barca != null)
                        {
                            if (item.viaje.islaDerecha.barca.misioneros == nodo.viaje.islaDerecha.barca.misioneros)
                                c++;
                            if (item.viaje.islaDerecha.barca.canibales == nodo.viaje.islaDerecha.barca.canibales)
                                c++;
                        }

                        if (c == 7)
                        {
                            respuesta = false;
                            return respuesta;
                        }
                        else
                        {
                            c = 0;
                        }
                    }
                }

            }

            return respuesta;
        }

        private bool esSolucion(Nodo nodoActual)
        {
            return nodoActual.esSolucion();
        }
    }
}
