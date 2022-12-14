LinqQueries queries = new LinqQueries();


Console.WriteLine("===================Coleccion de libros completa=======================");
ImprimirValores(queries.TodaLaColeccion());

Console.WriteLine("===================Libros publicados despues del 2000=======================");
ImprimirValores(queries.librosDespues2000());

Console.WriteLine("===================Libros que cumplen con la doble condicion=======================");
ImprimirValores(queries.dobleCondicion(250,"in Action"));

Console.WriteLine("===================Todos los libros contienen Status?=======================");
Console.WriteLine(queries.verificacionStatus());

Console.WriteLine("===================Verificacion de libro publicado por anio=======================");
int anio = 2005;
Console.WriteLine(queries.verificarPublicacionPorAnio(anio));

Console.WriteLine("===================Libros por categoria=======================");
string categoriaBuscada = "Python";
Console.WriteLine($"Libros que contengan la categoria {categoriaBuscada}");
ImprimirValores(queries.verificacionCategoria(categoriaBuscada));

Console.WriteLine("===================Libros por categoria Ascendente=======================");
categoriaBuscada = "Java";
Console.WriteLine($"Libros que contengan la categoria {categoriaBuscada} ordenados por su titulo de manera ascendente");
ImprimirValores(queries.retornarOrdenado_filtrandoCategoria(categoriaBuscada));

Console.WriteLine("===================Libros por minimo de paginas de manera descendente=======================");
ImprimirValores(queries.paginasMinimas_Descendente( 450 ));

Console.WriteLine("===================Top libros ordenados descendente segun categoria=======================");
categoriaBuscada = "Java";
int cantidad_Mostrar = 3;
Console.WriteLine($"Top {cantidad_Mostrar} libros que contengan la categoria {categoriaBuscada} ordenados por fecha de publicacion ");
ImprimirValores(queries.seleccionTopPublicacionPorCategoria(categoriaBuscada, cantidad_Mostrar));

Console.WriteLine("===================Tecer y cuarto libro de la seccion de libros con mas de n cantidad de paginas=======================");
int paginasMinimas = 400;
ImprimirValores(queries.seleccionTercerYCuartoLibroMayorAPaginas(paginasMinimas));

Console.WriteLine("===================Ejemplo TakeWhile=======================");
queries.EjTakeWhile();

Console.WriteLine("===================Ejemplo SkipWhile=======================");
queries.EjSkipWhile();

Console.WriteLine("===================Cantidad de libros segun intervalo de cantidad de paginas=======================");
int min = 200;
int max = 500;
Console.WriteLine($"La cantidad de libros que contienen entre {min} y {max} paginas es de : {queries.countLibrosPorNPaginas(min,max)}");


Console.WriteLine("===================Fecha de publicacion mas antigua=======================");
Console.WriteLine(queries.menorFechaPublicacion().ToShortDateString());


Console.WriteLine("===================Mayor cantidad de paginas de un libro=======================");
Console.WriteLine(queries.mayorCantidadPaginasLibro());





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