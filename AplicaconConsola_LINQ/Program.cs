LinqQueries queries = new LinqQueries();


Console.WriteLine("===================Coleccion de libros completa=======================");
ImprimirValores(queries.TodaLaColeccion());
Console.WriteLine("===================Libros publicados despues del 2000=======================");
ImprimirValores(queries.librosDespues2000());
Console.WriteLine("===================Libros que cumplen con la doble condicion=======================");
ImprimirValores(queries.dobleCondicion(250,"in Action"));

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    //imprimir titulos
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    
    //imprimir cada elemento segun la coleccion que nos manden
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

    Console.WriteLine($"Libros totales {listadelibros.Count()}");
}