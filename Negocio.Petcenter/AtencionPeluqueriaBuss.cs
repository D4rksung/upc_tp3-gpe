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

        public static DataTable BuscarServicioHoy(Int32 codigo, String fechaInicial, String fechaFinal)
        {
            return AtencionPeluqueriaDAO.BuscarServicioHoy(codigo, fechaInicial, fechaFinal);
        }


        public static DataTable BuscarMovimientosAtencion(Int32 movimientoID)
        {
            return AtencionPeluqueriaDAO.BuscarMovimientosAtencion(movimientoID);
        }

        public static DataTable BuscarMaterialesGen(String codigo)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesGen(codigo);
        }

        public static DataTable BuscarMaterialesxCodigo(Int32 codigo, Int32 almacenID)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesxCodigo(codigo, almacenID);
        }
        public static DataSet BuscarServicioDetalle(Int32 iddetalleCita)
        {
            return AtencionPeluqueriaDAO.BuscarServicioDetalle(iddetalleCita);
        }

        public static DataTable BuscarMovimientos(Int32 AlmacenID, String fechaIni, String FechaFin, String motivoID, String tipoID, String estadoID, String NumReq)
        {
            return AtencionPeluqueriaDAO.BuscarMovimientos(AlmacenID, fechaIni, FechaFin, motivoID, tipoID, estadoID, NumReq);
        }
        public static DataTable BuscarMateriales(int AlmacenID, string fechaIni, string FechaFin)
        {
            return AtencionPeluqueriaDAO.BuscarMateriales(AlmacenID, fechaIni, FechaFin);
        }

        public static DataTable GetcboTipoMov()
        {
            return AtencionPeluqueriaDAO.GetcboTipoMov();
        }

        public static DataTable GetParametros(String codigo)
        {
            return AtencionPeluqueriaDAO.GetParametros(codigo);
        }

        public static DataTable GetAlmacen()
        {
            return AtencionPeluqueriaDAO.GetAlmacen();
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

        public static DataTable BuscarMaterialesMov(Int32 idMaterial)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesMov(idMaterial);
        }

        public static DataSet BuscarMaterialesDispo(Int32 idMovimiento, Int32 almacenID)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesDispo(idMovimiento, almacenID);
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
            return AtencionPeluqueriaDAO.GetServicio();
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



        #endregion


        public static DataTable GetParametrosGEN(String tipo)
        {
            return AtencionPeluqueriaDAO.GetParametrosGEN(tipo);
        }



        public static DataSet BuscarSectorDetalle(Int32 idCanil)
        {
            return AtencionPeluqueriaDAO.BuscarSectorDetalle(idCanil);
        }



        public static DataSet BuscarCanilDetalle(int idSector)
        {
            return AtencionPeluqueriaDAO.BuscarCanilDetalle(idSector);
        }


        public static DataTable BuscarCanil(Int32 tipo, String fechaIni, String fechaFin, String Recurso, String Estado)
        {
            return AtencionPeluqueriaDAO.BuscarCanil(tipo, fechaIni, fechaFin, Recurso, Estado);
        }

        public static DataTable BuscarSector(Int32 tipo, String fechaIni, String fechaFin, String Recurso, String Estado)
        {
            return AtencionPeluqueriaDAO.BuscarSector(tipo, fechaIni, fechaFin, Recurso, Estado);
        }


    }
}
