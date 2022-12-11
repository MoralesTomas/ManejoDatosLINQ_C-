public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {


        using(StreamReader reader = new StreamReader("Libros/Libros.json"))
        {
            
            //vamos a guardar el contenido dentro de un string utilizando el metodo ReadToEnd 
            //para que lea el archivo de principio a fin

            string json = reader.ReadToEnd();

            //ahora vamos a tomar el texto y a convertirlo en una conleccion
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }
}


/*
Donde:

    >la opcion .Text.Json.JsonSerializer lo que hace es convertir el texto en un json que podemos manejar

    >luego lo convertimos en un tipo de dato definido por nosotros dependiendo lo que estemos reciviendo el json. En este caso queremos
    un listado de libros (es lo que viene en el json) "List<libro>" y le indicamos con que string debe trabajar en este caso es con el string
    llamado "json".

    >agregamos una propiedad mas para que las propiedades de cada objeto json se enlacen con las propiedades de la clase que definimos es decir 
    que ignore si vienen mayusculas o minusculas en las propiedades y que se enlace en sus distintas propiedades.

*/