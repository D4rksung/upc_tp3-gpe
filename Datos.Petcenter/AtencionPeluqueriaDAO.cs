using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entidades.Petcenter;
using System.Data.SqlClient;


namespace Datos.Petcenter
{
    public static class AtencionPeluqueriaDAO
    {

        //obtener parametros
        public static  DataTable GetDominioParametro(string strDominio)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();


            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Parametro_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@pisDominio", SqlDbType.Char, 3)).Value = strDominio;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("DominioParametro" + strDominio);
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable BuscarMovimientosAtencion(int almacenID, string material, String Req)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_getMaterialxAtencion_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;
                cmd.Parameters.Add(new SqlParameter("@material", SqlDbType.VarChar,250)).Value = material;
                cmd.Parameters.Add(new SqlParameter("@Req", SqlDbType.VarChar, 250)).Value = Req;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable BuscarMaterialesxCodigo(int codigo, Int32 almacenID)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_getMaterialxCod_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = codigo;
                cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static string GrabarMovimientoAtencion(DataTable dt, SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_RequerimientoAtencionActualizada";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@dtDetalle", SqlDbType.Structured)).Value = dt;

                return cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        

        public static DataTable BuscarMaterialesGen()
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_getMaterial_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable BuscarMovimientos(Int32 almacenID, String fechaIni, String fechaFin, String motivoID, String tipoID, String estadoID, String NumReq)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ReqMaterial_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                
                    cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;
                    cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar, 10)).Value = fechaIni;
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 10)).Value = fechaFin;
                cmd.Parameters.Add(new SqlParameter("@motivoID", SqlDbType.VarChar, 10)).Value = motivoID;
                cmd.Parameters.Add(new SqlParameter("@tipoID", SqlDbType.VarChar, 10)).Value = tipoID;
                cmd.Parameters.Add(new SqlParameter("@estadoID", SqlDbType.VarChar, 10)).Value = estadoID;
                cmd.Parameters.Add(new SqlParameter("@NumReq", SqlDbType.VarChar, 100)).Value = NumReq;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable GetParametros(String codigo)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ParametrosCombo_GL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (codigo != "0")
                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar,10)).Value = codigo;
                else
                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 10)).Value = DBNull.Value;
                

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable BuscarMateriales(int almacenID, string fechaIni, string fechaFin)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_KardexMaterialesgl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (almacenID != 0)
                    cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;
                else
                    cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = DBNull.Value;

                if (fechaIni != "")
                    cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar,10)).Value = fechaIni;
                else
                    cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                if (fechaFin != "")
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 10)).Value = fechaFin;
                else
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static string GrabarMovimientoTipo(int idMovimiento,String tipo, SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_RequerimientoTipo";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = idMovimiento;
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar,10)).Value = tipo;


                return  cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        public static DataTable BuscarMaterialesMov(int idMaterial)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_KardexMaterialesDetailgl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (idMaterial != 0)
                    cmd.Parameters.Add(new SqlParameter("@idMaterial", SqlDbType.Int)).Value = idMaterial;
                else
                    cmd.Parameters.Add(new SqlParameter("@idMaterial", SqlDbType.Int)).Value = DBNull.Value;

              

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }

        public static DataSet BuscarMaterialesDispo(int idMovimiento)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_ReqMaterialesDisponiblegl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (idMovimiento != 0)
                    cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = idMovimiento;
                else
                    cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = DBNull.Value;

                
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }

        public static DataTable GetcboTipoMov()
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_TipoMovimiento_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable GetAlmacen()
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Almacen_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }


        //busqueda de hoja de servicio
        public static DataTable BusquedaHojaServicio(HojaServicio hoja)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_HojaServicio_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (hoja.NumHojaServicio != 0)
                    cmd.Parameters.Add(new SqlParameter("@NumHoja", SqlDbType.Int)).Value = hoja.NumHojaServicio;
                else
                    cmd.Parameters.Add(new SqlParameter("@NumHoja", SqlDbType.Int)).Value = DBNull.Value;

                if (hoja.NombreCliente != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@NombreCliente", SqlDbType.VarChar, 250)).Value = hoja.NombreCliente;
                else
                    cmd.Parameters.Add(new SqlParameter("@NombreCliente", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                if (hoja.idServicio != 0)
                    cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = hoja.idServicio;
                else
                    cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = DBNull.Value;


                if (hoja.FechaInicial != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = hoja.FechaInicial;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = DBNull.Value;

                if (hoja.FechaFinal != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = hoja.FechaFinal;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = DBNull.Value;

                if (hoja.idCliente != 0)
                    cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int)).Value = hoja.idCliente;
                else
                    cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }

        public static string GrabarMovimiento(int idMovimiento, DataTable dtMateriales, String fechaMov, String tipoMov, String MotivoMov, Int32 idAlmacen,SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_RequerimientoActualizar";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = idMovimiento;
                cmd.Parameters.Add(new SqlParameter("@fechaMov", SqlDbType.VarChar,10)).Value = fechaMov;
                cmd.Parameters.Add(new SqlParameter("@tipoMov", SqlDbType.VarChar,10)).Value = tipoMov;
                cmd.Parameters.Add(new SqlParameter("@MotivoMov", SqlDbType.VarChar,10)).Value = MotivoMov;
                cmd.Parameters.Add(new SqlParameter("@dtMateriales", SqlDbType.Structured)).Value = dtMateriales;
                cmd.Parameters.Add(new SqlParameter("@idAlmacen", SqlDbType.Int)).Value = idAlmacen;

                return cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
    

        public static DataTable GrabarHojadeServicioComents(Int32 idDetalleCita, String text)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_HojaServicio_ComentsGrabar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (idDetalleCita != 0)
                    cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                else
                    cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = DBNull.Value;

                if (idDetalleCita != 0)
                    cmd.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar,5000)).Value = text;
                else
                    cmd.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar, 5000)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }

        public static string ActualizarHojaServicioComents(int idDetalleCita, string text, SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_HojaServicio_ComentsGrabar";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                cmd.Parameters.Add(new SqlParameter("@Comments", SqlDbType.Int)).Value = text;
                cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        public static string ActualizarHojaServicio(Int32 idDetalleCita, DataTable dt, String txtComents, SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_HojaServicio_Grabar";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                cmd.Parameters.Add(new SqlParameter("@dtMaterial", SqlDbType.Structured)).Value = dt;
                cmd.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar,5000)).Value = txtComents;
                cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        //ingreso de hoja de servicio
        public static string InsertarHojaServicio(HojaServicio  objParam, SqlTransaction objTx)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_HojaServicio_i";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = objTx.Connection;
                cmd.Transaction = objTx;

                cmd.Parameters.Add(new SqlParameter("@idcita", SqlDbType.Int)).Value = objParam.idCita;
                cmd.Parameters.Add(new SqlParameter("@idEmpleado", SqlDbType.Int)).Value = objParam.idEmpleado;
                cmd.Parameters.Add(new SqlParameter("@numhojaservicio", SqlDbType.Int)).Value = objParam.NumHojaServicio;
                cmd.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar,250)).Value = objParam.Observaciones;
                cmd.Parameters.Add(new SqlParameter("@fechaRegistro", SqlDbType.Date)).Value = objParam.FechaEmision;
                cmd.Parameters.Add(new SqlParameter("@Canil", SqlDbType.Char,3)).Value = objParam.Canil;
                cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }
        



        //Modificar de hoja de servicio
        public static void ModificarHojaServicio(HojaServicio objParam, SqlTransaction objTx)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_HojaServicio_u";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = objTx.Connection;
                cmd.Transaction = objTx;

                cmd.Parameters.Add(new SqlParameter("@idHojaServicio", SqlDbType.Int)).Value = objParam.idHojaServicio;
                if (objParam.FechaEmision != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaEmision", SqlDbType.Date)).Value = objParam.FechaEmision;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaEmision", SqlDbType.Date)).Value = DBNull.Value;

                cmd.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 250)).Value = objParam.Observaciones;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        public static void AnularHojaServicio(HojaServicio objParam, SqlTransaction objTx)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_HojaServicio_d";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = objTx.Connection;
                cmd.Transaction = objTx;

                cmd.Parameters.Add(new SqlParameter("@idHojaServicio", SqlDbType.Int)).Value = objParam.idHojaServicio;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        public static DataSet GetDatosCita(int idCita)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Cita_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@idCita", SqlDbType.Int)).Value = idCita;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        //busqueda de cita
        public static DataTable BusquedaCita(Cita cita)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_Cita_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                if (cita.FechaInicial != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = cita.FechaInicial;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = DBNull.Value;

                if (cita.FechaFinal != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = cita.FechaFinal;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = DBNull.Value;

                if (cita.Cliente != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 250)).Value = cita.Cliente;
                else
                    cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }

        public static DataSet GetDatosHojaServicioEjecutar(int idHojaServicio)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_HojaServicio_ge";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@idHojaServicio", SqlDbType.Int)).Value = idHojaServicio;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static void ActualizarDetalleHojaServicio(DetalleServicio detalle, SqlTransaction objTx)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_DetalleServicio_u";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = objTx.Connection;
                cmd.Transaction = objTx;

                cmd.Parameters.Add(new SqlParameter("@iddetalleHojaServicio", SqlDbType.Int)).Value = detalle.iddetalleHojaServicio;

                if (detalle.HoraInicio != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@HoraInicio", SqlDbType.VarChar, 10)).Value = detalle.HoraInicio;
                else
                    cmd.Parameters.Add(new SqlParameter("@HoraInicio", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                if (detalle.HoraFin != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@HoraFin", SqlDbType.VarChar, 10)).Value = detalle.HoraFin;
                else
                    cmd.Parameters.Add(new SqlParameter("@HoraFin", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Char,3)).Value = detalle.Estado;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        //busqueda de hoja de servicio
        public static DataTable BusquedaKardexMaterial(KardexMaterial kardex)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_KardexMaterial_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (kardex.Material != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Material", SqlDbType.VarChar, 250)).Value = kardex.Material;
                else
                    cmd.Parameters.Add(new SqlParameter("@Material", SqlDbType.VarChar, 250)).Value = DBNull.Value;


                if (kardex.FechaInicial != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = kardex.FechaInicial;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = DBNull.Value;

                if (kardex.FechaFinal != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = kardex.FechaFinal;
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = DBNull.Value;

               
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }


        //ingreso de kardex de material
        public static string InsertarMovHardexMaterial(KardexMaterial objParam, SqlTransaction objTx)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_KardexMaterial_i";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = objTx.Connection;
                cmd.Transaction = objTx;

                cmd.Parameters.Add(new SqlParameter("@idMaterial", SqlDbType.Int)).Value = objParam.idMaterial;
                cmd.Parameters.Add(new SqlParameter("@FecMovimiento", SqlDbType.Date)).Value = objParam.FechaMovimiento;
                cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", SqlDbType.Char,3)).Value = objParam.TipoMovimiento;
                cmd.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Decimal)).Value = objParam.Cantidad;
                cmd.Parameters.Add(new SqlParameter("@PrecioCompra", SqlDbType.Decimal)).Value = objParam.PrecioCompra;
                cmd.Parameters.Add(new SqlParameter("@DocumentoReferencia", SqlDbType.VarChar, 30)).Value = DbNullIfNull(objParam.NumGuia);
                cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        public static object DbNullIfNull(this object obj)
        {
            return ! string.IsNullOrEmpty(obj.ToString()) ? obj : DBNull.Value;
        }

        public static void AnularKardexMaterial(KardexMaterial objParam, SqlTransaction objTx)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_KardexMaterial_d";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = objTx.Connection;
                cmd.Transaction = objTx;

                cmd.Parameters.Add(new SqlParameter("@idKardexMaterial", SqlDbType.Int)).Value = objParam.idKardexMaterial;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmd = null;
            }
        }

        public static DataTable GetDatosMaterial(int idmaterial)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Material_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@idmaterial", SqlDbType.Int)).Value = idmaterial;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        //busqueda de cita
        public static DataTable BusquedaMaterial(Material mat)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_Material_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                if (mat.Nombre != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar,250)).Value = mat.Nombre;
                else
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar,250)).Value = DBNull.Value;

                if (mat.DscMaterial != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@DscMaterial", SqlDbType.Date)).Value = mat.DscMaterial;
                else
                    cmd.Parameters.Add(new SqlParameter("@DscMaterial", SqlDbType.Date)).Value = DBNull.Value;

                if (mat.Modelo != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 250)).Value = mat.Modelo;
                else
                    cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                if (mat.Categoria != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 250)).Value = mat.Categoria;
                else
                    cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }




      
     



        #region Metodos Actualizar Programacion Inicio
        #region Combos

        public static DataTable GetEstadosCita()
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_EstadoCita_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable GetSectores(String idServicio)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Sectores_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable GetRoles(String idServicio)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Roles_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable GetEmpleados()
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Empleado_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable GetServicio()
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_Servicio_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }


        #endregion

        #region Busqueda


        public static DataSet BuscarCitaDetalle(int idCita)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_getCitaDetalle_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@idCita", SqlDbType.Int)).Value = idCita;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataSet BuscarCitaDetalleCompleto(int idCita)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_getCitaDetalleCompleto_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@idCita", SqlDbType.Int)).Value = idCita;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }

        public static DataTable BuscarCita(Cita obj)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "usp_ProgCitaBusquedaCita_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (obj.FechaInicial != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar, 10)).Value = obj.FechaInicial.Substring(6, 4) + obj.FechaInicial.Substring(3, 2) + obj.FechaInicial.Substring(0, 2);
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar)).Value = DBNull.Value;

                if (obj.FechaFinal != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = obj.FechaFinal.Substring(6, 4) + obj.FechaFinal.Substring(3, 2) + obj.FechaFinal.Substring(0, 2);
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                if (obj.CodigoCita != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@CodigoCita", SqlDbType.VarChar, 100)).Value = obj.CodigoCita;
                else
                    cmd.Parameters.Add(new SqlParameter("@CodigoCita", SqlDbType.VarChar, 100)).Value = DBNull.Value;

                if (obj.CodigoCliente != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.VarChar, 100)).Value = obj.CodigoCliente;
                else
                    cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                if (obj.Cliente != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 200)).Value = obj.Cliente;
                else
                    cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 200)).Value = DBNull.Value;


                if (obj.CodigoMascota != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@CodigoMascota", SqlDbType.VarChar, 100)).Value = obj.CodigoMascota;
                else
                    cmd.Parameters.Add(new SqlParameter("@CodigoMascota", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                if (obj.Mascota != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@Mascota", SqlDbType.VarChar, 200)).Value = obj.Mascota;
                else
                    cmd.Parameters.Add(new SqlParameter("@Mascota", SqlDbType.VarChar, 200)).Value = DBNull.Value;


                if (obj.CodigoEstado != string.Empty)
                    cmd.Parameters.Add(new SqlParameter("@CodigoEstado", SqlDbType.VarChar, 200)).Value = obj.CodigoEstado;
                else
                    cmd.Parameters.Add(new SqlParameter("@CodigoEstado", SqlDbType.VarChar, 200)).Value = DBNull.Value;


                if (obj.Tipo != 0)
                    cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.Int)).Value = obj.Tipo;
                else
                    cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.Int)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dap.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;
            }
        }

        public static DataTable BuscarEmpleados(string RolID, String detalleCitaID)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();


            try
            {
                cnn.Open();

                cmd.CommandText = "usp_EmpleadosRolID_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@RolID", SqlDbType.Int)).Value = RolID;
                cmd.Parameters.Add(new SqlParameter("@detalleCitaID", SqlDbType.VarChar,8000)).Value = detalleCitaID;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Empleados" + RolID);
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }


        public static DataSet BuscarCitaDetalleEmpleados(string idDetalleCita, String idServicio)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_getCitaDetalleEmpleados_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }


        #endregion



        #region Grabar

        public static string AnularProgramacion(Int32 idDetalleCita, Int32 idServicio, String MotivoAnulacion, String idCitas, SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_AnularProgramacion_i";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;
                cmd.Parameters.Add(new SqlParameter("@idCitas", SqlDbType.VarChar, 8000)).Value = idCitas;
                cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", SqlDbType.VarChar,500)).Value = MotivoAnulacion;
                

                return cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                cmd = null;
            }
        }

        public static string ActualizarProgramacion(Int32 idServicio, DataTable dtEmpleados, Int32 idDetalleCita,Int32 idSector ,String idCitas, SqlTransaction txOle)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "usp_ActualizarProgramacion_i";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = txOle.Connection;
                cmd.Transaction = txOle;

                cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;
                cmd.Parameters.Add(new SqlParameter("@idSector", SqlDbType.Int)).Value = idSector;
                cmd.Parameters.Add(new SqlParameter("@idCitas", SqlDbType.VarChar,8000)).Value = idCitas;
                cmd.Parameters.Add(new SqlParameter("@dtEmpleados", SqlDbType.Structured)).Value = dtEmpleados;
               
                return cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw;
            }
            finally
            {
                cmd = null;
            }
        }


        #endregion

        #endregion





        #region Metodos Actualizar Hoja de servicio

        #region Combos

      
        public static DataTable GetEstadosHS()
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_EstadosHS_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }


        #endregion


        public static DataSet BuscarServicioDetalle(int iddetalleCita)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_GestionHojaServicioDetalle_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (iddetalleCita > 0)
                    cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = iddetalleCita;
                else
                    cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt;
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }
    

        public static DataTable BuscarServicioHoy(Int32 codigo, String FechaInicial, String FechaFinal)
        {
            
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_GestionHojaServicio_gl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                
                     if (codigo>0)
                    cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = codigo;
                else
                    cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = DBNull.Value;

                if (FechaInicial != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar, 10)).Value = FechaInicial.Substring(6, 4) + FechaInicial.Substring(3, 2) + FechaInicial.Substring(0, 2);
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar)).Value = DBNull.Value;

                if (FechaFinal != String.Empty)
                    cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = FechaFinal.Substring(6, 4) + FechaFinal.Substring(3, 2) + FechaFinal.Substring(0, 2) ; 
                else
                    cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                dap.Fill(dt);

                return dt.Tables[0];
                dt = null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                cnn.Close();
                cnn = null;
                cmd = null;

            }
        }
        
    
        #endregion

    }
}
