// See https://aka.ms/new-console-template for more information

using BusquedasNoInformadas;

//Instanciacion de clase WFS
BusquedaAnchura busquedaAnchura = new(new Isla(3, 3, true), new Isla(0, 0, false));

//Instanciacion de clase DFS
BusquedaProfundidad busquedaProfundidad = new(new Isla(3, 3, true), new Isla(0, 0, false));

//invocacion metodo busqueda WFS
//Nodo nodoSolucion = busquedaAnchura.busquedaAnchura();

//invocacion metodo busqueda DFS
Nodo nodoSolucion = busquedaProfundidad.busquedaProfundidad();

int pasos = nodoSolucion.imprimirArbol();

Console.WriteLine("\nSolución en " + pasos + " pasos.");


