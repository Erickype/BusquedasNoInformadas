// See https://aka.ms/new-console-template for more information

using BusquedasNoInformadas;

//Instanciacion de clase DFS
BusquedaAnchura busquedaAnchura = new(new Isla(3, 3));

//invocacion metodo busqueda DFS
Arbol arbol = busquedaAnchura.busquedaAnchura();

Console.WriteLine(arbol);
