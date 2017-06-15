using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
   public class HojaServicio
    {
        public int idHojaServicio { set; get; }
        public int NumHojaServicio { set; get; }
        public int idServicio { set; get; }
        public string FechaEmision { set; get; }
        public string FechaInicial { set; get; }
        public string FechaFinal { set; get; }
        public int idCliente { set; get; }
        public int idEmpleado { set; get; }
        public string Canil { set; get; }
        public int idCita { set; get; }
        public string Observaciones { set; get; }
        public string NombreCliente { set; get; }
    }
}
