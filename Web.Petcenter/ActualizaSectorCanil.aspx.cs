using Negocio.Petcenter;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
    public partial class ActualizaSectorCanil : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Text.StringBuilder msgError = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {

                    CargarDetalleCanil();
                    CargarDetalleSector();
                    CargarCombos();

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

        void CargarDetalleCanil()
        {
            DataTable Data = AtencionPeluqueriaBuss.BuscarCanil(0, txtfechaIni.Text, txtFechaFinal.Text, cboRecurso.SelectedValue, cboEstado.SelectedValue);
            grvresultado.DataSource = Data;
            grvresultado.DataBind();

        }

        void CargarDetalleSector()
        {
            DataTable Data = AtencionPeluqueriaBuss.BuscarSector(0, txtfechaIni.Text, txtFechaFinal.Text, cboRecurso.SelectedValue, cboEstado.SelectedValue);
            grvresultado2.DataSource = Data;
            grvresultado2.DataBind();

        }
        private void CargarCombos()
        {
            Utilidades.CargaCombo(ref cboRecurso, AtencionPeluqueriaBuss.GetParametrosGEN("Recurso"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetParametrosGEN("Estado"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);

            Utilidades.CargaCombo(ref cboEstadoCanil, AtencionPeluqueriaBuss.GetParametrosGEN("Estado"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
            Utilidades.CargaCombo(ref cboTamanioCanil, AtencionPeluqueriaBuss.GetParametrosGEN("TamanioCanil"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
            Utilidades.CargaCombo(ref cboEspecieCanil, AtencionPeluqueriaBuss.GetParametrosGEN("EspecieCanil"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);

            Utilidades.CargaCombo(ref cboEstadoSector, AtencionPeluqueriaBuss.GetParametrosGEN("Estado"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
            Utilidades.CargaCombo(ref cboServicioSector, AtencionPeluqueriaBuss.GetParametrosGEN("ServicioSector"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {

                if (cboRecurso.SelectedValue == "0")
            {
                divCanil.Visible = true;
                divSector.Visible = true;
            }
            if (cboRecurso.SelectedValue == "1")
            {
                divCanil.Visible = true;
                divSector.Visible = false;
            }
            if (cboRecurso.SelectedValue == "2")
            {
                divSector.Visible = true;
                divCanil.Visible = false;
            }
            CargarDetalleCanil();
            CargarDetalleSector();

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
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            
                
                       

            
        } 
        void CargarDataDetalleCanil(Int32 idCanil, Int32 tipo)
        {
            DataSet Ds = AtencionPeluqueriaBuss.BuscarCanilDetalle(idCanil);

            txtCodigoCanil.Text = "";
            txtNombreCanil.Text = "";
            cboTamanioCanil.ClearSelection();
            cboEspecieCanil.ClearSelection();
            cboEstadoCanil.ClearSelection();
            txtObservacionesCanil.Text = "";

            if (Ds.Tables[0].Rows.Count > 0)
            {
                txtCodigoCanil.Text = Ds.Tables[0].Rows[0]["CodigoCanil"].ToString();
                txtNombreCanil.Text = Ds.Tables[0].Rows[0]["NombreCanil"].ToString();
                cboTamanioCanil.SelectedValue = Ds.Tables[0].Rows[0]["TamanioCanil"].ToString();
                cboEspecieCanil.SelectedValue = Ds.Tables[0].Rows[0]["EspecieCanil"].ToString();
                cboEstadoCanil.SelectedValue = Ds.Tables[0].Rows[0]["EstadoCanil"].ToString();
                txtObservacionesCanil.Text = Ds.Tables[0].Rows[0]["ObservacionesCanil"].ToString();
            }

            if (tipo ==0)
            {
                divCodigoCanil.Visible = false;
                cboEspecieCanil.Attributes.Remove("disabled");
                cboEstadoCanil.Attributes.Remove("disabled");
                cboTamanioCanil.Attributes.Remove("disabled");
                txtObservacionesCanil.Attributes.Remove("disabled");
                btnGuardarCanil.Visible = true ;
            }
            else
            {

                divCodigoCanil.Visible = true;
                if (tipo == 3)
                {
                    cboEspecieCanil.Attributes.Add("disabled", "disabled");
                    cboEstadoCanil.Attributes.Add("disabled", "disabled");
                    cboTamanioCanil.Attributes.Add("disabled", "disabled");
                    txtObservacionesCanil.Attributes.Add("disabled", "disabled");
                    btnGuardarCanil.Visible = false;
                }
                else
                {
                    cboEspecieCanil.Attributes.Remove("disabled");
                    cboEstadoCanil.Attributes.Remove("disabled");
                    cboTamanioCanil.Attributes.Remove("disabled");
                    txtObservacionesCanil.Attributes.Remove("disabled");
                    btnGuardarCanil.Visible = true;
                }

            }

        }
        void CargarDataDetalleSector(Int32 idSector, Int32 tipo)
        {
            DataSet Ds = AtencionPeluqueriaBuss.BuscarSectorDetalle(idSector);

            txtCodigoSector.Text = "";
            txtNombreSector.Text = "";
            cboServicioSector.ClearSelection();
            cboEstadoSector.ClearSelection();
            txtObservacionesSector.Text = "";

            if (Ds.Tables[0].Rows.Count > 0)
            {
                txtCodigoSector.Text = Ds.Tables[0].Rows[0]["CodigoSector"].ToString();
                txtNombreSector.Text = Ds.Tables[0].Rows[0]["NombreSector"].ToString();
                cboServicioSector.SelectedValue = Ds.Tables[0].Rows[0]["ServicioSector"].ToString();
                cboEstadoSector.SelectedValue = Ds.Tables[0].Rows[0]["EstadoSector"].ToString();
                txtObservacionesSector.Text = Ds.Tables[0].Rows[0]["ObservacionesSector"].ToString();
            }

            if (tipo == 0)
            {
                divCodigoSector.Visible = false;
                cboEstadoSector.Attributes.Remove("disabled");
                cboServicioSector.Attributes.Remove("disabled");
                txtObservacionesSector.Attributes.Remove("disabled");
                btnGuardarSector.Visible = true;
            }
            else
            {
                divCodigoSector.Visible = true;
                if (tipo == 3)
                {
                    cboEstadoSector.Attributes.Add("disabled", "disabled");
                    cboServicioSector.Attributes.Add("disabled", "disabled");
                    txtObservacionesSector.Attributes.Add("disabled", "disabled");
                    btnGuardarSector.Visible = false;
                }
                else
                {
                    cboEstadoSector.Attributes.Remove("disabled");
                    cboServicioSector.Attributes.Remove("disabled");
                    txtObservacionesSector.Attributes.Remove("disabled");
                    btnGuardarSector.Visible = true;
                }


            }

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {

                idCanil.Value = "0";
                CargarDataDetalleCanil(Int32.Parse(idCanil.Value), 0);
                lblModalPTitle.Text = "Nuevo Canil";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();

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
        protected void grvresultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Editar")
                {
                    idCanil.Value = e.CommandArgument.ToString();
                    CargarDataDetalleCanil(Int32.Parse(idCanil.Value), 2);

                    lblModalPTitle.Text = "Modificar Canil";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                    upModalP.Update();
                    //EDITAR
                }
                if (e.CommandName == "Eliminar")
                {

                    id.Value = e.CommandArgument.ToString();
                    lblConfirmacionTitulo.Text = "Confirmación";
                    idTipo.Value = "C";
                    lblConfirmacion.Text = "Confirmación:¿Desea continuar con la anulación del canil?";
                    lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                    upModalConfirmacion.Update();
                }

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

        protected void grvresultado2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {

                if (e.CommandName == "Editar")
                {
                    idSector.Value = e.CommandArgument.ToString();
                    CargarDataDetalleSector(Int32.Parse(idSector.Value), 2);

                    lblModalSTitle.Text = "Modificar Sector";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalS", "$('#myModalS').modal();", true);
                    upModalP.Update();
                    //EDITAR
                }
                if (e.CommandName == "Eliminar")
                {

                    id.Value = e.CommandArgument.ToString();
                    lblConfirmacionTitulo.Text = "Confirmación";
                    idTipo.Value = "S";
                    lblConfirmacion.Text = "Confirmación:¿Desea continuar con la anulación del canil?";
                    lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                    upModalConfirmacion.Update();
                }

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

        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grvresultado.PageIndex = e.NewPageIndex;
                CargarDetalleCanil();

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

        protected void gvResultado2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grvresultado2.PageIndex = e.NewPageIndex;
                CargarDetalleSector();

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
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);

            try
            {

                if ((new ProgramacionCita()).GrabarEliminarCanilSector(Int32.Parse(id.Value), idTipo.Value))
                {
                    lblMensajeTitulo.Text = "Informativo";
                    if (idTipo.Value == "S")
                    {
                        lblMensaje.Text = "Información: Se realizó la anulación del Sector.";
                    }
                    else
                    {
                        lblMensaje.Text = "Información: Se realizó la anulación del Canil.";
                    }
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalS", "$('#myModalS').modal('hide');", true);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                    upModalMensaje.Update();
                }
                else
                {


                    lblModalValTitle.Text = "Error";
                    lblVal.Text = "Error: Valide la información con el administrador del sistema.";
                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();


                }

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

        protected void btnGuardarCanil_Click(object sender, EventArgs e)
        {

            Boolean VAL = true;
            String MENSAJE = " ";

            try
            {

                if (cboTamanioCanil.SelectedValue == "0")
                {
                    MENSAJE = MENSAJE + " Tamaño del canil";
                    VAL = false;
                }
                else if (cboEspecieCanil.SelectedValue == "0")
                {
                    MENSAJE = MENSAJE + " Especie";
                    VAL = false;
                }
                else if (cboEstadoCanil.SelectedValue == "0")
                {
                    MENSAJE = MENSAJE + " Estado";
                    VAL = false;
                }
                else
                {
                    MENSAJE = "";
                    VAL = true;

                }

                if (VAL)
                {
                    if ((new ProgramacionCita()).GrabarCanil(Int32.Parse(idCanil.Value), cboTamanioCanil.SelectedValue, cboEspecieCanil.SelectedValue, cboEstadoCanil.SelectedValue, txtObservacionesCanil.Text))
                    {

                        lblMensajeTitulo.Text = "Informativo";
                        lblMensaje.Text = "Informativo: Se procedió a registrar el canil";
                        lblMensaje.ForeColor = System.Drawing.Color.Blue;

                        idCanil.Value = "0";
                        cboTamanioCanil.ClearSelection();
                        cboEspecieCanil.ClearSelection();
                        cboEstadoCanil.ClearSelection();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                        upModalMensaje.Update();

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
                    lblVal.Text = "Ocurrio un error en el sistema: Debe ingresar " + MENSAJE;
                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();
                }

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


        protected void btnGuardarSector_Click(object sender, EventArgs e)
        {

            Boolean VAL = true;
            String MENSAJE = " ";


            try
            {

                if (cboServicioSector.SelectedValue == "0")
                {
                    MENSAJE = MENSAJE + " Servicio";
                    VAL = false;
                }
                else if (cboEstadoSector.SelectedValue == "0")
                {
                    MENSAJE = MENSAJE + " Estado";
                    VAL = false;
                }
                else
                {
                    MENSAJE = "";
                    VAL = true;

                }

                if (VAL)
                {
                    if ((new ProgramacionCita()).GrabarSector(Int32.Parse(idSector.Value), cboServicioSector.SelectedValue, cboEstadoSector.SelectedValue, txtObservacionesSector.Text))
                    {

                        lblMensajeTitulo.Text = "Informativo";
                        lblMensaje.Text = "Informativo: Se procedió a registrar el sector";
                        lblMensaje.ForeColor = System.Drawing.Color.Blue;

                        idSector.Value = "0";
                        cboServicioSector.ClearSelection();
                        cboEstadoSector.ClearSelection();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                        upModalMensaje.Update();

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
                    lblVal.Text = "Ocurrio un error en el sistema: Debe ingresar " + MENSAJE;
                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();
                }

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
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalS", "$('#myModalS').modal('hide');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);
                CargarDetalleCanil();
                CargarDetalleSector();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM1", "UpdateDatos();", true);

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
        protected void grvresultado2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvresultado2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Ver Detalle";

            }
        }
        protected void grvresultado2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow fila in grvresultado2.Rows)
                {

                    if (fila.RowIndex == grvresultado2.SelectedIndex)
                    {
                        fila.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                        fila.ToolTip = string.Empty;
                        idSector.Value = grvresultado2.SelectedDataKey.Values[0].ToString();
                        CargarDataDetalleSector(Int32.Parse(idSector.Value), 3);
                        lblModalSTitle.Text = "Detalle de Sector";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalS", "$('#myModalS').modal();", true);
                        upModalS.Update();
                    }
                    else
                    {
                        fila.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        fila.ToolTip = "Ver Detalle";
                    }
                }

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

        protected void grvresultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvresultado, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Ver Detalle";

            }
        }
        protected void grvresultado_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow fila in grvresultado.Rows)
                {

                    if (fila.RowIndex == grvresultado.SelectedIndex)
                    {
                        fila.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                        fila.ToolTip = string.Empty;
                        idCanil.Value = grvresultado.SelectedDataKey.Values[0].ToString();
                        CargarDataDetalleCanil(Int32.Parse(idCanil.Value), 3);
                        lblModalPTitle.Text = "Detalle de Canil";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                        upModalP.Update();
                    }
                    else
                    {
                        fila.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        fila.ToolTip = "Ver Detalle";
                    }
                }

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
}