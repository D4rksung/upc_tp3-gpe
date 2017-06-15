using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Petcenter;
using Negocio.Petcenter;
using Utilitario.Comun;
using System.Data;

namespace Web.Petcenter
{
    public partial class ActualizarKardexMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarKardex();
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarKardexMaterial.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListarKardex();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }

        private void ListarKardex()
        {
            KardexMaterial kardex = new KardexMaterial();

            kardex.FechaInicial = txtfechaInicio.Text;
            kardex.FechaFinal = txtFechaFin.Text;
            kardex.Material = txtnombrematerial.Text;

            DataTable data = AtencionPeluqueriaBuss.BusquedaKardexMaterial(kardex);
            ViewState["_datagrilla"] = data;

            if (data.Rows.Count == 0)
                lblmsg.Text = "Sin registros para mostrar";
            else
                lblmsg.Text = "";

            this.grvIngresoMateriales.DataSource = data;
            this.grvIngresoMateriales.DataBind();
        }

        protected void grvIngresoMateriales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Anular")
            {
                try
                {
                    int idkardex = Utilidades.ToInt(e.CommandArgument.ToString());
                    GridViewRow gvr = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                    int RowIndex = gvr.RowIndex;

                    KardexMaterial kardex = new KardexMaterial() { idKardexMaterial = idkardex };
                    AtencionPeluqueriaBuss.GrabarKardexMaterial(kardex, 2);
                    ListarKardex();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
                }


            }
        }


        protected void grvIngresoMateriales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grvIngresoMateriales.PageIndex = e.NewPageIndex;
            this.grvIngresoMateriales.DataSource = ViewState["_datagrilla"];
            this.grvIngresoMateriales.DataBind();
        }


    }
}