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
    public partial class ActualizaKardex : System.Web.UI.Page
    {
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
            DataTable data = AtencionPeluqueriaBuss.BuscarMovimientos(Int32.Parse(cboAlmacen.SelectedValue), txtfechaIni.Text, txtFechaFinal.Text);
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
            Utilidades.CargaCombo(ref cboAlmacen, AtencionPeluqueriaBuss.GetAlmacen(), "idAlmacen", "descripcion", true);
            Utilidades.CargaCombo(ref cboAlmacenV, AtencionPeluqueriaBuss.GetAlmacen(), "idAlmacen", "descripcion", true);
            Utilidades.CargaCombo(ref cboTipoMov, AtencionPeluqueriaBuss.GetcboTipoMov(), "idcboTipoMov", "descripcion", true);
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
            gvMateriales.DataSource = data2;
            gvMateriales.DataBind();


            txtGuia.Text = "";
            txtFechaMov.Text = "";
            cboTipoMov.ClearSelection();
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtFechaMov.Text = ds.Tables[1].Rows[0]["FECHAMOV"].ToString();
                txtGuia.Text = ds.Tables[1].Rows[0]["NROGUIA"].ToString();
                cboTipoMov.SelectedValue = ds.Tables[1].Rows[0]["TipoMovimiento"].ToString();
                idAlmacen.Value = ds.Tables[1].Rows[0]["IdAlmacen"].ToString();
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
            if (e.CommandName == "Anular")
            {

                idMovimiento.Value = e.CommandArgument.ToString();

                lblConfirmacionTitulo.Text = "Confirmación";
                lblConfirmacion.Text = "Confirmación:¿Desea continuar con la anulación del registro?";
                lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                upModalConfirmacion.Update();
            }
        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);
           

            if ((new ProgramacionCita()).GrabarMovimientoAnular(Int32.Parse(idMovimiento.Value)))
            {
                lblMensajeTitulo.Text = "Informativo";
                lblMensaje.Text = "Información: Se realizó la anulación del registro con éxito.";
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
                CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 0);
                lblModalPTitle.Text = "Registro de Movimiento";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
            }
            else
            {
                lblModalValTitle.Text = "Error";
                lblVal.Text = "Ocurrio un error en el sistema: Debe seleccionar el almacén";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }
        }
        protected void btnGuardarP_Click(object sender, EventArgs e)
        {

            Boolean VAL = true;
            String MENSAJE = " ";
            if (txtFechaMov.Text == "")
            {
                MENSAJE = MENSAJE + " la Fecha del movimiento";
                VAL = false;
            }
            else if (cboTipoMov.SelectedValue == "001")
            {
                if (txtGuia.Text == "")
                {
                    MENSAJE = MENSAJE +(MENSAJE==""?" y":"") +  " el Número de guía de remisión.";
                    VAL = false;
                }
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

            if (VAL)
            {
                foreach (GridViewRow gvRow in gvMateriales.Rows)
                {
                    DataRow dr = dt.NewRow();
                    Int32 rowIndex = gvRow.RowIndex;
                    Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                    TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                    TextBox txtPrecioCompra = (TextBox)gvRow.Cells[0].FindControl("txtprecioCompra");
                    dr[0] = idMaterial;
                    dr[1] = txtPrecioCompra.Text;
                    dr[2] = txtCantidad.Text;
                    dt.Rows.Add(dr);

                }
                if ((new ProgramacionCita()).GrabarMovimiento(Int32.Parse(idMovimiento.Value), dt, txtFechaMov.Text, txtGuia.Text, cboTipoMov.SelectedValue, Int32.Parse(idAlmacen.Value )))
                {

                    lblMensajeTitulo.Text = "Informativo";
                    lblMensaje.Text = "Informativo: Se procedió a registrar el movimiento.";
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;

                    txtGuia.Text = "";
                    txtFechaMov.Text = "";
                    cboTipoMov.ClearSelection();

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
    }
    }
