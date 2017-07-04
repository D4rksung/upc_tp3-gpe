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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CargarDetalleCanil();
                CargarDetalleSector();
                CargarCombos();
            }
        }

        void CargarDetalleCanil()
        {
            DataTable data = AtencionPeluqueriaBuss.BuscarCanil(0, txtfechaIni.Text, txtFechaFinal.Text, cboRecurso.SelectedValue, cboEstado.SelectedValue);
            grvresultado.DataSource = data;
            grvresultado.DataBind();

        }

        void CargarDetalleSector()
        {
            DataTable data = AtencionPeluqueriaBuss.BuscarSector(0, txtfechaIni.Text, txtFechaFinal.Text, cboRecurso.SelectedValue, cboEstado.SelectedValue);
            grvresultado2.DataSource = data;
            grvresultado2.DataBind();

        }
        private void CargarCombos()
        {
            Utilidades.CargaCombo(ref cboRecurso, AtencionPeluqueriaBuss.GetParametrosGEN("Recurso"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetParametrosGEN("Estado"), "ID", "DESCR", true);

            Utilidades.CargaCombo(ref cboEstadoCanil, AtencionPeluqueriaBuss.GetParametrosGEN("Estado"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref cboTamanioCanil, AtencionPeluqueriaBuss.GetParametrosGEN("TamanioCanil"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref cboEspecieCanil, AtencionPeluqueriaBuss.GetParametrosGEN("EspecieCanil"), "ID", "DESCR", true);

            Utilidades.CargaCombo(ref cboEstadoSector, AtencionPeluqueriaBuss.GetParametrosGEN("Estado"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref cboServicioSector, AtencionPeluqueriaBuss.GetParametrosGEN("ServicioSector"), "ID", "DESCR", true);

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
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
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            
                
                       

            
        } 

            void CargarDataDetalleCanil(Int32 idCanil, Int32 tipo)
        {
            DataSet ds = AtencionPeluqueriaBuss.BuscarCanilDetalle(idCanil);

            txtCodigoCanil.Text = "";
            txtNombreCanil.Text = "";
            cboTamanioCanil.ClearSelection();
            cboEspecieCanil.ClearSelection();
            cboEstadoCanil.ClearSelection();
            txtObservacionesCanil.Text = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCodigoCanil.Text = ds.Tables[0].Rows[0]["CodigoCanil"].ToString();
                txtNombreCanil.Text = ds.Tables[0].Rows[0]["NombreCanil"].ToString();
                cboTamanioCanil.SelectedValue = ds.Tables[0].Rows[0]["TamanioCanil"].ToString();
                cboEspecieCanil.SelectedValue = ds.Tables[0].Rows[0]["EspecieCanil"].ToString();
                cboEstadoCanil.SelectedValue = ds.Tables[0].Rows[0]["EstadoCanil"].ToString();
                txtObservacionesCanil.Text = ds.Tables[0].Rows[0]["ObservacionesCanil"].ToString();
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
            DataSet ds = AtencionPeluqueriaBuss.BuscarSectorDetalle(idSector);

            txtCodigoSector.Text = "";
            txtNombreSector.Text = "";
            cboServicioSector.ClearSelection();
            cboEstadoSector.ClearSelection();
            txtObservacionesSector.Text = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCodigoSector.Text = ds.Tables[0].Rows[0]["CodigoSector"].ToString();
                txtNombreSector.Text = ds.Tables[0].Rows[0]["NombreSector"].ToString();
                cboServicioSector.SelectedValue = ds.Tables[0].Rows[0]["ServicioSector"].ToString();
                cboEstadoSector.SelectedValue = ds.Tables[0].Rows[0]["EstadoSector"].ToString();
                txtObservacionesSector.Text = ds.Tables[0].Rows[0]["ObservacionesSector"].ToString();
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
            
                idCanil.Value = "0";
                CargarDataDetalleCanil(Int32.Parse(idCanil.Value), 0);
                lblModalPTitle.Text = "Nuevo Canil";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
          
        }
        protected void grvresultado_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void grvresultado2_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado.PageIndex = e.NewPageIndex;
            CargarDetalleCanil();
        }

        protected void gvResultado2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado2.PageIndex = e.NewPageIndex;
            CargarDetalleSector();
        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);


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

        protected void btnGuardarCanil_Click(object sender, EventArgs e)
        {

            Boolean VAL = true;
            String MENSAJE = " ";



            if (cboTamanioCanil.SelectedValue=="0")
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


        protected void btnGuardarSector_Click(object sender, EventArgs e)
        {

            Boolean VAL = true;
            String MENSAJE = " ";



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
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalS", "$('#myModalS').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);
            CargarDetalleCanil();
            CargarDetalleSector();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM1", "UpdateDatos();", true);

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
            foreach (GridViewRow row in grvresultado2.Rows)
            {

                if (row.RowIndex == grvresultado2.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                    row.ToolTip = string.Empty;
                    idSector.Value = grvresultado2.SelectedDataKey.Values[0].ToString();
                    CargarDataDetalleSector(Int32.Parse(idSector.Value), 3);
                    lblModalSTitle.Text = "Detalle de Sector";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalS", "$('#myModalS').modal();", true);
                    upModalS.Update();
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Ver Detalle";
                }
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
            foreach (GridViewRow row in grvresultado.Rows)
            {

                if (row.RowIndex == grvresultado.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                    row.ToolTip = string.Empty;
                    idCanil.Value = grvresultado.SelectedDataKey.Values[0].ToString();
                    CargarDataDetalleCanil(Int32.Parse(idCanil.Value), 3);
                    lblModalPTitle.Text = "Detalle de Canil";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                    upModalP.Update();
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Ver Detalle";
                }
            }
        }

    }
}