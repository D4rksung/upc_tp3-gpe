using Negocio.Petcenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class ResumenGeneralGrafico2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindChart();
                BindChart2();

            }
        }
        private void BindChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = Negocio.Petcenter.Graficos.ObtenerGraficaRent1().Tables[0]; 

                strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});</script>

                    <script type='text/javascript'>
                    function drawVisualization() {       
                    var data = google.visualization.arrayToDataTable([
                    ['"+ dsChartData.Rows[0]["ID"] + "', '" + dsChartData.Rows[0]["TEXTO1"] + "', '" + dsChartData.Rows[0]["TEXTO2"] + "', '" + dsChartData.Rows[0]["TEXTO3"] + "', '" + dsChartData.Rows[0]["TEXTO4"] + "', '" + dsChartData.Rows[0]["TEXTO5"] + "'],");
               
                dsChartData.Rows.RemoveAt(0);
                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["ID"] + "'," + row["TEXTO1"] + "," +
                        row["TEXTO2"] + "," + row["TEXTO3"] + "," + row["TEXTO4"] + "," + row["TEXTO5"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : '', vAxis: {title: ''},  hAxis: {title: 'Meses'}, seriesType: 'bars', series: {4: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");

                ltScripts.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        private void BindChart2()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = Negocio.Petcenter.Graficos.ObtenerGraficaRent2().Tables[0];

                strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});</script>

                    <script type='text/javascript'>
                    function drawVisualization() {       
                    var data = google.visualization.arrayToDataTable([
                    ['" + dsChartData.Rows[0]["ID"] + "', '" + dsChartData.Rows[0]["TEXTO1"] + "', '" + dsChartData.Rows[0]["TEXTO2"] + "', '" + dsChartData.Rows[0]["TEXTO3"] +  "'],");

                dsChartData.Rows.RemoveAt(0);
                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["ID"] + "'," + row["TEXTO1"] + "," +
                        row["TEXTO2"] + "," + row["TEXTO3"] +  "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : '', vAxis: {title: ''},  hAxis: {title: 'Meses'}, seriesType: 'bars', series: {2: {type: 'area'}} };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div2'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");

                ltScripts2.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        void CargarCombos()
        {
            
        }

      
    }
}