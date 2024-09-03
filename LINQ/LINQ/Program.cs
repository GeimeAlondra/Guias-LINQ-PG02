// See https://aka.ms/new-console-template for more information

using LINQ;

#region Introduccion

string[] palabras;
palabras = new string[] { "gato", "perro", "lagarto", "tortuga", "cocodrilo", "serpiente", "123456789" };
Console.WriteLine("Mas de 5 letras");

List<string> resultado = new List<string>();

foreach (string str in palabras)
{
    if (str.Length > 5)
    {
        resultado.Add(str);
    }
}

foreach (var r in resultado)
    Console.WriteLine(r);

#endregion

#region Utilizando LinQ

Console.WriteLine("---------------------------------------------------------------------------------");
IEnumerable<string> list = from r in palabras where r.Length > 8 select r;

foreach (var listado in list)
    Console.WriteLine(listado);

Console.WriteLine("---------------------------------------------------------------------------------");

#endregion

// LinQ

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
                  where objHabitante.Edad > 60
                  select objHabitante)
                  .LastOrDefault();

Console.WriteLine("---------------------------------------------------------------------------------");
if (habitante1 == null)
{
    Console.WriteLine("Algo fallo");
    return;
}

Console.WriteLine(habitante1.datosHabitante());

#endregion

#region ElementAt

Console.WriteLine("---------------------------------------------------------------------------------");
var terceraCasa = listaCasa.ElementAt(2);
Console.WriteLine($"La tercera casa es: {terceraCasa.datosCasa()}");

var casaError = listaCasa.ElementAtOrDefault(3);
if (casaError != null) { Console.WriteLine($"La tercera casa es: {casaError.datosCasa()}"); }

Console.WriteLine("---------------------------------------------------------------------------------");
var segundoHabitante = (from objetoTem in listaHabitante select objetoTem).ElementAtOrDefault(2);
Console.WriteLine($"Segundo habitante es: {segundoHabitante.datosHabitante()}");

#endregion

#region Single

try
{
    Console.WriteLine("---------------------------------------------------------------------------------");
    var habitantes = listaHabitante.Single(variableTem => variableTem.Edad > 40 && variableTem.Edad < 70);
    // Creando esta consulta pero con LinQ
    var habitante2 = (from obtem in listaHabitante where obtem.Edad > 70 select obtem).Single();

    Console.WriteLine($"Habitante con menos de 20 años: {habitantes.datosHabitante()}");
    if (habitante2 != null) Console.WriteLine($"Habitante con mas de 70 años: {habitante2.datosHabitante()}");
}
catch (Exception)
{
    Console.WriteLine($"Ocurrio un error");
}

#endregion

#region typeOf

var listaEmpleados = new List<Empleado>() {
    new Medico(){ Nombre = "Jorge Casa" },
    new Enfermero(){ Nombre = "Raul Blanco"}
};

Console.WriteLine("---------------------------------------------------------------------------------");
var medico = listaEmpleados.OfType<Medico>();
Console.WriteLine(medico.Single().Nombre);

#endregion

#region OrderBy

Console.WriteLine("---------------------------------------------------------------------------------");

var edadAsc = listaHabitante.OrderBy(x => x.Edad);

var edadAscendente = from vt in listaHabitante orderby vt.Edad select vt;

foreach (var edad in edadAscendente)
{
    Console.WriteLine(edad.datosHabitante());
}

#endregion

#region OrderByDescending

Console.WriteLine("---------------------------------------------------------------------------------");

var listaEdadDescendente = listaHabitante.OrderByDescending(x => x.Edad);

foreach (Habitante h in listaEdad) { 
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

var ListaEdad2 = from h in listaHabitante orderby h.Edad descending select h;

foreach (Habitante h in ListaEdad2)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion

#region ThenBy y ThenByDescending

Console.WriteLine("---------------------------------------------------------------------------------");

var habitantes3 = listaHabitante.OrderBy(x => x.Edad).ThenBy(x => x.Nombre);

foreach (var h in habitantes3)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

var lista4 = from h in listaHabitante orderby h.Edad, h.Nombre ascending select h;

foreach (var h in lista4)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

var habitantes4 = listaHabitante.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);

foreach (var h in habitantes4)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("---------------------------------------------------------------------------------");

var lista5 = from h in listaHabitante orderby h.Edad, h.Nombre descending select h;

foreach (var h in lista4)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion