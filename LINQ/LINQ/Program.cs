// See https://aka.ms/new-console-template for more information

using LINQ;

#region Introduccion

// Declaramos un arreglo llamado "palabras"
string[] palabras;

// Llenamos el arreglo.
palabras = new string[] { "gato", "perro", "lagarto", "tortuga", "cocodrilo", "serpiente", "123456789" };

Console.WriteLine("Mas de 5 letras");

// Creamos una lista de cadenas llamada "resultado" que almacenará las palabras con mas de 5 letras.
List<string> resultado = new List<string>();

// Recorremos el arreglo para seleccionar las palabras que tienen mas de 5 letras.
foreach (string str in palabras)
{
    // Comprueba si la longitud de la cadena es mayor que 5.
    if (str.Length > 5)
    {
        // Almacena los elementos que cumplen con la condición.
        resultado.Add(str);
    }
}

// Iteramos a través de cada cadena r en la lista "resultado".
foreach (var r in resultado)

    // Imprimimos en la consola cada palabra almacenada en "resultado".
    Console.WriteLine(r);

#endregion

#region Utilizando LinQ

Console.WriteLine("---------------------------------------------------------------------------------");

// Definimos una variable que almacena las cadenas de texto con más de 8 caracteres.
IEnumerable<string> list = from r in palabras where r.Length > 8 select r;

// Iteramos a través de cada elemento en la lista.
foreach (var listado in list)

    // Imprimimos cada elemento almacenado en list.
    Console.WriteLine(listado);

Console.WriteLine("---------------------------------------------------------------------------------");

#endregion

#region ListaModelos

// Creamos un alista vacia para el objeto Casa y Hbiatante.
List<Casa> listaCasa = new List<Casa>();
List<Habitante> listaHabitante = new List<Habitante>();

#endregion

#region Casa

// Clase anónima - No se puede escribir sobre ella, son de solo lectura.

// Agregamos nuevos objetos del tipo Casa a listaCasa que contendran Id, direccion, ciudad y numero de habitaciones.

listaCasa.Add(new Casa
{
    IdCasa = 1,
    Direccion = "3 av Norte ArcanCity",
    Ciudad = "Gothan City",
    numeroHabitaciones = 20,
});

listaCasa.Add(new Casa
{
    IdCasa = 2,
    Direccion = "6 av Sur SmollVille",
    Ciudad = "Metropolis",
    numeroHabitaciones = 5,
});

listaCasa.Add(new Casa
{
    IdCasa = 3,
    Direccion = "Forest Hills, Queens, NY 11375",
    Ciudad = "New York"
});

#endregion

#region Habitante

// Agregamos nuevos objetos del tipo Habiatante a listaHabitante que contendran Id, nombre, edad y el id de la casa.

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Bruno Diaz",
    Edad = 36,
    IdCasa = 1
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Clark Kent.",
    Edad = 40,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Peter Parker",
    Edad = 25,
    IdCasa = 3
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Tia Mey",
    Edad = 85,
    IdCasa = 3
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Luise Lain",
    Edad = 40,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Selina Kyle",
    Edad = 30,
    IdCasa = 1
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Alfred",
    Edad = 65,
    IdCasa = 1
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Nathan Drake",
    Edad = 36,
    IdCasa = 1
});

#endregion

#region SentenciaLinQ

// IEnumerable nos permite tener un elemento sobre el que iteraremos 
// Realizamos una consulta LINQ que recorre listaHabitante para filtrar los resultados que coinciden con la condición de que el habitante tenga mas de 40 años.
IEnumerable<Habitante> listaEdad = from objetoTemporal in listaHabitante
                                   where objetoTemporal.Edad > 40
                                   select objetoTemporal;

Console.WriteLine("---------------------------------------------------------------------------------");

// foreach no afecta al elemento recorrido
foreach (var iteracion in listaEdad)
{
    // Imprime los detalles de cada habitante que cumple con la condición de tener más de 40 años.
    Console.WriteLine(iteracion.datosHabitante());
}

// Realiza una consulta LINQ que une listaHabitante y listaCasa basándose en la coincidencia de IdHabitante y IdCasa
// y filtra los resultados para seleccionar solo aquellos habitantes que viven en Gothan City.
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in listaHabitante
                                         join objetoTemporalCasa in listaCasa
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.IdCasa
                                         where objetoTemporalCasa.Ciudad == "Gothan City"
                                         select objetoTemporalHabitante;

Console.WriteLine("---------------------------------------------------------------------------------");

// Iteramos a través de los habitantes que viven en Gothan City y los imprimimos.
foreach (Habitante habitante in listaCasaGothan)
{
    Console.WriteLine(habitante.datosHabitante());
}

#endregion

#region Firsth()

Console.WriteLine("---------------------------------------------------------------------------------");

// Esto no es linQ es  una funcion de los IEnumarable.
// Obtiene el primer elemento de listaCasa y lo almacena en la variable primeraCasa.
var primeraCasa = listaCasa.First();

// Imprime la información de la primera casa utilizando el método datosCasa().
Console.WriteLine(primeraCasa.datosCasa());

Console.WriteLine("---------------------------------------------------------------------------------");

// Aplicando una restricción con una consulta LINQ sin utilizar lambda
// Encuentra el primer habitante en listaHabitante cuya edad es mayor a 25 años.
Habitante personaEdad = (from variableTemporalHabitante
                         in listaHabitante
                         where variableTemporalHabitante.Edad > 25
                         select variableTemporalHabitante).First();

// Imprime la información del habitante encontrado utilizando el método datosHabitante().
Console.WriteLine(personaEdad.datosHabitante());

Console.WriteLine("---------------------------------------------------------------------------------");

// Utiliza una expresión lambda para encontrar el primer habitante en listaHabitante cuya edad es mayor a 25 años.
var Habitante1 = listaHabitante.First(objTemporal => objTemporal.Edad > 25);

// Imprime la información del habitante encontrado utilizando el método datosHabitante().
Console.WriteLine(Habitante1.datosHabitante());

// Si no tenemos el elemento que buscamos entonces la consulta devolvera una excepcion que detendra el codigo en su totalidad.

#endregion

#region FirsthOrDefault()

// Busca el primer objeto Casa en listaCasa cuyo ID es mayor a 200.
Casa CasaConFirsthOrDedault = listaCasa.FirstOrDefault(variableCasa => variableCasa.IdCasa > 200);

Console.WriteLine("---------------------------------------------------------------------------------");

// Si no encuentra ningún objeto que cumpla con la condición, devuelve null.
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe !No hay!");
    return;
}
Console.WriteLine("Existe !Si existe!");

#endregion

#region Last

Console.WriteLine("---------------------------------------------------------------------------------");
// Busca el último objeto Casa en listaCasa cuyo ID es mayor a 1.
Casa ultimaCasa = listaCasa.Last(vTemporal => vTemporal.IdCasa > 1);

// Si hay múltiples casas que cumplen con la condición, devuelve la última utilizando el método datosCasa().
Console.WriteLine(ultimaCasa.datosCasa());

// Consulta LINQ para encontrar el último habitante en listaHabitante cuya edad es mayor a 60 años.
var habitante1 = (from objetoHabitante in listaHabitante
                  where objetoHabitante.Edad > 60
                  select objetoHabitante)
                  .LastOrDefault();

Console.WriteLine("---------------------------------------------------------------------------------");

// Verifica si el resultado de LastOrDefault es null.
if (habitante1 == null)
{
    // Si es null imprime el mensaje indicando que algo falló en la búsqueda.
    Console.WriteLine("Algo fallo");
    return;
}

// Si habitante1 no es null, significa que se encontró al menos un habitante que cumple con la condición y lo imprime.
Console.WriteLine(habitante1.datosHabitante());

#endregion

#region ElementAt

Console.WriteLine("---------------------------------------------------------------------------------");

// Obtiene el tercer objeto Casa en listaCasa (0 se cuanta como primera posicion).
var terceraCasa = listaCasa.ElementAt(2);
Console.WriteLine($"La tercera casa es: {terceraCasa.datosCasa()}");

// Obtiene el cuarto objeto Casa en listaCasa.
var casaError = listaCasa.ElementAtOrDefault(3);

// Verificamos si casaError no es null antes de intentar imprimir su información.
if (casaError != null)
{
    Console.WriteLine($"La tercera casa es: {casaError.datosCasa()}");
}

Console.WriteLine("---------------------------------------------------------------------------------");

// Consulta LINQ para seleccionar todos los habitantes en listaHabitante.
// Tambien obtenemos el tercer habitante en la lista y si no existe devuelve null.
var segundoHabitante = (from objetoTem in listaHabitante select objetoTem).ElementAtOrDefault(2);

// Imprime la información del segundo habitante utilizando el método datosHabitante().
Console.WriteLine($"Tercer habitante es: {segundoHabitante.datosHabitante()}");

#endregion

#region Single

try
{
    Console.WriteLine("---------------------------------------------------------------------------------");

    // Encuentra un único habitante cuya edad este entre 40 y 70 años.
    var habitante2 = listaHabitante.Single(variableTemp => variableTemp.Edad > 40 && variableTemp.Edad < 70);

    // Consulta LINQ para encontrar un único habitante mayor de 70 años.
    var habitante3 = (from obtem in listaHabitante where obtem.Edad > 70 select obtem).Single();

    // Imprime los detalles del habitante de entre 40 y 70 años.
    Console.WriteLine($"Habitante mayor de 40 y menor de 70 años: {habitante2.datosHabitante()}");

    // Verifica si habitante3 no es null antes de imprimir.
    if (habitante3 != null)
        Console.WriteLine($"Habitante con más de 70 años: {habitante3.datosHabitante()}");
}
catch (Exception)
{
    // Imprime un mensaje de error si ocurre una excepción.
    Console.WriteLine("Ocurrió un error");
}

#endregion

#region typeOf

// Crea una lista de empleados con instancias de Medico y Enfermero.
var listaEmpleados = new List<Empleado>() {
    new Medico(){ Nombre = "Jorge Casa" },
    new Enfermero(){ Nombre = "Raul Blanco"}
};

Console.WriteLine("---------------------------------------------------------------------------------");

// Filtra la lista para obtener solo los objetos de tipo Medico.
var medico = listaEmpleados.OfType<Medico>();
// Imprime el nombre del único Medico en la lista.
Console.WriteLine(medico.Single().Nombre);

#endregion

#region OrderBy

Console.WriteLine("---------------------------------------------------------------------------------");

// Ordena la lista de habitantes por edad en orden ascendente.
var edadAsc = listaHabitante.OrderBy(x => x.Edad);

// Consulta LINQ para ordenar los habitantes por edad en orden ascendente.
var edadAscendente = from variableTemp in listaHabitante
                     orderby variableTemp.Edad
                     select variableTemp;

// Itera a través de la lista ordenada e imprime los detalles de cada habitante.
foreach (var edad in edadAscendente)
{
    Console.WriteLine(edad.datosHabitante());
}

#endregion

#region OrderByDescending

Console.WriteLine("---------------------------------------------------------------------------------");

// Filtra la lista de habitantes para obtener aquellos cuya edad es mayor de 40 años.
IEnumerable<Habitante> listaEdad2 = from objetoTemporal in listaHabitante
                                    where objetoTemporal.Edad > 40
                                    select objetoTemporal;

// Ordena la lista de habitantes por edad en orden descendente.
var listaEdadDescendente = listaHabitante.OrderByDescending(x => x.Edad);

// Imprime los detalles de los habitantes filtrados que tienen más de 40 años.
foreach (Habitante hab in listaEdad2)
{
    Console.WriteLine(hab.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

// Consulta LINQ para ordenar los habitantes por edad en orden descendente.
var listaEdadDescendente2 = from h in listaHabitante
                            orderby h.Edad descending
                            select h;

// Imprime los detalles de los habitantes ordenados por edad en orden descendente.
foreach (Habitante hab in listaEdadDescendente2)
{
    Console.WriteLine(hab.datosHabitante());
}

#endregion

#region ThenBy y ThenByDescending

Console.WriteLine("---------------------------------------------------------------------------------");

// Ordena la lista de habitantes primero por edad en orden ascendente y luego por nombre en orden ascendente.
var habitante4 = listaHabitante.OrderBy(x => x.Edad).ThenBy(x => x.Nombre);

// Imprime los detalles de los habitantes ordenados.
foreach (var h in habitante4)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

// Consulta LINQ para ordenar los habitantes primero por edad y luego por nombre en orden ascendente.
var lista1 = from h in listaHabitante orderby h.Edad, h.Nombre ascending select h;

// Imprime los detalles de los habitantes ordenados.
foreach (var h in lista1)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

// Ordena la lista de habitantes primero por edad en orden ascendente y luego por nombre en orden descendente.
var habitante5 = listaHabitante.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);

// Imprime los detalles de los habitantes ordenados.
foreach (var h in habitante5)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

// Consulta LINQ para ordenar los habitantes primero por edad y luego por nombre en orden descendente.
var lista2 = from h in listaHabitante orderby h.Edad, h.Nombre descending select h;

// Imprime los detalles de los habitantes ordenados.
foreach (var h in lista2)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion