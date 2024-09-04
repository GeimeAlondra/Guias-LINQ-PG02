using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    // Clase que define al obejto Medico que hereda de la clase Empleado.
    public class Medico : Empleado
    {
        // Propiedad publica que almacena el nombre del medico.
        public string Nombre { get; set; }
    }
}
