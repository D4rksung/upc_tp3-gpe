using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
   public class DetalleServicio
    {
        public int iddetalleHojaServicio { set; get; }
        public string Estado { set; get; }
        public string HoraInicio { set; get; }
        public string HoraFin { set; get; }
        public string Observaciones { set; get; }
        public string Servicio { set; get; }
    }
}
