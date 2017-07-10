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
        public static  DataTable GetDominioParametro(string dominio)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();


            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_Parametro_gl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@pisDominio", SqlDbType.Char, 3)).Value = dominio;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                Dt = new DataTable("DominioParametro" + dominio);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable BuscarMovimientosAtencion(int movimientoID)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerMaterialxAtencion";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@movimientoID", SqlDbType.Int)).Value = movimientoID;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable BuscarMaterialesPorCodigo(int codigo, Int32 almacenID)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerMaterialxCodigo";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = codigo;
                Cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static string GrabarMovimientoAtencion(DataTable dt, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_ActualizarRequerimientoAtencion";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@dtDetalle", SqlDbType.Structured)).Value = dt;

                return Cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }
        

        public static DataTable BuscarMaterialesGen(String codigo)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerMaterial";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;
                Cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar,10)).Value = codigo;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable BuscarMovimientos(Int32 almacenID, String fechaIni, String fechaFin, String motivoID, String tipoID, String estadoID, String NumReq)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarReqMaterial";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;
                
                    Cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;
                    Cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar, 10)).Value = fechaIni;
                    Cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 10)).Value = fechaFin;
                Cmd.Parameters.Add(new SqlParameter("@motivoID", SqlDbType.VarChar, 10)).Value = motivoID;
                Cmd.Parameters.Add(new SqlParameter("@tipoID", SqlDbType.VarChar, 10)).Value = tipoID;
                Cmd.Parameters.Add(new SqlParameter("@estadoID", SqlDbType.VarChar, 10)).Value = estadoID;
                Cmd.Parameters.Add(new SqlParameter("@NumReq", SqlDbType.VarChar, 100)).Value = NumReq;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable GetParametros(String codigo)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarParametroCombo";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (codigo != "0")
                    Cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar,10)).Value = codigo;
                else
                    Cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 10)).Value = DBNull.Value;
                

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;
            }
        }

    

        public static DataTable BuscarMateriales(int almacenID, string fechaIni, string fechaFin)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_KardexMaterialesgl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (almacenID != 0)
                    Cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;
                else
                    Cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = DBNull.Value;

                if (fechaIni != "")
                    Cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar,10)).Value = fechaIni;
                else
                    Cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                if (fechaFin != "")
                    Cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 10)).Value = fechaFin;
                else
                    Cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static string GrabarMovimientoTipo(int idMovimiento,String tipo, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_ActualizarRequerimientoTipo";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = idMovimiento;
                Cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar,10)).Value = tipo;


                return  Cmd.ExecuteNonQuery().ToString();
            }
            catch 
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        public static DataTable BuscarMaterialesMovimiento(int idMaterial)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_KardexMaterialesDetailgl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (idMaterial != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idMaterial", SqlDbType.Int)).Value = idMaterial;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idMaterial", SqlDbType.Int)).Value = DBNull.Value;

              

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                

                dap.Fill(Dt);

                return Dt;

            }
            catch 
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;
            }
        }

        public static DataSet BuscarMaterialesDispositivo(int idMovimiento, Int32 almacenID)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_GP_ListarReqMaterialDisponible";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (idMovimiento != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = idMovimiento;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = DBNull.Value;


                if (almacenID != 0)
                    Cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = almacenID;
                else
                    Cmd.Parameters.Add(new SqlParameter("@almacenID", SqlDbType.Int)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;
            }
        }

        public static DataTable GetcboTipoMov()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarTipoMovimiento";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable GetAlmacen()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarAlmacen";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        //busqueda de hoja de servicio
        public static DataTable BusquedaHojaServicio(HojaServicio hoja)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_HojaServicio_gl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (hoja.NumHojaServicio != 0)
                    Cmd.Parameters.Add(new SqlParameter("@NumHoja", SqlDbType.Int)).Value = hoja.NumHojaServicio;
                else
                    Cmd.Parameters.Add(new SqlParameter("@NumHoja", SqlDbType.Int)).Value = DBNull.Value;

                if (hoja.NombreCliente != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@NombreCliente", SqlDbType.VarChar, 250)).Value = hoja.NombreCliente;
                else
                    Cmd.Parameters.Add(new SqlParameter("@NombreCliente", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                if (hoja.IdServicio != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = hoja.IdServicio;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = DBNull.Value;


                if (hoja.FechaInicial != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = hoja.FechaInicial;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = DBNull.Value;

                if (hoja.FechaFinal != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = hoja.FechaFinal;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = DBNull.Value;

                if (hoja.IdCliente != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int)).Value = hoja.IdCliente;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();

                dap.Fill(Dt);

                return Dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
            }
        }

        public static string GrabarMovimiento(int idMovimiento, DataTable dtMateriales, String fechaMov, String tipoMov, String MotivoMov, Int32 idAlmacen,SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_ActualizarRequerimiento";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idMovimiento", SqlDbType.Int)).Value = idMovimiento;
                Cmd.Parameters.Add(new SqlParameter("@fechaMov", SqlDbType.VarChar,10)).Value = fechaMov;
                Cmd.Parameters.Add(new SqlParameter("@tipoMov", SqlDbType.VarChar,10)).Value = tipoMov;
                Cmd.Parameters.Add(new SqlParameter("@MotivoMov", SqlDbType.VarChar,10)).Value = MotivoMov;
                Cmd.Parameters.Add(new SqlParameter("@dtMateriales", SqlDbType.Structured)).Value = dtMateriales;
                Cmd.Parameters.Add(new SqlParameter("@idAlmacen", SqlDbType.Int)).Value = idAlmacen;

                return Cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }
    

        public static DataTable GrabarHojaDeServicioComents(Int32 idDetalleCita, String text)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_GP_InsertarHojaServicioComentario";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (idDetalleCita != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = DBNull.Value;

                if (idDetalleCita != 0)
                    Cmd.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar,5000)).Value = text;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Comments", SqlDbType.VarChar, 5000)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();

                dap.Fill(Dt);

                return Dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
            }
        }

        public static string ActualizarHojaServicioComents(int idDetalleCita, string text, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_InsertarHojaServicioComentario";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                Cmd.Parameters.Add(new SqlParameter("@Comments", SqlDbType.Int)).Value = text;
                Cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        public static string ActualizarHojaServicio(Int32 idDetalleCita, DataTable dt, String coments, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_InsertarHojaServicio";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                Cmd.Parameters.Add(new SqlParameter("@dtMaterial", SqlDbType.Structured)).Value = dt;
                Cmd.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar,5000)).Value = coments;
                Cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }

            return "OK";
        }

        //ingreso de hoja de servicio
        public static string InsertarHojaServicio(HojaServicio  objParam, SqlTransaction objTx)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_HojaServicio_i";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = objTx.Connection;
                Cmd.Transaction = objTx;

                Cmd.Parameters.Add(new SqlParameter("@idcita", SqlDbType.Int)).Value = objParam.IdCita;
                Cmd.Parameters.Add(new SqlParameter("@idEmpleado", SqlDbType.Int)).Value = objParam.IdEmpleado;
                Cmd.Parameters.Add(new SqlParameter("@numhojaservicio", SqlDbType.Int)).Value = objParam.NumHojaServicio;
                Cmd.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar,250)).Value = objParam.Observaciones;
                Cmd.Parameters.Add(new SqlParameter("@fechaRegistro", SqlDbType.Date)).Value = objParam.FechaEmision;
                Cmd.Parameters.Add(new SqlParameter("@Canil", SqlDbType.Char,3)).Value = objParam.Canil;
                Cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }
        



        //Modificar de hoja de servicio
        public static void ModificarHojaServicio(HojaServicio objParam, SqlTransaction objTx)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_HojaServicio_u";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = objTx.Connection;
                Cmd.Transaction = objTx;

                Cmd.Parameters.Add(new SqlParameter("@idHojaServicio", SqlDbType.Int)).Value = objParam.IdHojaServicio;
                if (objParam.FechaEmision != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaEmision", SqlDbType.Date)).Value = objParam.FechaEmision;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaEmision", SqlDbType.Date)).Value = DBNull.Value;

                Cmd.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 250)).Value = objParam.Observaciones;

                Cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        public static void AnularHojaServicio(HojaServicio objParam, SqlTransaction objTx)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_HojaServicio_d";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = objTx.Connection;
                Cmd.Transaction = objTx;

                Cmd.Parameters.Add(new SqlParameter("@idHojaServicio", SqlDbType.Int)).Value = objParam.IdHojaServicio;
                Cmd.ExecuteNonQuery();

            }
            catch 
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        public static DataSet GetDatosCita(int idCita)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_Cita_g";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@idCita", SqlDbType.Int)).Value = idCita;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        //busqueda de cita
        public static DataTable BusquedaCita(Cita cita)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_Cita_gl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;


                if (cita.FechaInicial != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = cita.FechaInicial;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = DBNull.Value;

                if (cita.FechaFinal != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = cita.FechaFinal;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = DBNull.Value;

                if (cita.Cliente != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 250)).Value = cita.Cliente;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();

                dap.Fill(Dt);

                return Dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
            }
        }

        public static DataSet GetDatosHojaServicioEjecutar(int idHojaServicio)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_HojaServicio_ge";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@idHojaServicio", SqlDbType.Int)).Value = idHojaServicio;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static void ActualizarDetalleHojaServicio(DetalleServicio detalle, SqlTransaction objTx)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_DetalleServicio_u";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = objTx.Connection;
                Cmd.Transaction = objTx;

                Cmd.Parameters.Add(new SqlParameter("@iddetalleHojaServicio", SqlDbType.Int)).Value = detalle.IdDetalleHojaServicio;

                if (detalle.HoraInicio != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@HoraInicio", SqlDbType.VarChar, 10)).Value = detalle.HoraInicio;
                else
                    Cmd.Parameters.Add(new SqlParameter("@HoraInicio", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                if (detalle.HoraFin != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@HoraFin", SqlDbType.VarChar, 10)).Value = detalle.HoraFin;
                else
                    Cmd.Parameters.Add(new SqlParameter("@HoraFin", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                Cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Char,3)).Value = detalle.Estado;
                Cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        //busqueda de hoja de servicio
        public static DataTable BusquedaKardexMaterial(KardexMaterial kardex)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_KardexMaterial_gl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (kardex.Material != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Material", SqlDbType.VarChar, 250)).Value = kardex.Material;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Material", SqlDbType.VarChar, 250)).Value = DBNull.Value;


                if (kardex.FechaInicial != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = kardex.FechaInicial;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date)).Value = DBNull.Value;

                if (kardex.FechaFinal != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = kardex.FechaFinal;
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date)).Value = DBNull.Value;

               
                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();

                dap.Fill(Dt);

                return Dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
            }
        }


        //ingreso de kardex de material
        public static string InsertarMovKardexMaterial(KardexMaterial objParam, SqlTransaction objTx)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_KardexMaterial_i";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = objTx.Connection;
                Cmd.Transaction = objTx;

                Cmd.Parameters.Add(new SqlParameter("@idMaterial", SqlDbType.Int)).Value = objParam.IdMaterial;
                Cmd.Parameters.Add(new SqlParameter("@FecMovimiento", SqlDbType.Date)).Value = objParam.FechaMovimiento;
                Cmd.Parameters.Add(new SqlParameter("@TipoMovimiento", SqlDbType.Char,3)).Value = objParam.TipoMovimiento;
                Cmd.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Decimal)).Value = objParam.Cantidad;
                Cmd.Parameters.Add(new SqlParameter("@PrecioCompra", SqlDbType.Decimal)).Value = objParam.PrecioCompra;
                Cmd.Parameters.Add(new SqlParameter("@DocumentoReferencia", SqlDbType.VarChar, 30)).Value = DbNullIfNull(objParam.NumGuia);
                Cmd.ExecuteNonQuery();

                return string.Empty;
            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        public static object DbNullIfNull(this object obj)
        {
            return ! string.IsNullOrEmpty(obj.ToString()) ? obj : DBNull.Value;
        }

        public static void AnularKardexMaterial(KardexMaterial objParam, SqlTransaction objTx)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_KardexMaterial_d";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = objTx.Connection;
                Cmd.Transaction = objTx;

                Cmd.Parameters.Add(new SqlParameter("@idKardexMaterial", SqlDbType.Int)).Value = objParam.IdKardexMaterial;
                Cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }

        public static DataTable GetDatosMaterial(int idmaterial)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_Material_g";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@idmaterial", SqlDbType.Int)).Value = idmaterial;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();
                dap.Fill(Dt);

                return Dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;

            }
        }

        //busqueda de cita
        public static DataTable BusquedaMaterial(Material mat)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_Material_gl";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;


                if (mat.Nombre != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar,250)).Value = mat.Nombre;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar,250)).Value = DBNull.Value;

                if (mat.DscMaterial != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@DscMaterial", SqlDbType.Date)).Value = mat.DscMaterial;
                else
                    Cmd.Parameters.Add(new SqlParameter("@DscMaterial", SqlDbType.Date)).Value = DBNull.Value;

                if (mat.Modelo != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 250)).Value = mat.Modelo;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                if (mat.Categoria != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 250)).Value = mat.Categoria;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 250)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();

                dap.Fill(Dt);

                return Dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
            }
        }




      
     



        #region Metodos Actualizar Programacion Inicio
        #region Combos

        public static DataTable GetEstadosCita()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarEstadoCita";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable GetSectores(String idServicio)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarSector";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;
                Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable GetRoles(String idServicio)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarRol";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;
                Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable GetEmpleados()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarEmpleado";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);
                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable GetServicio()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarServicio";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        #endregion

        #region Busqueda


        public static DataSet BuscarCitaDetalle(int idCita)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerCitaDetalle";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@idCita", SqlDbType.Int)).Value = idCita;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataSet BuscarCitaDetalleCompleto(int idCita)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerCitaDetalleCompleto";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@idCita", SqlDbType.Int)).Value = idCita;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable BuscarCita(Cita obj)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();
                Cmd.CommandText = "usp_GP_BuscarProgramacionCita";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (obj.FechaInicial != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar, 10)).Value = obj.FechaInicial.Substring(6, 4) + obj.FechaInicial.Substring(3, 2) + obj.FechaInicial.Substring(0, 2);
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar)).Value = DBNull.Value;

                if (obj.FechaFinal != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = obj.FechaFinal.Substring(6, 4) + obj.FechaFinal.Substring(3, 2) + obj.FechaFinal.Substring(0, 2);
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = DBNull.Value;

                if (obj.CodigoCita != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@CodigoCita", SqlDbType.VarChar, 100)).Value = obj.CodigoCita;
                else
                    Cmd.Parameters.Add(new SqlParameter("@CodigoCita", SqlDbType.VarChar, 100)).Value = DBNull.Value;

                if (obj.CodigoCliente != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.VarChar, 100)).Value = obj.CodigoCliente;
                else
                    Cmd.Parameters.Add(new SqlParameter("@CodigoCliente", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                if (obj.Cliente != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 200)).Value = obj.Cliente;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 200)).Value = DBNull.Value;


                if (obj.CodigoMascota != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@CodigoMascota", SqlDbType.VarChar, 100)).Value = obj.CodigoMascota;
                else
                    Cmd.Parameters.Add(new SqlParameter("@CodigoMascota", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                if (obj.Mascota != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@Mascota", SqlDbType.VarChar, 200)).Value = obj.Mascota;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Mascota", SqlDbType.VarChar, 200)).Value = DBNull.Value;


                if (obj.CodigoEstado != string.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@CodigoEstado", SqlDbType.VarChar, 200)).Value = obj.CodigoEstado;
                else
                    Cmd.Parameters.Add(new SqlParameter("@CodigoEstado", SqlDbType.VarChar, 200)).Value = DBNull.Value;


                if (obj.Tipo != 0)
                    Cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.Int)).Value = obj.Tipo;
                else
                    Cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.Int)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();

                dap.Fill(Dt);

                return Dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
            }
        }

        public static DataTable BuscarEmpleados(string rolID, String detalleCitaID)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable("Empleados" + rolID);


            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarEmpleadoRol";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@RolID", SqlDbType.Int)).Value = rolID;
                Cmd.Parameters.Add(new SqlParameter("@detalleCitaID", SqlDbType.VarChar,8000)).Value = detalleCitaID;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        public static DataSet BuscarCitaDetalleEmpleados(string idDetalleCita, String idServicio)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerCitaDetalleEmpleado";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt;
               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        #endregion



        #region Grabar

        public static string AnularProgramacion(Int32 idDetalleCita, Int32 idServicio, String MotivoAnulacion, String idCitas, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_AnularProgramacion";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;
                Cmd.Parameters.Add(new SqlParameter("@idCitas", SqlDbType.VarChar, 8000)).Value = idCitas;
                Cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", SqlDbType.VarChar,500)).Value = MotivoAnulacion;
                

                return Cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                Cmd = null;
            }
        }

        public static string ActualizarProgramacion(Int32 idServicio, DataTable dtEmpleados, Int32 idDetalleCita,Int32 idSector ,String idCitas, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_ActualizarProgramacion";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                Cmd.Parameters.Add(new SqlParameter("@idServicio", SqlDbType.Int)).Value = idServicio;
                Cmd.Parameters.Add(new SqlParameter("@idSector", SqlDbType.Int)).Value = idSector;
                Cmd.Parameters.Add(new SqlParameter("@idCitas", SqlDbType.VarChar,8000)).Value = idCitas;
                Cmd.Parameters.Add(new SqlParameter("@dtEmpleados", SqlDbType.Structured)).Value = dtEmpleados;
               
                return Cmd.ExecuteNonQuery().ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
                throw;
            }
            finally
            {
                Cmd = null;
            }
        }


        #endregion

        #endregion





        #region Metodos Actualizar Hoja de servicio

        #region Combos

      
        public static DataTable GetEstadosHS()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarEstadoHojaServicio";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);
                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        #endregion


        public static DataSet BuscarServicioDetalle(int idDetalleCita)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarHojaServicioDetalle";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (idDetalleCita > 0)
                    Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = idDetalleCita;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = DBNull.Value;

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }
    

        public static DataTable BuscarServicioHoy(Int32 codigo, String fechaInicial, String fechaFinal)
        {
            
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarHojaServicio";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;
                
                     if (codigo>0)
                    Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = codigo;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idDetalleCita", SqlDbType.Int)).Value = DBNull.Value;

                if (fechaInicial != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar, 10)).Value = fechaInicial.Substring(6, 4) + fechaInicial.Substring(3, 2) + fechaInicial.Substring(0, 2);
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaInicial", SqlDbType.VarChar)).Value = DBNull.Value;

                if (fechaFinal != String.Empty)
                    Cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = fechaFinal.Substring(6, 4) + fechaFinal.Substring(3, 2) + fechaFinal.Substring(0, 2) ; 
                else
                    Cmd.Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.VarChar, 10)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                
                dap.Fill(Dt);

                return Dt.Tables[0];
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        #endregion







        public static DataTable GetParametrosGEN(String tipo)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ListarParametroComboGEN";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (tipo != "0")
                    Cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 100)).Value = tipo;
                else
                    Cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataSet BuscarSectorDetalle(Int32 idSector)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_BuscarSectorDetalle";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (idSector != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idSector", SqlDbType.VarChar, 100)).Value = idSector;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idSector", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataSet BuscarCanilDetalle(int idCanil)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataSet Dt = new DataSet();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_BuscarCanilDetalle";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                if (idCanil != 0)
                    Cmd.Parameters.Add(new SqlParameter("@idCanil", SqlDbType.VarChar, 100)).Value = idCanil;
                else
                    Cmd.Parameters.Add(new SqlParameter("@idCanil", SqlDbType.VarChar, 100)).Value = DBNull.Value;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static  DataTable BuscarCanil(Int32 tipo, String fechaIni, String fechaFin, String recurso, String estado)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_BuscarCanil";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;
                
                Cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 100)).Value = tipo;
                Cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar, 100)).Value = fechaIni;
                Cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 100)).Value = fechaFin;
                Cmd.Parameters.Add(new SqlParameter("@Recurso", SqlDbType.VarChar, 100)).Value = recurso;
                Cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 100)).Value = estado;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }

        public static DataTable BuscarSector(Int32 tipo, String fechaIni, String fechaFin, String recurso, String estado)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();
            DataTable Dt = new DataTable();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_BuscarSector";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 100)).Value = tipo;
                Cmd.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar, 100)).Value = fechaIni;
                Cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar, 100)).Value = fechaFin;
                Cmd.Parameters.Add(new SqlParameter("@Recurso", SqlDbType.VarChar, 100)).Value = recurso;
                Cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 100)).Value = estado;


                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(Dt);

                return Dt;
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
            finally
            {
                Cnn.Close();
                Cnn = null;
                Cmd = null;
                Dt = null;

            }
        }


        public static string GrabarEliminarCanilSector(int id, string tipo, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_EliminarCanilSector";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                Cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 10)).Value = tipo;


                return Cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                Cmd = null;
            }
        }
        public static string GrabarCanil(int idCanil, string tamanio, string especie, string estado, string observaciones, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_InsertarCanil";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idCanil", SqlDbType.Int)).Value = idCanil;
                Cmd.Parameters.Add(new SqlParameter("@tamanio", SqlDbType.VarChar, 10)).Value = tamanio;
                Cmd.Parameters.Add(new SqlParameter("@especie", SqlDbType.VarChar, 10)).Value = especie;
                Cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 10)).Value = estado;
                Cmd.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.VarChar, 8000)).Value = observaciones;


                return Cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                Cmd = null;
            }
        }

        public static string GrabarSector(int idSector, string servicio, string estado, string observaciones, SqlTransaction txOle)
        {
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cmd.CommandText = "usp_GP_InsertarSector";

                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = txOle.Connection;
                Cmd.Transaction = txOle;

                Cmd.Parameters.Add(new SqlParameter("@idSector", SqlDbType.Int)).Value = idSector;
                Cmd.Parameters.Add(new SqlParameter("@servicio", SqlDbType.VarChar, 10)).Value = servicio;
                Cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 10)).Value = estado;
                Cmd.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.VarChar, 8000)).Value = observaciones;


                return Cmd.ExecuteNonQuery().ToString();
            }
            catch 
            {
                return "";
            }
            finally
            {
                Cmd = null;
            }
        }

    }
}

