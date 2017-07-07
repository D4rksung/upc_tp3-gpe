using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
  public  class Empleado
    {

        public int IdCliente {set;get;}
        public string NumeroDocumento { set; get; }
        public string NombreCliente { set; get; }
        public string ApellidoCliente { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public string FechaNacimiento { set; get; }
        public string EmailCliente { set; get; }
        public int IdEmpleado { set; get; }
        public string NombreEmpleado { set; get; }

    }
}
