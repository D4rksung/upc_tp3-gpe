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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Text.StringBuilder msgError = new System.Text.StringBuilder();

        Int32 MarcaGrid = 0;
        public static DataTable dtComents = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    lblmsg.Text = string.Empty;
                    CargarDetalle();

                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                    msgError.Clear();
                    msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                    msgError.AppendLine("Descripción:" + ex.Message);
                    msgError.AppendLine("Detalle:" + ex.StackTrace);
                    log.Error(msgError.ToString());
                }
                
            }
        }

        void CargarDetalle()
        {

            DataTable Data = AtencionPeluqueriaBuss.BuscarServicioHoy(0, txtfechaIni.Text, txtFechaFinal.Text);
            grvresultado.DataSource = Data;
            grvresultado.DataBind();

        }

        void CargarDataDetalle(Int32 idHojaServicio, Int32 tipo)
        {

            idTipo.Value = tipo.ToString();
            DataSet Data = AtencionPeluqueriaBuss.BuscarServicioDetalle(idHojaServicio);

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
            if (Data.Tables[0].Rows.Count > 0)
            {
                imgMascota.ImageUrl = Data.Tables[0].Rows[0]["Foto"].ToString();

                txtNombreMascota.Text = Data.Tables[0].Rows[0]["nombreMascota"].ToString();
                txtEspecieMascota.Text = Data.Tables[0].Rows[0]["especieMascota"].ToString();
                txtRazaMascota.Text = Data.Tables[0].Rows[0]["razaMascota"].ToString();
                txtAlertas.Text = Data.Tables[0].Rows[0]["observaciones"].ToString();
                txtEstado.Text = Data.Tables[0].Rows[0]["estado"].ToString();
                txtServicio.Text = Data.Tables[0].Rows[0]["Servicio"].ToString();
                lblModalPTitle2.Text = txtServicio.Text;
                gvComents.DataSource = Data.Tables[2];
                gvComents.DataBind();
                dtComents = Data.Tables[2];

                gvMateriales.DataSource = Data.Tables[1];
                gvMateriales.DataBind();

                gvTracking.DataSource = Data.Tables[3];
                gvTracking.DataBind();
            }  //detalle           

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            try
            {

                CargarDetalle();

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
            }
        }

        protected void grvresultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvresultado, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = "Ver Detalle";

                    Int32 HoraCita = Int32.Parse(grvresultado.DataKeys[e.Row.RowIndex].Values[1].ToString().Split(':')[0]);
                    String FechaCita = grvresultado.DataKeys[e.Row.RowIndex].Values[2].ToString();
                    DateTime Dt = new DateTime(Int32.Parse(FechaCita.Substring(6, 4)), Int32.Parse(FechaCita.Substring(3, 2)), Int32.Parse(FechaCita.Substring(0, 2)));
                    DateTime DtActual = DateTime.Now;

                    Int32 horaActual = DateTime.Now.Hour;
                    if (horaActual < HoraCita && MarcaGrid < 2 && Dt.ToShortDateString() == DtActual.ToShortDateString())
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#E8E5F5");
                        MarcaGrid++;
                    }


                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
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

                try
                {

                    idHojaServicio.Value = e.CommandArgument.ToString();
                    CargarDataDetalle(Int32.Parse(idHojaServicio.Value), 1);

                    lblModalPTitle.Text = "Hoja de servicio peluquería";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                    upModalP.Update();
                    //EDITAR

                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                    msgError.Clear();
                    msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                    msgError.AppendLine("Descripción:" + ex.Message);
                    msgError.AppendLine("Detalle:" + ex.StackTrace);
                    log.Error(msgError.ToString());
                }

            }
            if (e.CommandName == "Finalizar")
            {

                try
                {

                    idHojaServicio.Value = e.CommandArgument.ToString();

                    CargarDataDetalle(Int32.Parse(idHojaServicio.Value), 2);
                    lblModalPTitle.Text = "Hoja de servicio peluquería";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                    upModalP.Update();

                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                    msgError.Clear();
                    msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                    msgError.AppendLine("Descripción:" + ex.Message);
                    msgError.AppendLine("Detalle:" + ex.StackTrace);
                    log.Error(msgError.ToString());
                }

                
            }
        }

        protected void btnGuardarP_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("MaterialID");
            Dt.Columns.Add("Cantidad", typeof(Int32));

            try
            {

                foreach (GridViewRow gvRow in gvMateriales.Rows)
                {
                    DataRow Dr = Dt.NewRow();
                    Int32 rowIndex = gvRow.RowIndex;
                    Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                    Int32 idTipo = (Int32)gvMateriales.DataKeys[rowIndex]["idUnidadMedida"];
                    TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                    CheckBox chkCantidad = (CheckBox)gvRow.Cells[0].FindControl("chkCantidad");
                    Dr[0] = idMaterial;
                    Dr[1] = (idTipo == 1 ? (chkCantidad.Checked ? "1" : "0") : txtCantidad.Text);
                    Dt.Rows.Add(Dr);

                }
                if (Dt.Select("Cantidad>0").Count() == 0)
                {
                    lblModalValTitle.Text = "Error";
                    lblVal.Text = "Ocurrio un error en el sistema: Debe de ingresar al menos la cantidad de un material que se utilizó para el servicio";
                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();
                }
                else
                {
                    if (gvComents.Rows.Count > 0 || txtComent.Text != "")
                    {
                        if ((new ProgramacionCita()).GrabarHojadeServicio(Int32.Parse(idHojaServicio.Value), Dt, txtComent.Text))
                        {

                            lblMensajeTitulo.Text = "Informativo";
                            lblMensaje.Text = "Informativo: Se procedió a finalizar el servicio.";
                            lblMensaje.ForeColor = System.Drawing.Color.Blue;
                            txtComent.Text = "";

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                            upModalMensaje.Update();
                            ActualizarParent();

                        }
                        else
                        {


                            lblModalValTitle.Text = "Error";
                            lblVal.Text = "Ocurió un error en el sistema. Error de Base de datos.";
                            lblVal.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                            upModalVal.Update();

                        }

                    }
                    else
                    {

                        lblModalValTitle.Text = "Error";
                        lblVal.Text = "Ocurrio un error en el sistema: Debe de ingresar comentario sobre lo realizado para finalizar el servicio";

                        lblVal.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                        upModalVal.Update();
                    }
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
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
            try
            {

                gvComents.DataSource = ((new ProgramacionCita()).GrabarHojadeServicioComents(Int32.Parse(idHojaServicio.Value), txtComent.Text));
                gvComents.DataBind();
                txtComent.Text = "";
                upModalP.Update();

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
            }
            
        }
        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {

                grvresultado.PageIndex = e.NewPageIndex;
                CargarDetalle();

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
            }
            
        }
        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("MaterialID");
            Dt.Columns.Add("Cantidad", typeof(Int32));

            try
            {


                foreach (GridViewRow gvRow in gvMateriales.Rows)
                {
                    DataRow Dr = Dt.NewRow();
                    Int32 rowIndex = gvRow.RowIndex;
                    Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                    Int32 idTipo = (Int32)gvMateriales.DataKeys[rowIndex]["idUnidadMedida"];
                    TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                    CheckBox chkCantidad = (CheckBox)gvRow.Cells[0].FindControl("chkCantidad");
                    Dr[0] = idMaterial;
                    Dr[1] = (idTipo == 1 ? (chkCantidad.Checked ? "1" : "0") : txtCantidad.Text);
                    Dt.Rows.Add(Dr);

                }

                if ((new ProgramacionCita()).GrabarHojadeServicio(Int32.Parse(idHojaServicio.Value), Dt, txtComent.Text))
                {
                    String mensaje = "";
                    if (idTipo.Value == "1")
                    {
                        mensaje = "Informativo: Se procedió a ejecutar el servicio";
                    }

                    lblMensajeTitulo.Text = "Informativo";
                    lblMensaje.Text = mensaje;
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;
                    txtComent.Text = "";


                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                    upModalMensaje.Update();
                    ActualizarParent();
                }
                else
                {


                    lblModalValTitle.Text = "Error";
                    lblVal.Text = "Ocurió un error en el sistema. Error de Base de datos.";
                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();


                }


            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
            }
        }


    }
}