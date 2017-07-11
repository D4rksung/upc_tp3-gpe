using Datos.Petcenter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio.Petcenter
{
    public class ProgramacionCita : IProgramacion
    {


        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idServicio"></param>
        /// <param name="idCita"></param>
        /// <param name="dtEmpleados"></param>
        /// <param name="idDetalleCita"></param>
        /// <param name="idSector"></param>
        /// <param name="accion"></param>
        /// <param name="motivoAnulacion"></param>
        /// <returns></returns>
        public bool GrabarProgramación(int idServicio, string idCita, DataTable dtEmpleados, int idDetalleCita, int idSector, int accion, string motivoAnulacion)
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

                if (accion == Utilitario.Comun.AccionProgramacion.Actualizar)
                    Resultado = AtencionPeluqueriaDAO.ActualizarProgramacion(idServicio, dtEmpleados, idDetalleCita, idSector, idCita, TxOle);
                else if (accion == Utilitario.Comun.AccionProgramacion.Anular)
                    Resultado = AtencionPeluqueriaDAO.AnularProgramacion(idDetalleCita, idServicio, motivoAnulacion, idCita, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return true;
            }
            catch 
            {
                TxOle.Rollback();
                CnnDS.Close();
                return false;
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
        /// <param name="idDetalleCita"></param>
        /// <param name="dt"></param>
        /// <param name="txtComents"></param>
        /// <returns></returns>
        public bool GrabarHojadeServicio(Int32 idDetalleCita, DataTable dt, String coments)
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

                Resultado = AtencionPeluqueriaDAO.ActualizarHojaServicio(idDetalleCita, dt, coments, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch
            {
                TxOle.Rollback();
                CnnDS.Close();
                return false;
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
        /// <param name="dt"></param>
        /// <returns></returns>
        public Boolean GrabarMovimientoAtencion(DataTable dt)
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

                Resultado = AtencionPeluqueriaDAO.GrabarMovimientoAtencion(dt, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
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
        /// <param name="idDetalleCita"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public DataTable GrabarHojadeServicioComents(Int32 idDetalleCita, String text)
        {

            return AtencionPeluqueriaDAO.GrabarHojaDeServicioComents(idDetalleCita, text);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idMovimiento"></param>
        /// <param name="dt"></param>
        /// <param name="fechaMov"></param>
        /// <param name="tipoMov"></param>
        /// <param name="motivoMov"></param>
        /// <param name="idAlmacen"></param>
        /// <returns></returns>
        public Boolean GrabarMovimiento(int idMovimiento, DataTable dt, String fechaMov, String tipoMov, String motivoMov, Int32 idAlmacen)
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

                Resultado = AtencionPeluqueriaDAO.GrabarMovimiento(idMovimiento, dt, fechaMov, tipoMov, motivoMov, idAlmacen, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
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
        /// <param name="idMovimiento"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public Boolean GrabarMovimientoTipo(Int32 idMovimiento, String tipo)
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

                Resultado = AtencionPeluqueriaDAO.GrabarMovimientoTipo(idMovimiento,tipo,  TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
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
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public bool GrabarEliminarCanilSector(Int32 id, String tipo)
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

                Resultado = AtencionPeluqueriaDAO.GrabarEliminarCanilSector(id, tipo, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
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
        /// <param name="idCanil"></param>
        /// <param name="tamanio"></param>
        /// <param name="especie"></param>
        /// <param name="estado"></param>
        /// <param name="observaciones"></param>
        /// <returns></returns>
        public bool GrabarCanil(Int32 idCanil, String tamanio, String especie, String estado, String observaciones)
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

                Resultado = AtencionPeluqueriaDAO.GrabarCanil(idCanil, tamanio, especie, estado, observaciones, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
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
        /// <param name="idSector"></param>
        /// <param name="servicio"></param>
        /// <param name="estado"></param>
        /// <param name="observaciones"></param>
        /// <returns></returns>
        public bool GrabarSector(Int32 idSector, String servicio, String   estado, String observaciones)
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

                Resultado = AtencionPeluqueriaDAO.GrabarSector(idSector, servicio,  estado, observaciones, TxOle);

                TxOle.Commit();
                CnnDS.Close();
                return (Resultado != String.Empty);
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
    }
}

