using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
   public class GraficaResponse
    {
        public int IdEtiqueta { set; get; }
        public string DescripcionEtiqueta { set; get; }
        public decimal Cantidad { set; get; }
        public string DiaSemana { set; get; }

    }
}
