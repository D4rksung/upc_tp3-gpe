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
        public bool GrabarProgramación(int idServicio, string idCita, DataTable dtEmpleados, int idDetalleCita, int idSector, int accion, string MotivoAnulacion)
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
                    Resultado = AtencionPeluqueriaDAO.ActualizarProgramacion(idServicio, dtEmpleados, idDetalleCita, idSector, idCita, txOle);
                else if (accion == 2)
                    Resultado = AtencionPeluqueriaDAO.AnularProgramacion(idDetalleCita, idServicio, MotivoAnulacion, idCita, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public bool GrabarHojadeServicio(Int32 idDetalleCita, DataTable dt, String txtComents)
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

                Resultado = AtencionPeluqueriaDAO.ActualizarHojaServicio(idDetalleCita, dt, txtComents, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public Boolean GrabarMovimientoAtencion(DataTable dt)
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

                Resultado = AtencionPeluqueriaDAO.GrabarMovimientoAtencion(dt, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public DataTable GrabarHojadeServicioComents(Int32 idDetalleCita, String text)
        {

            return AtencionPeluqueriaDAO.GrabarHojadeServicioComents(idDetalleCita, text);


        }

        public Boolean GrabarMovimiento(int idMovimiento, DataTable dt, String fechaMov, String tipoMov, String motivoMov, Int32 idAlmacen)
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

                Resultado = AtencionPeluqueriaDAO.GrabarMovimiento(idMovimiento, dt, fechaMov, tipoMov, motivoMov, idAlmacen, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public Boolean GrabarMovimientoTipo(Int32 idMovimiento, String tipo)
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

                Resultado = AtencionPeluqueriaDAO.GrabarMovimientoTipo(idMovimiento,tipo,  txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public bool GrabarEliminarCanilSector(Int32 id, String Tipo)
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

                Resultado = AtencionPeluqueriaDAO.GrabarEliminarCanilSector(id, Tipo, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public bool GrabarCanil(Int32 idCanil, String Tamanio, String Especie, String Estado, String observaciones)
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

                Resultado = AtencionPeluqueriaDAO.GrabarCanil(idCanil, Tamanio, Especie, Estado, observaciones, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }

        public bool GrabarSector(Int32 idSector, String Servicio, String   Estado, String observaciones)
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

                Resultado = AtencionPeluqueriaDAO.GrabarSector(idSector, Servicio,  Estado, observaciones, txOle);

                txOle.Commit();
                cnnDS.Close();
                return (Resultado != String.Empty);
            }
            catch (Exception ex)
            {
                txOle.Rollback();
                cnnDS.Close();
                throw;
                return false;
            }
            finally
            {
                cnnDS = null;
                txOle = null;
            }
        }
    }
}

