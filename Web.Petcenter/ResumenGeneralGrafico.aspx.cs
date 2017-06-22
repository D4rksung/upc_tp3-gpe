using Negocio.Petcenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class ResumenGeneralGrafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                DataSet data = Negocio.Petcenter.Graficos.BuscarResumen();
                lblServicioHoy.Text = data.Tables[0].Rows[0]["ServicioHoy"].ToString();
                lblServicioPendientes.Text = data.Tables[0].Rows[0]["ServicioPendientes"].ToString();
                lblServicioFinalizados.Text = data.Tables[0].Rows[0]["ServicioFinalizados"].ToString();
                lblTotalEmpleados.Text = data.Tables[0].Rows[0]["TotalEmpleados"].ToString();
                CargarCombos();
                CargarGrid(0);
            }
        }
        void CargarCombos()
        {

            Utilidades.CargaCombo(ref cboGrafico1, AtencionPeluqueriaBuss.GetServicio(), "idServicio", "descripcion", true);
            Utilidades.CargaCombo(ref cbografico4, AtencionPeluqueriaBuss.GetRoles("0"), "idRol", "descripcion", true);
            Utilidades.CargaCombo(ref filtroservicio, AtencionPeluqueriaBuss.GetServicio(), "idServicio", "descripcion", true);
            
        }

        protected void cbografico4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid(Int32.Parse(cbografico4.SelectedValue));
        }
        void CargarGrid(Int32 valor)
        {
            DataSet data = Negocio.Petcenter.Graficos.BuscarGrafico4(valor);
            gvEmpleados.DataSource = data;
            gvEmpleados.DataBind();
        }
    }
}