using Datos.Petcenter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio.Petcenter
{
   public class ProgramacionCita :IProgramacion
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

    }
}
