using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos.Petcenter
{
    public class Graficos
    {

        public static DataSet ObtenerGraficaDemandaSemanal(string idServicio)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerGrafica1";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20)).Value = idServicio;

                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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

        public static DataSet ObtenerGraficaRent2()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "up_graficoRENT_2";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;


                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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

        public static DataSet ObtenerGraficaRent1()
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "up_graficoRENT_1";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;


                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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
        public static DataSet BuscarGrafico4(Int32 opcion)
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerGrafico4";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = opcion;

                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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

        public static DataSet BuscarResumen()
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerResumen";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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

        public static DataSet ObtenerGraficaIndicadorDeActividadPorEmpleado(string opcion)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerGrafica2";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20)).Value = opcion;

                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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

        public static DataSet ObtenerGraficaIndicadorDeEficienciaDeRecurso(string opcion)
        {
            //Shared
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection Cnn = new SqlConnection(Conn);
            SqlCommand Cmd = new SqlCommand();

            try
            {
                Cnn.Open();

                Cmd.CommandText = "usp_GP_ObtenerGrafica3";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Cnn;

                Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20)).Value = opcion;

                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataSet Dt = new DataSet();
                Dap.Fill(Dt);

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

    }
}
