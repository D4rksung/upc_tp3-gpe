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
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="Dominio"></param>
        /// <returns></returns>
        public static DataTable ParametroListar(string dominio)
        {
            return AtencionPeluqueriaDAO.GetDominioParametro(dominio);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="hoja"></param>
        /// <returns></returns>
        public static DataTable BusquedaHojaServicio(HojaServicio hoja)
        {
            return AtencionPeluqueriaDAO.BusquedaHojaServicio(hoja);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="codigo"></param>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <returns></returns>
        public static DataTable BuscarServicioHoy(Int32 codigo, String fechaInicial, String fechaFinal)
        {
            return AtencionPeluqueriaDAO.BuscarServicioHoy(codigo, fechaInicial, fechaFinal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movimientoID"></param>
        /// <returns></returns>
        public static DataTable BuscarMovimientosAtencion(Int32 movimientoID)
        {
            return AtencionPeluqueriaDAO.BuscarMovimientosAtencion(movimientoID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static DataTable BuscarMaterialesGen(String codigo)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesGen(codigo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="codigo"></param>
        /// <param name="almacenID"></param>
        /// <returns></returns>
        public static DataTable BuscarMaterialesxCodigo(Int32 codigo, Int32 almacenID)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesPorCodigo(codigo, almacenID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="iddetalleCita"></param>
        /// <returns></returns>
        public static DataSet BuscarServicioDetalle(Int32 iddetalleCita)
        {
            return AtencionPeluqueriaDAO.BuscarServicioDetalle(iddetalleCita);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="almacenID"></param>
        /// <param name="fechaIni"></param>
        /// <param name="fechaFin"></param>
        /// <param name="motivoID"></param>
        /// <param name="tipoID"></param>
        /// <param name="estadoID"></param>
        /// <param name="numeroRequerimiento"></param>
        /// <returns></returns>
        public static DataTable BuscarMovimientos(Int32 almacenID, String fechaIni, String fechaFin, String motivoID, String tipoID, String estadoID, String numeroRequerimiento)
        {
            return AtencionPeluqueriaDAO.BuscarMovimientos(almacenID, fechaIni, fechaFin, motivoID, tipoID, estadoID, numeroRequerimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="almacenID"></param>
        /// <param name="fechaIni"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static DataTable BuscarMateriales(int almacenID, string fechaIni, string fechaFin)
        {
            return AtencionPeluqueriaDAO.BuscarMateriales(almacenID, fechaIni, fechaFin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        public static DataTable GetcboTipoMov()
        {
            return AtencionPeluqueriaDAO.GetcboTipoMov();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static DataTable GetParametros(String codigo)
        {
            return AtencionPeluqueriaDAO.GetParametros(codigo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        public static DataTable GetAlmacen()
        {
            return AtencionPeluqueriaDAO.GetAlmacen();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="objParam"></param>
        /// <param name="detalle"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static string GrabarHojaServicio(HojaServicio objParam, List<DetalleServicio> detalle, int accion)
        {

            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();

            SqlConnection CnnDS = new SqlConnection();
            SqlTransaction TxOle = null;
            string Resultado = string.Empty;

            try
            {
                CnnDS.ConnectionString = Conn;
                CnnDS.Open();
                TxOle = CnnDS.BeginTransaction();

                if (accion == Utilitario.Comun.AccionHojaServicio.Insertar)
                    Resultado = AtencionPeluqueriaDAO.InsertarHojaServicio(objParam, TxOle);
                else if (accion == Utilitario.Comun.AccionHojaServicio.Anular)
                    AtencionPeluqueriaDAO.AnularHojaServicio(objParam, TxOle);
                else if (accion == Utilitario.Comun.AccionHojaServicio.Actualizar)
                {
                    //update detalle
                    for (Int32 pp = 0; pp <= detalle.Count - 1; pp++)
                    {
                        AtencionPeluqueriaDAO.ActualizarDetalleHojaServicio(detalle[pp], TxOle);
                    }

                    //update cabecera
                    AtencionPeluqueriaDAO.ModificarHojaServicio(objParam, TxOle);
                }


                TxOle.Commit();
                CnnDS.Close();
                return Resultado;
            }
            catch
            {
                TxOle.Rollback();
                CnnDS.Close();
                throw;
            }
            finally
            {
                CnnDS = null;
                TxOle = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idHojaServicio"></param>
        /// <returns></returns>
        public static DataSet GetDatosHojaServicioEjecutar(int idHojaServicio)
        {
            return AtencionPeluqueriaDAO.GetDatosHojaServicioEjecutar(idHojaServicio);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="kardex"></param>
        /// <returns></returns>
        public static DataTable BusquedaKardexMaterial(KardexMaterial kardex)
        {
            return AtencionPeluqueriaDAO.BusquedaKardexMaterial(kardex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="objParam"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static string GrabarKardexMaterial(KardexMaterial objParam, int accion)
        {

            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();

            SqlConnection CnnDS = new SqlConnection();
            SqlTransaction TxOle = null;
            string Resultado = string.Empty;

            try
            {
                CnnDS.ConnectionString = Conn;
                CnnDS.Open();
                TxOle = CnnDS.BeginTransaction();

                if (accion == Utilitario.Comun.AccionMovimientoMateriales.Insertar)
                    Resultado = AtencionPeluqueriaDAO.InsertarMovKardexMaterial(objParam, TxOle);
                else if (accion == Utilitario.Comun.AccionMovimientoMateriales.Anular)
                    AtencionPeluqueriaDAO.AnularKardexMaterial(objParam, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return Resultado;
            }
            catch
            {
                TxOle.Rollback();
                CnnDS.Close();
                throw;
            }
            finally
            {
                CnnDS = null;
                TxOle = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idMaterial"></param>
        /// <returns></returns>
        public static DataTable BuscarMaterialesMovimiento(Int32 idMaterial)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesMovimiento(idMaterial);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idMovimiento"></param>
        /// <param name="almacenID"></param>
        /// <returns></returns>
        public static DataSet BuscarMaterialesDispositivo(Int32 idMovimiento, Int32 almacenID)
        {
            return AtencionPeluqueriaDAO.BuscarMaterialesDispositivo(idMovimiento, almacenID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idmaterial"></param>
        /// <returns></returns>
        public static DataTable GetDatosMaterial(int idmaterial)
        {
            return AtencionPeluqueriaDAO.GetDatosMaterial(idmaterial);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static DataTable BusquedaMaterial(Material mat)
        {
            return AtencionPeluqueriaDAO.BusquedaMaterial(mat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="cita"></param>
        /// <returns></returns>
        public static DataTable BusquedaCita(Cita cita)
        {
            return AtencionPeluqueriaDAO.BusquedaCita(cita);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idcita"></param>
        /// <returns></returns>
        public static DataSet GetDatosCita(int idcita)
        {
            return AtencionPeluqueriaDAO.GetDatosCita(idcita);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        #region Metodos Actualizar Programacion Inicio
        #region Combos
        public static DataTable GetEstadosCita()
        {
            return AtencionPeluqueriaDAO.GetEstadosCita();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idServicio"></param>
        /// <returns></returns>
        public static DataTable GetSectores(String idServicio)
        {
            return AtencionPeluqueriaDAO.GetSectores(idServicio);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idServicio"></param>
        /// <returns></returns>
        public static DataTable GetRoles(String idServicio)
        {
            return AtencionPeluqueriaDAO.GetRoles(idServicio);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        public static DataTable GetServicio()
        {
            return AtencionPeluqueriaDAO.GetServicio();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        public static DataTable GetEmpleados()
        {
            return AtencionPeluqueriaDAO.GetEmpleados();
        }


        #endregion

        #region Busqueda

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idCita"></param>
        /// <returns></returns>
        public static DataSet BuscarCitaDetalle(int idCita)
        {
            return AtencionPeluqueriaDAO.BuscarCitaDetalle(idCita);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idCita"></param>
        /// <returns></returns>
        public static DataSet BuscarCitaDetalleCompleto(int idCita)
        {
            return AtencionPeluqueriaDAO.BuscarCitaDetalleCompleto(idCita);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="cita"></param>
        /// <returns></returns>
        public static DataTable BuscarCita(Cita cita)
        {
            return AtencionPeluqueriaDAO.BuscarCita(cita);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="rolID"></param>
        /// <param name="detalleCitaID"></param>
        /// <returns></returns>
        public static DataTable BuscarEmpleados(String rolID, String detalleCitaID)
        {
            return AtencionPeluqueriaDAO.BuscarEmpleados(rolID, detalleCitaID);
        }

        public static DataSet BuscarCitaDetalleEmpleados(string idDetalleCita, String idServicio)
        {
            return AtencionPeluqueriaDAO.BuscarCitaDetalleEmpleados(idDetalleCita, idServicio);
        }


        #endregion



        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static DataTable GetParametrosGEN(String tipo)
        {
            return AtencionPeluqueriaDAO.GetParametrosGEN(tipo);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idCanil"></param>
        /// <returns></returns>
        public static DataSet BuscarSectorDetalle(Int32 idCanil)
        {
            return AtencionPeluqueriaDAO.BuscarSectorDetalle(idCanil);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idSector"></param>
        /// <returns></returns>
        public static DataSet BuscarCanilDetalle(int idSector)
        {
            return AtencionPeluqueriaDAO.BuscarCanilDetalle(idSector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="tipo"></param>
        /// <param name="fechaIni"></param>
        /// <param name="fechaFin"></param>
        /// <param name="recurso"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static DataTable BuscarCanil(Int32 tipo, String fechaIni, String fechaFin, String recurso, String estado)
        {
            return AtencionPeluqueriaDAO.BuscarCanil(tipo, fechaIni, fechaFin, recurso, estado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="tipo"></param>
        /// <param name="fechaIni"></param>
        /// <param name="fechaFin"></param>
        /// <param name="recurso"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static DataTable BuscarSector(Int32 tipo, String fechaIni, String fechaFin, String recurso, String estado)
        {
            return AtencionPeluqueriaDAO.BuscarSector(tipo, fechaIni, fechaFin, recurso, estado);
        }


    }
}
