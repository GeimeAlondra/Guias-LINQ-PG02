using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    // Clase que define al objeto Habitante.
    public class Habitante
    {
        // Propiedad publica que almacena el ID del habitante.
        public int IdHabitante { get; set; }

        // Propiedad publica que almacena el nombre del habitante.
        public string Nombre { get; set; }

        // Propiedad publica que almacena la edad del habitante.
        public int Edad { get; set; }

        // Propiedad publica que almacena el ID de la casa del habitante.
        public int IdCasa { get; set; }

        // Esta propiedad retorna una cadena que incluye el nombre, la edad y el ID de la casa del habitante.
        public string datosHabitante()
        {
            return $"Soy {Nombre}, con edad de {Edad} con número de años vividos en {IdCasa}";
        }
    }
}
