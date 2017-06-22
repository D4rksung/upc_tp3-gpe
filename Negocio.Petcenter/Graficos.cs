using System.Data;
using Entidades.Petcenter;
using Datos.Petcenter;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
namespace Negocio.Petcenter
{
  public  class Graficos
    {

        public static DataSet ObtenerGrafica1(string idServicio)
        {
            return Datos.Petcenter. Graficos.ObtenerGrafica1(idServicio);
        }

        public static DataSet ObtenerGrafica2(string opcion)
        {
            return Datos.Petcenter.Graficos.ObtenerGrafica2(opcion);
        }

        public static DataSet BuscarResumen()
        {
            return Datos.Petcenter.Graficos.BuscarResumen();
        }

        public static DataSet ObtenerGrafica3(string opcion)
        {
            return Datos.Petcenter.Graficos.ObtenerGrafica3(opcion);
        }

        public static DataSet BuscarGrafico4(int opcion)
        {
            return Datos.Petcenter.Graficos.BuscarGrafico4(opcion);
        }
    }
}
