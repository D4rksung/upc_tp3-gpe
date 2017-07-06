using Entidades.Petcenter;
using Negocio.Petcenter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Web.Petcenter
{
    /// <summary>
    /// Summary description for ServicioGraficas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServicioGraficas : System.Web.Services.WebService
    {

        [WebMethod]
        public string ObtenerGraficaDemandaSemanal(string idServcio)
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGraficaDemandaSemanal(idServcio);
            data.Tables[0].TableName = "Servicios";
            data.Tables[1].TableName = "Etiquetas";
            daresult= JsonConvert.SerializeObject(data);
            return daresult;

        }

        [WebMethod]
        public string ObtenerGraficaIndicadorDeActividadPorEmpleado(string opcion)
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGraficaIndicadorDeActividadPorEmpleado(opcion);
            data.Tables[0].TableName = "Empleado";
            daresult = JsonConvert.SerializeObject(data);
            return daresult;

        }

        [WebMethod]
        public string ObtenerGraficaIndicadorDeEficienciaDeRecurso(string sede)
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGraficaIndicadorDeEficienciaDeRecurso(sede);
            data.Tables[0].TableName = "Sede";
            daresult = JsonConvert.SerializeObject(data);
            return daresult;

        }


        [WebMethod]
        public string GraficoRent1()
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGraficaRent1();
            data.Tables[0].TableName = "RentxSede";
            daresult = JsonConvert.SerializeObject(data);
            return daresult;

        }
      
    }
}
