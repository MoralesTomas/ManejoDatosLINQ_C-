LinqQueries queries = new LinqQueries();

ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    //imprimir titulos
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    
    //imprimir cada elemento segun la coleccion que nos manden
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}