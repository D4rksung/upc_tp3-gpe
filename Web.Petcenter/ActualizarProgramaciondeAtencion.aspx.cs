using Entidades.Petcenter;
using Negocio.Petcenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class ActualizarProgramaciondeAtencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CargaCombo();

            }
        }

        private void CargaCombo()
        {
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetEstadosCita(), "idEstado", "descripcion", true);
        }
        protected void btnBuscarCita_Click(object sender, EventArgs e)
        {


            lblModalTitle.Text = "Buscar Cita";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
        protected void btnMascota_Click(object sender, EventArgs e)
        {

            lblModalTitleMasc.Text = "Buscar Mascota";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMasc", "$('#myModalMasc').modal();", true);
            upModalMasc.Update();
        }

        protected void btnBuscarCitaMasc_Click(object sender, EventArgs e)
        {

            Cita obj = new Cita();
            obj.CodigoCliente = txtCodigoClienteMasc.Text;
            obj.Cliente = txtnombreclienteMasc.Text;
            obj.CodigoMascota = txtCodigoMascotaMasc.Text;
            obj.Mascota = txtnombreMascotaMasc.Text;
            obj.Tipo = 2;
            DataTable data = AtencionPeluqueriaBuss.BuscarCita(obj);


            this.grvResultadoMascPopup.DataSource = data;
            this.grvResultadoMascPopup.DataBind();
            lblModalTitleMasc.Text = "Buscar Mascota";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMasc", "$('#myModalMasc').modal();", true);
            upModalMasc.Update();
        }

        protected void btnBuscarCitaCita_Click(object sender, EventArgs e)
        {
            Cita obj = new Cita();
            obj.FechaInicial = txtFechaInicioCita.Text;
            obj.FechaFinal = txtFechaFinCita.Text;
            obj.CodigoCita = txtCodigoCitaCita.Text;
            obj.CodigoCliente = txtCodigoClienteCita.Text;
            obj.Cliente = txtnombreclienteCita.Text;
            obj.CodigoMascota = txtCodigoMascotaCita.Text;
            obj.Mascota = txtnombreMascotaCita.Text;
            obj.Tipo = 2;
            DataTable data = AtencionPeluqueriaBuss.BuscarCita(obj);


            this.grvResultadoPopup.DataSource = data;
            this.grvResultadoPopup.DataBind();
            lblModalTitle.Text = "Buscar Cita";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
        protected void grvResultadoPopup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EJECUTAR
            if (e.CommandName == "Seleccionar")
            {
                txtCodigoCita.Text = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "AsignarValor(1, '" + e.CommandArgument.ToString() + "' );", true);
                //EDITAR
            }



        }
        protected void grvResultadoMascPopup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Seleccionar
            if (e.CommandName == "Seleccionar")
            {
                txtCodigoMascota.Text = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMasc", "$('#myModalMasc').modal('hide');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "AsignarValor(2, '" + e.CommandArgument.ToString() + "' );", true);
                //EDITAR
            }



        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cita obj = new Cita();
            obj.CodigoCita = txtCodigoCita.Text;
            obj.CodigoMascota = txtCodigoMascotaMasc.Text;
            obj.FechaInicial = txtFechaInicioCita.Text;
            obj.FechaFinal = txtFechaFinCita.Text;
            obj.CodigoEstado = cboEstado.SelectedValue;
            obj.Tipo = 2;


            DataTable data = AtencionPeluqueriaBuss.BuscarCita(obj);


            this.grvresultado.DataSource = data;
            this.grvresultado.DataBind();
        }

        protected void btnProgramarCita_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProgramaciondeAtencion.aspx?mode=1&upd=0&id=0");
        }

        protected void btnProgramacion_Click(object sender, EventArgs e)
        {
            if (grvresultado.SelectedDataKey == null)
            {
                lblErrorTitulo.Text = "ERROR";
                lblError.Text = "Debe seleccionar un registro para editar la programación de cita.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalError", "$('#myModalError').modal();", true);
                upModalError.Update();
            }
            else
            {
                Response.Redirect("MantenimientoProgramaciondeAtencion.aspx?mode=2&upd=0&id=" + grvresultado.SelectedDataKey.Values[0]);
            }
        }

        protected void btnAnularProgramacion_Click(object sender, EventArgs e)
        {
            if (grvresultado.SelectedDataKey == null)
            {
                lblErrorTitulo.Text = "ERROR";
                lblError.Text = "Debe seleccionar un registro para anular la programación de cita.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalError", "$('#myModalError').modal();", true);
                upModalError.Update();
            }
            else
            {
                Response.Redirect("MantenimientoProgramaciondeAtencion.aspx?mode=3&upd=0&id=" + grvresultado.SelectedDataKey.Values[0]);
            }
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.grvresultado, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Seleccionar";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvresultado.Rows)
            {
                if (row.RowIndex == grvresultado.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Seleccionar";
                }
            }
        }
    }
}