// See https://aka.ms/new-console-template for more information

using BusquedasNoInformadas;

//Instanciacion de clase DFS
BusquedaAnchura busquedaAnchura = new(new Isla(3, 3, true), new Isla(0, 0, false));

//invocacion metodo busqueda DFS
//Arbol arbol = busquedaAnchura.busquedaAnchura();
Nodo nodoSolucion = busquedaAnchura.busquedaAnchura();

//Console.WriteLine(nodoSolucion.imprimirNodo());
int pasos = nodoSolucion.imprimirArbol();

Console.WriteLine("\nSolución en "+pasos+" pasos.")


