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
    Direccion = "3 avn Chalatenango",
    Ciudad = "Chalatenango",
    numeroHabitaciones = 20
});

listaCasa.Add(new Casa
{
    IdCasa = 2,
    Direccion = "4 av",
    Ciudad = "San Salvador",
    numeroHabitaciones = 9
});

listaCasa.Add(new Casa
{
    IdCasa = 3,
    Direccion = "6 avn",
    Ciudad = "San Miguel",
    numeroHabitaciones = 5
});

#endregion

#region Habitante

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Elena",
    Edad = 25,
    IdCasa = 1
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Carlos",
    Edad = 20,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Alfredo",
    Edad = 30,
    IdCasa = 3
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Luis",
    Edad = 50,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Sonia",
    Edad = 18,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Elmer",
    Edad = 36,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Miguel",
    Edad = 45,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Olga",
    Edad = 15,
    IdCasa = 2
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
IEnumerable<Habitante> listaCasaChalatenango = from objetoTemporalHabitante in listaHabitante
                                               join objetoTemporalCasa in listaCasa
                                               on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.IdCasa
                                               where objetoTemporalCasa.Ciudad == "Chalatenango"
                                               select objetoTemporalHabitante;

Console.WriteLine("---------------------------------------------------------------------------------");
foreach (Habitante habitante in listaCasaChalatenango)
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
