using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
   public class HojaServicio
    {
        public int IdHojaServicio { set; get; }
        public int NumHojaServicio { set; get; }
        public int IdServicio { set; get; }
        public string FechaEmision { set; get; }
        public string FechaInicial { set; get; }
        public string FechaFinal { set; get; }
        public int IdCliente { set; get; }
        public int IdEmpleado { set; get; }
        public string Canil { set; get; }
        public int IdCita { set; get; }
        public string Observaciones { set; get; }
        public string NombreCliente { set; get; }
    }
}
