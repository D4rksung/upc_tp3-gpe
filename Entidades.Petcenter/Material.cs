using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Petcenter
{
  public  class Material
    {
        public int idMaterial { set; get; }
        public string DscMaterial { set; get; }
        public string Nombre { set; get; }
        public string Categoria { set; get; }
        public string Modelo { set; get; }
        public decimal StockMinimo { set; get; }
        public string UndMedida { set; get; }
    }
}
