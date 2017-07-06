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

        public static DataSet ObtenerGraficaDemandaSemanal(string idServicio)
        {
            return Datos.Petcenter. Graficos.ObtenerGraficaDemandaSemanal(idServicio);
        }

        public static DataSet ObtenerGraficaIndicadorDeActividadPorEmpleado(string opcion)
        {
            return Datos.Petcenter.Graficos.ObtenerGraficaIndicadorDeActividadPorEmpleado(opcion);
        }

        public static DataSet BuscarResumen()
        {
            return Datos.Petcenter.Graficos.BuscarResumen();
        }

        public static DataSet ObtenerGraficaIndicadorDeEficienciaDeRecurso(string opcion)
        {
            return Datos.Petcenter.Graficos.ObtenerGraficaIndicadorDeEficienciaDeRecurso(opcion);
        }

        public static DataSet BuscarGrafico4(int opcion)
        {
            return Datos.Petcenter.Graficos.BuscarGrafico4(opcion);
        }
        public static DataSet ObtenerGraficaRent1()
        {
            return Datos.Petcenter.Graficos.ObtenerGraficaRent1();
        }

        public static DataSet ObtenerGraficaRent2()
        {
            return Datos.Petcenter.Graficos.ObtenerGraficaRent2();
        }
    }
}
