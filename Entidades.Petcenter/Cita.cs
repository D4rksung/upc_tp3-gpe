using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
   public class Cita
    {
        public int IdCita { set; get; }
        public int IdServicio { set; get; }
        public DateTime FechaLlegada { set; get; }
        public DateTime FechaRecojo { set; get; }
        public string Observaciones { set; get; }
        public string FechaInicial { set; get; }
        public string FechaFinal { set; get; }
        public string Estado { set; get; }
        public string Cliente { set; get; }
        public string Mascota { set; get; }
        public string CodigoCita { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoMascota { get; set; }
        public string CodigoEstado { get; set; }
        public int Tipo { get; set; }
    }
}
