using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
  public  class KardexMaterial
    {
        public int idKardexMaterial { set; get; }
        public int idMaterial { set; get; }
        public string Material { set; get; }
        public string FechaMovimiento { set; get; }
        public string TipoMovimiento { set; get; }
        public string NumGuia { set; get; }
        public decimal PrecioCompra { set; get; }
        public decimal Cantidad { set; get; }
        public string FechaInicial { set; get; }
        public string FechaFinal { set; get; }
    }
}
