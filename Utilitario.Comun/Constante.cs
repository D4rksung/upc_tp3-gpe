using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilitario.Comun
{
    public class Dominios
    {
        public const String ID = "ID";
        public const String Descripcion = "DESCR";

        public const String IdAlmacen = "idAlmacen";
        public const String DescripcionAlmacen = "descripcion";

        public const String IdServicio = "idServicio";
        public const String DescripcionServicio = "descripcion";

        public const String IdRol = "idRol";
        public const String DescripcionRol = "descripcion";

        public const String IdSector = "idSector";
        public const String DescripcionSector = "descripcion";

        public const String Parametro = "Parametro";
        public const String DescripcionParametro = "DscParametro";

        public const String IdEstado = "idEstado";
        public const String DescripcionEstado = "descripcion";
    }

    public class AccionHojaServicio
    {
        public const int Insertar = 1;
        public const int Actualizar = 2;
        public const int Anular = 3;
        
    }

    public class AccionMovimientoMateriales
    {
        public const int Insertar = 1;
        public const int Anular = 2;
    }

    public class AccionProgramacion
    {
        public const int Actualizar = 1;
        public const int Anular = 2;
    }

}
