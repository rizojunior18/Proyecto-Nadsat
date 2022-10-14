using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario : Empleado
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        
    }
}
