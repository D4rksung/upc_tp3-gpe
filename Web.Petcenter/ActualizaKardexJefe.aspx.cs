using Negocio.Petcenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class ActualizaKardexJefe : System.Web.UI.Page
    {
        public static DataTable dtMateriales;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombo();
                CargarDetalle();
                CargarDetalle2();
            }
        }
        
        void CargarDetalle()
        {
            DataTable data = AtencionPeluqueriaBuss.BuscarMovimientos(Int32.Parse(cboAlmacen.SelectedValue), txtfechaIni.Text, txtFechaFinal.Text, cboMotivo.SelectedValue,"0",cboEstado.SelectedValue, txtNumReq.Text);
            grvresultado.DataSource = data;
            grvresultado.DataBind();
            
        }
        void CargarDetalle2()
        {

            DataTable data2 = AtencionPeluqueriaBuss.BuscarMateriales(Int32.Parse(cboAlmacenV.SelectedValue), txtFechaMovHasta.Text,"");
            grvresultado2.DataSource = data2;
            grvresultado2.DataBind();
        }
        private void CargarCombo()
        {
            Utilidades.CargaCombo(ref cboAlmacenV, AtencionPeluqueriaBuss.GetAlmacen(), "idAlmacen", "descripcion", true);


            Utilidades.CargaCombo(ref cboAlmacen, AtencionPeluqueriaBuss.GetAlmacen(), "idAlmacen", "descripcion", true);
            Utilidades.CargaCombo(ref cboMotivo, AtencionPeluqueriaBuss.GetParametros("012"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetParametros("011"), "ID", "DESCR", true);
            cboEstado.SelectedValue = "002";
            Utilidades.CargaCombo(ref cboTipoReq, AtencionPeluqueriaBuss.GetParametros("013"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref cboMotivoReq, AtencionPeluqueriaBuss.GetParametros("012"), "ID", "DESCR", true);
            Utilidades.CargaCombo(ref combobox, AtencionPeluqueriaBuss.BuscarMaterialesGen(), "IdMaterial", "Descripcion", true);
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDetalle();
        }


        protected void btnBuscar2_Click(object sender, EventArgs e)
        {
            CargarDetalle2();
        }

        protected void grvresultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvresultado, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Ver Detalle";               

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
            foreach (GridViewRow row in grvresultado2.Rows)
            {

                if (row.RowIndex == grvresultado2.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                    row.ToolTip = string.Empty;
                    //divDetalle.Visible = true;
                    //divDetalle.Style.Add("width", "380px");
                    //upModalConfirmacion.Update();
                    idMaterial.Value = grvresultado2.SelectedDataKey.Values[0].ToString();
                    CargarDataDetalle(Int32.Parse(idMaterial.Value), 0);
                    lblModalPTitleV.Text = "Detalle de Movimiento";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalV", "$('#myModalV').modal();", true);
                    upModalV.Update();
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Ver Detalle";
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
                    idMovimiento.Value = grvresultado.SelectedDataKey.Values[0].ToString();
                    CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 3);

                    lblModalPTitle.Text = "Detalle del requerimiento";
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);
            CargarDetalle();
            CargarDetalle2();
            UpdatePanel1.Update();
            UpdatePanel2.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM1", "UpdateDatos();", true);

        }
        void CargarDataDetalle(Int32 idMaterial, Int32 tipo)
        {

            DataTable data2 = AtencionPeluqueriaBuss.BuscarMaterialesMov(idMaterial);
            gvMaterialesV.DataSource = data2;
            gvMaterialesV.DataBind();
        }
        void CargarDataDetalle2(Int32 idMovimiento, Int32 tipo)
        {
            DataSet ds = AtencionPeluqueriaBuss.BuscarMaterialesDispo(idMovimiento);
            DataTable data2 = ds.Tables[0];

            data2.Columns.Add("SubTotal");
            foreach (DataRow dr in data2.Rows)
            {
                dr[6] = (Decimal.Parse(dr["Precio"].ToString()) * Decimal.Parse(dr["Cantidad"].ToString())   );
            }

                

            gvMateriales.DataSource = data2;
            gvMateriales.DataBind();
            dtMateriales = data2;

            txtNroReq.Text = "";
            txtFechaReq.Text = "";
            cboTipoReq.ClearSelection();
            cboMotivoReq.ClearSelection();
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtNroReq.Text = ds.Tables[1].Rows[0]["NroReq"].ToString();
                txtFechaReq.Text = ds.Tables[1].Rows[0]["FECHAMOV"].ToString();
                cboTipoReq.SelectedValue = ds.Tables[1].Rows[0]["TipoMovimiento"].ToString();
                cboMotivoReq.SelectedValue = ds.Tables[1].Rows[0]["MotivoMovimiento"].ToString();
                txtSede.Text = ds.Tables[1].Rows[0]["Sede"].ToString();
                idAlmacen.Value = ds.Tables[1].Rows[0]["IdAlmacen"].ToString();
            }
            if (tipo == 3)
            {
                txtFechaReq.ReadOnly = true;
                txtFechaReq.Attributes.Add("disabled", "disabled");
                cboTipoReq.Attributes.Add("disabled", "disabled");
                cboMotivoReq.Attributes.Add("disabled", "disabled");
                divBuscar.Visible = false;
                gvMateriales.Enabled = false ;
                btnGuardarP.Visible = false;
            }
            else
            {
                txtFechaReq.ReadOnly = false;
                txtFechaReq.Attributes.Add("disabled", "");
                cboTipoReq.Attributes.Add("disabled", "");
                cboMotivoReq.Attributes.Add("disabled", "");
                divBuscar.Visible = true;
                gvMateriales.Enabled = true;
                btnGuardarP.Visible = true;
            }
        }
        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado.PageIndex = e.NewPageIndex;
            CargarDetalle();
        }
        protected void gvMaterialesV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMaterialesV.PageIndex = e.NewPageIndex;
            CargarDataDetalle(Int32.Parse(idMaterial.Value), 0);
        }
        protected void gvResultado2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado2.PageIndex = e.NewPageIndex;
            CargarDetalle2();
        }
        protected void grvresultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                idMovimiento.Value = e.CommandArgument.ToString();
                CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 1);

                lblModalPTitle.Text = "Registro de Movimiento";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
                //EDITAR
            }
            if (e.CommandName == "Aprobar")
            {

                idMovimientoT.Value = e.CommandArgument.ToString();
                idTipo.Value = "P";
                lblConfirmacionTitulo.Text = "Confirmación";
                lblConfirmacion.Text = "Confirmación:¿Desea aprobar requerimiento de Material?";
                lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                upModalConfirmacion.Update();
            }
            if (e.CommandName == "Rechazar")
            {

                idMovimientoT.Value = e.CommandArgument.ToString();
                idTipo.Value = "R";

                lblConfirmacionTitulo.Text = "Confirmación";
                lblConfirmacion.Text = "Confirmación:¿Desea rechazar requerimiento de Material?";
                lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                upModalConfirmacion.Update();
            }
        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);
           

            if ((new ProgramacionCita()).GrabarMovimientoTipo(Int32.Parse(idMovimientoT.Value), idTipo.Value))
            {
                lblMensajeTitulo.Text = "Informativo";
                if (idTipo.Value == "P")
                {
                    lblMensaje.Text = "Información: Se realizó la aprobación del requerimiento de materiales.";
                }
                else
                {
                    lblMensaje.Text = "Información: Se rechazó el requerimiento de materiales.";
                }
                lblMensaje.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalA", "$('#myModalA').modal('hide');", true);
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
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            if (cboAlmacen.SelectedValue != "0")
            {
                idMovimiento.Value = "0";
                idAlmacen.Value = cboAlmacen.SelectedValue;
                txtSede.Text = cboAlmacen.SelectedItem.Text;
                CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 0);
                lblModalPTitle.Text = "Registro de material";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
            }
            else
            {
                lblModalValTitle.Text = "Error";
                lblVal.Text = "Ocurrio un error en el sistema: Debe seleccionar la sede";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }
        }
        protected void btnGuardarP_Click(object sender, EventArgs e)
        {

            Boolean VAL = true;
            String MENSAJE = " ";
            if (txtFechaReq.Text == "")
            {
                MENSAJE = MENSAJE + " la Fecha del requerimiento";
                VAL = false;
            }
            else if (cboTipoReq.SelectedValue =="0")
            {
                MENSAJE = MENSAJE + " el tipo de requerimiento";
                VAL = false;
            }
            else if (cboMotivoReq.SelectedValue =="0")
            {
                MENSAJE = MENSAJE + " el motivo del requerimiento";
                VAL = false;
            }
            else if (gvMateriales.Rows.Count==0)
            {
                MENSAJE = MENSAJE + " lista de materiales";
                VAL = false;
            }
            else
            {
                MENSAJE = "";
                VAL = true;

            }
                DataTable dt = new DataTable();
            dt.Columns.Add("MaterialID");
            dt.Columns.Add("Precio", typeof(Decimal));
            dt.Columns.Add("Cantidad", typeof(Decimal));

                foreach (GridViewRow gvRow in gvMateriales.Rows)
                {
                    DataRow dr = dt.NewRow();
                    Int32 rowIndex = gvRow.RowIndex;
                    Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                    TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                    dr[0] = idMaterial;
                    dr[1] = 0;
                    dr[2] = txtCantidad.Text;
                    dt.Rows.Add(dr);

                }
            if (VAL)
            {
                if ((new ProgramacionCita()).GrabarMovimiento(Int32.Parse(idMovimiento.Value), dt, txtFechaReq.Text,  cboTipoReq.SelectedValue, cboMotivoReq.SelectedValue, Int32.Parse(idAlmacen.Value )))
                {

                    lblMensajeTitulo.Text = "Informativo";
                    lblMensaje.Text = "Informativo: Se procedió a registrar el requerimiento.";
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;

                    txtNroReq.Text = "";
                    txtFechaReq.Text = "";
                    txtSede.Text = "";
                    cboTipoReq.ClearSelection();
                    cboMotivoReq.ClearSelection();

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
        void ActualizarParent()
        {


            string script = "$(document).ready(function () { $('[id*=btnBuscar]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
            
        }
        void ActualizarParent2()
        {
            

            string script2 = "$(document).ready(function () { $('[id*=btnBuscar2]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load2", script2, true);
        }

        protected void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in gvMateriales.Rows)
            {
                Int32 rowIndex = gvRow.RowIndex;
                Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");

                DataRow dr = dtMateriales.Select("IdMaterial=" + idMaterial.ToString())[0];
                dr[4] = txtCantidad.Text;


            }

            if (dtMateriales.Select("IdMaterial=" + combobox.SelectedValue).Count() == 0)
            {
                DataTable ds = AtencionPeluqueriaBuss.BuscarMaterialesxCodigo(Int32.Parse(combobox.SelectedValue), Int32.Parse(idAlmacen.Value));

                DataRow dr = dtMateriales.NewRow();

                if (ds.Rows.Count > 0)
                {
                    dr[0] = ds.Rows[0]["IdMaterial"].ToString();
                    dr[1]= ds.Rows[0]["material"].ToString();
                    dr[2] = ds.Rows[0]["descripcion"].ToString();
                    dr[3] = ds.Rows[0]["umedida"].ToString();
                    dr[4] = ds.Rows[0]["Cantidad"].ToString();
                    dr[5] = ds.Rows[0]["Precio"].ToString();
                    dr[6] = "0";
                    dtMateriales.Rows.Add(dr);
                }


                gvMateriales.DataSource = dtMateriales;
                gvMateriales.DataBind();
            }
            else
            {

                lblModalValTitle.Text = "Error";
                lblVal.Text = "El material ya fue ingresado;";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }
            combobox.SelectedValue = "0";
        }
    }
    }
