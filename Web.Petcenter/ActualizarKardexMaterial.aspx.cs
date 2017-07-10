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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Text.StringBuilder msgError = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    ListarKardex();

                }
                catch (Exception ex)
                {
                    msgError.Clear();
                    msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                    msgError.AppendLine("Descripción:" + ex.Message);
                    msgError.AppendLine("Detalle:" + ex.StackTrace);
                    log.Error(msgError.ToString());
                }
                
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
            KardexMaterial Kardex = new KardexMaterial();

            Kardex.FechaInicial = txtfechaInicio.Text;
            Kardex.FechaFinal = txtFechaFin.Text;
            Kardex.Material = txtnombrematerial.Text;

            DataTable Data = AtencionPeluqueriaBuss.BusquedaKardexMaterial(Kardex);
            ViewState["_datagrilla"] = Data;

            if (Data.Rows.Count == 0)
                lblmsg.Text = "Sin registros para mostrar";
            else
                lblmsg.Text = "";

            this.grvIngresoMateriales.DataSource = Data;
            this.grvIngresoMateriales.DataBind();
        }

        protected void grvIngresoMateriales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Anular")
            {
                try
                {
                    int Idkardex = Utilidades.ToInt(e.CommandArgument.ToString());
                    GridViewRow Gvr = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                    int FilaIndex = Gvr.RowIndex;

                    KardexMaterial kardex = new KardexMaterial() { IdKardexMaterial = Idkardex };
                    AtencionPeluqueriaBuss.GrabarKardexMaterial(kardex, 2);
                    ListarKardex();
                }
                catch 
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