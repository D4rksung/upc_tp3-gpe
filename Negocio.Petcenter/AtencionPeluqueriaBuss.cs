using System.Data;
using Entidades.Petcenter;
using Datos.Petcenter;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Negocio.Petcenter
{
    public static class AtencionPeluqueriaBuss 
    {

        public static DataTable ParametroListar(string strDominio)
        {
            return AtencionPeluqueriaDAO.GetDominioParametro(strDominio);
        }

        public static DataTable BusquedaHojaServicio(HojaServicio hoja)
        {
            return AtencionPeluqueriaDAO.BusquedaHojaServicio(hoja);
        }


        //Grabar Hoja de servicio
        public static string GrabarHojaServicio(HojaServicio objParam, List<DetalleServicio> detalle, int accion)
        {

            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();

            SqlConnection cnnDS = new SqlConnection();
            SqlTransaction txOle = null;
            string Resultado = string.Empty;

            try
            {
                cnnDS.ConnectionString = conn;
                cnnDS.Open();
                txOle = cnnDS.BeginTransaction();

                if (accion == 1)
                    Resultado = AtencionPeluqueriaDAO.InsertarHojaServicio(objParam, txOle);
                else if (accion == 3)
                    AtencionPeluqueriaDAO.AnularHojaServicio(objParam, txOle);
                else if (accion == 2)
                {
                    //update detalle
                    for (Int32 pp = 0; pp <= detalle.Count - 1; pp++)
                    {
                        AtencionPeluqueriaDAO.ActualizarDetalleHojaServicio(detalle[pp], txOle);
                    }

                    //update cabecera
                    AtencionPeluqueriaDAO.ModificarHojaServicio(objParam, txOle);
                }


                txOle.Commit();
                cnnDS.Close();
                return Resultado;
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return string.Empty;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }



        public static DataSet GetDatosHojaServicioEjecutar(int idHojaServicio)
        {
            return AtencionPeluqueriaDAO.GetDatosHojaServicioEjecutar(idHojaServicio);
        }



        public static DataTable BusquedaKardexMaterial(KardexMaterial kardex)
        {
            return AtencionPeluqueriaDAO.BusquedaKardexMaterial(kardex);
        }

        //Grabar Kardex Material
        public static string GrabarKardexMaterial(KardexMaterial objParam, int accion)
        {

            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();

            SqlConnection cnnDS = new SqlConnection();
            SqlTransaction txOle = null;
            string Resultado = string.Empty;

            try
            {
                cnnDS.ConnectionString = conn;
                cnnDS.Open();
                txOle = cnnDS.BeginTransaction();

                if (accion == 1)
                    Resultado = AtencionPeluqueriaDAO.InsertarMovHardexMaterial(objParam, txOle);
                else if (accion == 2)
                    AtencionPeluqueriaDAO.AnularKardexMaterial(objParam, txOle);

                txOle.Commit();
                cnnDS.Close();
                return Resultado;
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return string.Empty;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public static DataTable GetDatosMaterial(int idmaterial)
        {
            return AtencionPeluqueriaDAO.GetDatosMaterial(idmaterial);
        }

        public static DataTable BusquedaMaterial(Material mat)
        {
            return AtencionPeluqueriaDAO.BusquedaMaterial(mat);
        }


        public static DataTable BusquedaCita(Cita cita)
        {
            return AtencionPeluqueriaDAO.BusquedaCita(cita);
        }


        public static DataSet GetDatosCita(int idcita)
        {
            return AtencionPeluqueriaDAO.GetDatosCita(idcita);
        }


        #region Metodos Actualizar Programacion Inicio
        #region Combos
        public static DataTable GetEstadosCita()
        {
            return AtencionPeluqueriaDAO.GetEstadosCita();
        }


        public static DataTable GetSectores(String idServicio)
        {
            return AtencionPeluqueriaDAO.GetSectores(idServicio);
        }

        public static DataTable GetRoles(String idServicio)
        {
            return AtencionPeluqueriaDAO.GetRoles(idServicio);
        }

        public static DataTable GetServicio()
        {
            return AtencionPeluqueriaDAO.GetEstado();
        }

        public static DataTable GetEmpleados()
        {
            return AtencionPeluqueriaDAO.GetEmpleados();
        }


        #endregion

        #region Busqueda

        public static DataSet BuscarCitaDetalle(int idCita)
        {
            return AtencionPeluqueriaDAO.BuscarCitaDetalle(idCita);
        }

        public static DataSet BuscarCitaDetalleCompleto(int idCita)
        {
            return AtencionPeluqueriaDAO.BuscarCitaDetalleCompleto(idCita);
        }

        public static DataTable BuscarCita(Cita cita)
        {
            return AtencionPeluqueriaDAO.BuscarCita(cita);
        }


        public static DataTable BuscarEmpleados(String RolID, String detalleCitaID)
        {
            return AtencionPeluqueriaDAO.BuscarEmpleados(RolID, detalleCitaID);
        }

        public static DataSet BuscarCitaDetalleEmpleados(string idDetalleCita, String idServicio)
        {
            return AtencionPeluqueriaDAO.BuscarCitaDetalleEmpleados(idDetalleCita, idServicio);
        }


        #endregion


        #region Grabar

      

        #endregion

        #endregion
    }
}
