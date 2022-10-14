namespace Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }


        public Empleado()
        {

        }

    }
}