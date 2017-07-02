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
        public string Grafico1(string idServcio)
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGrafica1(idServcio);
            data.Tables[0].TableName = "Servicios";
            data.Tables[1].TableName = "Etiquetas";
            daresult= JsonConvert.SerializeObject(data);
            return daresult;

        }

        [WebMethod]
        public string Grafico2(string opcion)
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGrafica2(opcion);
            data.Tables[0].TableName = "Empleado";
            daresult = JsonConvert.SerializeObject(data);
            return daresult;

        }

        [WebMethod]
        public string Grafico3(string sede)
        {
            String daresult = null;
            DataSet data = Negocio.Petcenter.Graficos.ObtenerGrafica3(sede);
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
        [WebMethod]

    public string[] GetMateriales(string prefixText, int count)

    {

        if (count == 0)

        {

            count = 10;

      }

            DataTable dt = AtencionPeluqueriaBuss.BuscarMaterialesGen();

            List<string> items = new List<string>(count);

 

        for (int i = 0; i<dt.Rows.Count; i++)

        {

            string strName = dt.Rows[i][0].ToString();

            items.Add(strName);

        }

        return items.ToArray();

    }

    }
}
