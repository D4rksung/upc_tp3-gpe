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

        public static DataSet ObtenerGrafica1(string idServicio)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ObtenerGrafica1_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar,20)).Value = idServicio;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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

        public static DataSet BuscarGrafico4(Int32 opcion)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ObtenerGrafico4_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = opcion;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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

        public static DataSet BuscarResumen()
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ObtenerResumen_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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

        public static DataSet ObtenerGrafica2(string opcion)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ObtenerGrafica2_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20)).Value = opcion;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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

        public static DataSet ObtenerGrafica3(string opcion)
        {
            //Shared
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ToString();
            SqlConnection cnn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();

                cmd.CommandText = "usp_ObtenerGrafica3_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20)).Value = opcion;

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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

    }
}
