using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    // Clase que define al objeto Casa.
    public class Casa
    {
        // Propiedad publica que almacena el ID de la casa.
        public int IdCasa { get; set; }

        // Propiedad publica que almacena la dirección de la casa.
        public string Direccion { get; set; }

        // Propiedad publica que almacena la ciudad donde esta la casa.
        public string Ciudad { get; set; }

        // Propiedad publica que almacena el número de habitantes de la casa.
        public int numeroHabitaciones { get; set; }

        // Esta propiedad retorna una cadena que incluye la dirección, la ciudad y el número de habitaciones de la casa.
        public string datosCasa()
        {
            return $"La dirección es {Direccion}, en la ciudad {Ciudad} con el número de habitaciones {numeroHabitaciones}";
        }
    }
}
