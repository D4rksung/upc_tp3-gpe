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
            DataTable ChartData = new DataTable();
            StringBuilder Script = new StringBuilder();

            try
            {
                ChartData = Negocio.Petcenter.Graficos.ObtenerGraficaRent1().Tables[0]; 

                Script.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});</script>

                    <script type='text/javascript'>
                    function drawVisualization() {       
                    var data = google.visualization.arrayToDataTable([
                    ['"+ ChartData.Rows[0]["ID"] + "', '" + ChartData.Rows[0]["TEXTO1"] + "', '" + ChartData.Rows[0]["TEXTO2"] + "', '" + ChartData.Rows[0]["TEXTO3"] + "', '" + ChartData.Rows[0]["TEXTO4"] + "', '" + ChartData.Rows[0]["TEXTO5"] + "'],");

                ChartData.Rows.RemoveAt(0);
                foreach (DataRow row in ChartData.Rows)
                {
                    Script.Append("['" + row["ID"] + "'," + row["TEXTO1"] + "," +
                        row["TEXTO2"] + "," + row["TEXTO3"] + "," + row["TEXTO4"] + "," + row["TEXTO5"] + "],");
                }
                Script.Remove(Script.Length - 1, 1);
                Script.Append("]);");

                Script.Append("var options = { title : '', vAxis: {title: ''},  hAxis: {title: 'Meses'}, seriesType: 'bars', series: {4: {type: 'area'}} };");
                Script.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                Script.Append(" </script>");

                ltScripts.Text = Script.ToString();
            }
            catch
            {
            }
            finally
            {
                ChartData.Dispose();
                Script.Clear();
            }
        }

        private void BindChart2()
        {
            DataTable ChartData = new DataTable();
            StringBuilder Script = new StringBuilder();

            try
            {
                ChartData = Negocio.Petcenter.Graficos.ObtenerGraficaRent2().Tables[0];

                Script.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});</script>

                    <script type='text/javascript'>
                    function drawVisualization() {       
                    var data = google.visualization.arrayToDataTable([
                    ['" + ChartData.Rows[0]["ID"] + "', '" + ChartData.Rows[0]["TEXTO1"] + "', '" + ChartData.Rows[0]["TEXTO2"] + "', '" + ChartData.Rows[0]["TEXTO3"] +  "'],");

                ChartData.Rows.RemoveAt(0);
                foreach (DataRow row in ChartData.Rows)
                {
                    Script.Append("['" + row["ID"] + "'," + row["TEXTO1"] + "," +
                        row["TEXTO2"] + "," + row["TEXTO3"] +  "],");
                }
                Script.Remove(Script.Length - 1, 1);
                Script.Append("]);");

                Script.Append("var options = { title : '', vAxis: {title: ''},  hAxis: {title: 'Meses'}, seriesType: 'bars', series: {2: {type: 'area'}} };");
                Script.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div2'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                Script.Append(" </script>");

                ltScripts2.Text = Script.ToString();
            }
            catch
            {
            }
            finally
            {
                ChartData.Dispose();
                Script.Clear();
            }
        }

        void CargarCombos()
        {
            
        }

      
    }
}