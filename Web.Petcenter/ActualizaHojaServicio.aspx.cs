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
    public partial class ActualizaHojaServicio : System.Web.UI.Page
    {
        Int32 marcaGrid = 0;
        public static DataTable dtComents = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //txtfechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarDetalle();
            }
        }

        void CargarDetalle()
        {
            DataTable data = AtencionPeluqueriaBuss.BuscarServicioHoy(0, txtfechaIni.Text, txtFechaFinal.Text);
            grvresultado.DataSource = data;
            grvresultado.DataBind();

        }

        void CargarDataDetalle(Int32 idHojaServicio, Int32 tipo)
        {
            idTipo.Value = tipo.ToString();
            DataSet data = AtencionPeluqueriaBuss.BuscarServicioDetalle(idHojaServicio);

            if (tipo == 0)
            {
                btnEjecutar.Visible = false;
                btnGuardarP.Visible = false;
                txtComent.Visible = false;
                btnSend.Visible = false;
                gvMateriales.Enabled = false;
                txtComent.Rows = 6;
            }
            else if (tipo == 1)
            {
                btnEjecutar.Visible = true;
                btnGuardarP.Visible = false;
                txtComent.Visible = true;
                btnSend.Visible = false;
                gvMateriales.Enabled = true;
                txtComent.Rows = 2;
            }
            else
            {
                btnEjecutar.Visible = false;
                btnGuardarP.Visible = true;
                txtComent.Visible = true;
                txtComent.Rows = 1;
                btnSend.Visible = false;
                gvMateriales.Enabled = true;
            }
            if (data.Tables[0].Rows.Count > 0)
            {
                imgMascota.ImageUrl = data.Tables[0].Rows[0]["Foto"].ToString();

                txtNombreMascota.Text = data.Tables[0].Rows[0]["nombreMascota"].ToString();
                txtEspecieMascota.Text = data.Tables[0].Rows[0]["especieMascota"].ToString();
                txtRazaMascota.Text = data.Tables[0].Rows[0]["razaMascota"].ToString();
                txtAlertas.Text = data.Tables[0].Rows[0]["observaciones"].ToString();
                txtEstado.Text = data.Tables[0].Rows[0]["estado"].ToString();
                txtServicio.Text = data.Tables[0].Rows[0]["Servicio"].ToString();
                lblModalPTitle2.Text = txtServicio.Text;
                gvComents.DataSource = data.Tables[2];
                gvComents.DataBind();
                dtComents = data.Tables[2];

                gvMateriales.DataSource = data.Tables[1];
                gvMateriales.DataBind();

                gvTracking.DataSource = data.Tables[3];
                gvTracking.DataBind();
            }  //detalle

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        protected void grvresultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvresultado, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Ver Detalle";

                Int32 horaCita = Int32.Parse(grvresultado.DataKeys[e.Row.RowIndex].Values[1].ToString().Split(':')[0]);
                String fechaCita = grvresultado.DataKeys[e.Row.RowIndex].Values[2].ToString();
                DateTime dt = new DateTime(Int32.Parse(fechaCita.Substring(6, 4)), Int32.Parse(fechaCita.Substring(3, 2)), Int32.Parse(fechaCita.Substring(0, 2)));
                DateTime dtActual = DateTime.Now;

                Int32 horaActual = DateTime.Now.Hour;
                if (horaActual < horaCita && marcaGrid < 2 && dt.ToShortDateString() == dtActual.ToShortDateString())
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#E8E5F5");
                    marcaGrid++;
                }


            }
        }
        protected void grvresultado_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvresultado.Rows)
            {

                if (row.RowIndex == grvresultado.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                    row.ToolTip = string.Empty;
                    //divDetalle.Visible = true;
                    //divDetalle.Style.Add("width", "380px");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                    //upModalConfirmacion.Update();
                    CargarDataDetalle(Int32.Parse(grvresultado.SelectedDataKey.Values[0].ToString()), 0);
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Ver Detalle";
                }
            }
        }
        protected void grvresultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ejecutar")
            {
                idHojaServicio.Value = e.CommandArgument.ToString();
                CargarDataDetalle(Int32.Parse(idHojaServicio.Value), 1);

                lblModalPTitle.Text = "Hoja de servicio peluquería";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
                //EDITAR
            }
            if (e.CommandName == "Finalizar")
            {
                idHojaServicio.Value = e.CommandArgument.ToString();

                CargarDataDetalle(Int32.Parse(idHojaServicio.Value), 2);
                lblModalPTitle.Text = "Hoja de servicio peluquería";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
            }
        }

        protected void btnGuardarP_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaterialID");
            dt.Columns.Add("Cantidad", typeof(Int32));

            foreach (GridViewRow gvRow in gvMateriales.Rows)
            {
                DataRow dr = dt.NewRow();
                Int32 rowIndex = gvRow.RowIndex;
                Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                Int32 idTipo = (Int32)gvMateriales.DataKeys[rowIndex]["idUnidadMedida"];
                TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                CheckBox chkCantidad = (CheckBox)gvRow.Cells[0].FindControl("chkCantidad");
                dr[0] = idMaterial;
                dr[1] =  (idTipo == 1 ? (chkCantidad.Checked ? "1":"0"): txtCantidad.Text) ;
                dt.Rows.Add(dr);

            }
            if (dt.Select("Cantidad>0").Count() == 0)
            {
                lblModalValTitle.Text = "ERROR";
                lblVal.Text = "Error: Debe de ingresar al menos la cantidad de un material que se utilizó para el servicio";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }
            else
            {
                if (gvComents.Rows.Count > 0 || txtComent.Text != "")
                {
                    if ((new ProgramacionCita()).GrabarHojadeServicio(Int32.Parse(idHojaServicio.Value), dt, txtComent.Text) != null)
                    {

                        lblMensajeTitulo.Text = "MENSAJE INFORMATIVO";
                        lblMensaje.Text = "Informativo: Se procedió a finalizar el servicio.";
                        lblMensaje.ForeColor = System.Drawing.Color.Blue;
                        txtComent.Text = "";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                        upModalMensaje.Update();
                        ActualizarParent();

                    }
                    else
                    {


                        lblModalValTitle.Text = "ERROR";
                        lblVal.Text = "Ocurrio un error al grabar. Favor comunicarse con el administrador del sistema.";
                        lblVal.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                        upModalVal.Update();

                    }

                }
                else
                {

                    lblModalValTitle.Text = "ERROR";
                    lblVal.Text = "Debe de ingresar comentario sobre lo realizado para finalizar el servicio";

                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();
                }
            }
        }
        void ActualizarParent()
        {


            string script = "$(document).ready(function () { $('[id*=btnBuscar]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM", "UpdateDatos();", true);
            ActualizarParent();

        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
           

        }
        

        protected void btnSend_Click(object sender, EventArgs e)
        {

            gvComents.DataSource = ((new ProgramacionCita()).GrabarHojadeServicioComents(Int32.Parse(idHojaServicio.Value), txtComent.Text));
            gvComents.DataBind();
            txtComent.Text = "";
            upModalP.Update();
        }
        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado.PageIndex = e.NewPageIndex;
            CargarDetalle();
        }
        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaterialID");
            dt.Columns.Add("Cantidad", typeof(Int32));

            foreach (GridViewRow gvRow in gvMateriales.Rows)
            {
                DataRow dr = dt.NewRow();
                Int32 rowIndex = gvRow.RowIndex;
                Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                Int32 idTipo = (Int32)gvMateriales.DataKeys[rowIndex]["idUnidadMedida"];
                TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                CheckBox chkCantidad = (CheckBox)gvRow.Cells[0].FindControl("chkCantidad");
                dr[0] = idMaterial;
                dr[1] = (idTipo == 1 ? (chkCantidad.Checked ? "1" : "0") : txtCantidad.Text);
                dt.Rows.Add(dr);

            }

            if ((new ProgramacionCita()).GrabarHojadeServicio(Int32.Parse(idHojaServicio.Value), dt, txtComent.Text ) != null)
            {
                String mensaje = "";
                if (idTipo.Value == "1")
                {
                    mensaje = "Informativo: Se procedió a ejecutar el servicio";
                }

                lblMensajeTitulo.Text = "MENSAJE INFORMATIVO";
                lblMensaje.Text = mensaje;
                lblMensaje.ForeColor = System.Drawing.Color.Blue;
                txtComent.Text = "";


                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                upModalMensaje.Update();
                ActualizarParent();
            }
            else
            {


                lblModalValTitle.Text = "ERROR";
                lblVal.Text = "Ocurrio un error al grabar. Favor comunicarse con el administrador del sistema.";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();


            }

        
        }
    }
}