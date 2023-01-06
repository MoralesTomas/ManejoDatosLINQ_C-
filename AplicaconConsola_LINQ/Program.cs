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

Console.WriteLine("===================Libro con menor cantidad de paginas==========");
var result = queries.libroConMenorCantidadPaginasMayorQueCero();
Console.WriteLine($"{result.Title} con un numero de paginas de {result.PageCount}");

Console.WriteLine("===================Libro fecha de publicacion mas reciente==========");
result = queries.ultimoLibroPublicado();
Console.WriteLine($"{result.Title} //Fecha de publicacion ====>// {result.PublishedDate.ToShortDateString()}");

Console.WriteLine("===================Suma de paginas de los libros que contengan entre 0 y 500 paginas==========");
var resultado = queries.SumaPaginasLibrosConPaginasEntre_0y500();
Console.WriteLine($"La suma total es de: {resultado}");


Console.WriteLine("===================Listado de libros que fueron publicados despues del 2015==========");
var resultadoString = queries.TitulosDeLibrosDespuesDel2015Concatenados();
Console.WriteLine($"{resultadoString}");

Console.WriteLine("===========Se muestra el promedio de caracteres contenidos en el titulo de los libros==========");
var resultadoDouble = queries.PromedioCaracteresTitulo();
Console.WriteLine($"El promedio de los caracteres en los titulos es: {resultadoDouble}");

Console.WriteLine("===========Libros publicados apartir del 2000 agrupados por anios==========");
var resultadoAgrupado = queries.LibrosDespuesdel2000AgrupadosporAnio();
ImprimirGrupo( resultadoAgrupado );

//comenzando a usar Lookup
var diccionarioBusqueda = queries.DiccionariosDeLibrosPorLetra();
var letra = 'B';
Console.WriteLine($"\n===========Libros que comienzan con la letra {letra}==========");
ImprimirDiccionario(diccionarioBusqueda, letra);




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

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Anio evaluado: { grupo.Key } --------------------------------");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{   
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in ListadeLibros[letra])
    {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
    }
}