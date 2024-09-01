// See https://aka.ms/new-console-template for more information

using LINQ;

//LinQ

#region ListaModelos

List<Casa> listaCasa = new List<Casa>();
List<Habitante> listaHabitante = new List<Habitante>();

#endregion

#region Casa

// Clase anónima - No se puede escribir sobre ella, son de solo lectura.
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

// Nos permite tener un elemento sobre el que iteraremos 
IEnumerable<Habitante> listaEdad = from objTemporal in listaHabitante
                                   where objTemporal.Edad > 40
                                   select objTemporal;

// foreach no afecta al elemento recorrido
Console.WriteLine("---------------------------------------------------------------------------------");
foreach (var iteracion in listaEdad)
{
    Console.WriteLine(iteracion.datosHabitante());
}

// JOIN
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in listaHabitante
                                               join objetoTemporalCasa in listaCasa
                                               on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.IdCasa
                                               where objetoTemporalCasa.Ciudad == "Gothan City"
                                               select objetoTemporalHabitante;

Console.WriteLine("---------------------------------------------------------------------------------");
foreach (Habitante habitante in listaCasaGothan)
{
    Console.WriteLine(habitante.datosHabitante());
}

#endregion

#region Firsth()

Console.WriteLine("---------------------------------------------------------------------------------");
var primeraCasa = listaCasa.First(); //esto no es linQ es  una funcion de los Ienumarable
Console.WriteLine(primeraCasa.datosCasa());

// Aplicando una restriccion sin restricion lambda
Console.WriteLine("---------------------------------------------------------------------------------");
Habitante personaEdad = (from variableTemporalHabitante
                         in listaHabitante
                         where variableTemporalHabitante.Edad > 25
                         select variableTemporalHabitante).First();

Console.WriteLine(personaEdad.datosHabitante());

// Lo mismo pero con lambda
Console.WriteLine("---------------------------------------------------------------------------------");
var Habitante1 = listaHabitante.First(objectTemp => objectTemp.Edad > 25);
Console.WriteLine(Habitante1.datosHabitante());

// Si no tenemos el elemento que buscamos entoences la consulta devolvera una excepcion que detendra el codigo en su totalidad.

#endregion

#region FirsthOrDefault()

Casa CasaConFirsthOrDedault = listaCasa.FirstOrDefault(vCasa => vCasa.IdCasa > 200);

Console.WriteLine("---------------------------------------------------------------------------------");
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe !No hay!");
    return;
}

Console.WriteLine("existe !Si existe!");

#endregion

#region Last

Console.WriteLine("---------------------------------------------------------------------------------");
Casa ultimaCasa = listaCasa.Last(vTemporal => vTemporal.IdCasa > 1);

Console.WriteLine(ultimaCasa.datosCasa());

var habitante1 = (from objHabitante in listaHabitante 
                  where objHabitante.Edad > 60 select objHabitante)
                  .LastOrDefault();

Console.WriteLine("---------------------------------------------------------------------------------");
if (habitante1 == null)
{
    Console.WriteLine("Algo fallo");
    return;
}

Console.WriteLine(habitante1.datosHabitante());

#endregion
