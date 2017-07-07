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
    public partial class ActualizaKardex : System.Web.UI.Page
    {
        public static DataTable DtMateriales;
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
            DataTable Data = AtencionPeluqueriaBuss.BuscarMovimientos(Int32.Parse(cboAlmacen.SelectedValue), txtfechaIni.Text, txtFechaFinal.Text, "",cboTipo.SelectedValue,cboEstado.SelectedValue, txtNumReq.Text);
            grvresultado.DataSource = Data;
            grvresultado.DataBind();
            
        }
        void CargarDetalle2()
        {

            DataTable Data2 = AtencionPeluqueriaBuss.BuscarMateriales(Int32.Parse(cboAlmacenV.SelectedValue), txtFechaMovHasta.Text,"");
            grvresultado2.DataSource = Data2;
            grvresultado2.DataBind();
        }
        private void CargarCombo()
        {
            Utilidades.CargaCombo(ref cboAlmacenV, AtencionPeluqueriaBuss.GetAlmacen(), Utilitario.Comun.Dominios.IdAlmacen, Utilitario.Comun.Dominios.DescripcionAlmacen, true);


            Utilidades.CargaCombo(ref cboAlmacen, AtencionPeluqueriaBuss.GetAlmacen(), Utilitario.Comun.Dominios.IdAlmacen, Utilitario.Comun.Dominios.DescripcionAlmacen, true);
            Utilidades.CargaCombo(ref cboTipo, AtencionPeluqueriaBuss.GetParametros("013"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetParametros("011"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
            Utilidades.CargaCombo(ref cboTipoReq, AtencionPeluqueriaBuss.GetParametros("013"), Utilitario.Comun.Dominios.ID, Utilitario.Comun.Dominios.Descripcion, true);
             
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
        protected void grvresultado_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvresultado.Rows)
            {

                if (row.RowIndex == grvresultado.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                    row.ToolTip = string.Empty;
                    idMovimiento.Value = grvresultado.SelectedDataKey.Values[0].ToString();
                    CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 3, 0);

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
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalR", "$('#myModalR').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);
            CargarDetalle();
            CargarDetalle2();
            UpdatePanel1.Update();
            UpdatePanel2.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM1", "UpdateDatos();", true);

        }
        void CargarDataDetalle(Int32 idMaterial, Int32 tipo)
        {

            DataTable Data2 = AtencionPeluqueriaBuss.BuscarMaterialesMovimiento(idMaterial);
            gvMaterialesV.DataSource = Data2;
            gvMaterialesV.DataBind();
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("IdDetReqMaterial");
            Dt.Columns.Add("Precio", typeof(Decimal));
            Dt.Columns.Add("Cantidad", typeof(Decimal));

            foreach (GridViewRow gvRow in grvresultado3.Rows)
            {
                DataRow Dr = Dt.NewRow();
                Int32 rowIndex = gvRow.RowIndex;
                Int32 idMaterial = (Int32)grvresultado3.DataKeys[rowIndex]["idMovimiento"];
                TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                if (Decimal.Parse(txtCantidad.Text) > 0)
                {
                    Dr[0] = idMaterial;
                    Dr[1] = 0;
                    Dr[2] = txtCantidad.Text;
                    Dt.Rows.Add(Dr);
                }
            }

            if (Dt.Rows.Count > 0)
            {
                if ((new ProgramacionCita()).GrabarMovimientoAtencion(Dt))
                {
                    lblMensajeTitulo.Text = "Informativo";
                    lblMensaje.Text = "Informativo: Se procedió a registrar las cantidades recibidas.";
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;


                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                    upModalMensaje.Update();
                }
            }
            else
            {

                lblModalValTitle.Text = "Error";
                lblVal.Text = "Error: Ingrese la cantidad recibida de por lo menos 1 material.";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }
        }


        void CargarDataDetalle3(Int32 idMovimiento)
        {

            DataTable Data2 = AtencionPeluqueriaBuss.BuscarMovimientosAtencion(idMovimiento);
            grvresultado3.DataSource = Data2;
            grvresultado3.DataBind();
        }
        void CargarDataDetalle2(Int32 idMovimiento, Int32 tipo, Int32 almacenID)
        {
            DataSet Ds = AtencionPeluqueriaBuss.BuscarMaterialesDispositivo(idMovimiento, almacenID);
            DataTable Data2 = Ds.Tables[0];
            gvMateriales.DataSource = Data2;
            gvMateriales.DataBind();
            DtMateriales = Data2;

            txtNroReq.Text = "";
            txtFechaReq.Text = "";
            cboTipoReq.ClearSelection();
            if (Ds.Tables[1].Rows.Count > 0)
            {
                txtNroReq.Text = Ds.Tables[1].Rows[0]["NroReq"].ToString();
                txtFechaReq.Text = Ds.Tables[1].Rows[0]["FECHAMOV"].ToString();
                cboTipoReq.SelectedValue = Ds.Tables[1].Rows[0]["TipoMovimiento"].ToString();
                txtSede.Text = Ds.Tables[1].Rows[0]["Sede"].ToString();
                idAlmacen.Value = Ds.Tables[1].Rows[0]["IdAlmacen"].ToString();
            }

            if (tipo == 3)
            {
                txtFechaReq.ReadOnly = true;
                txtFechaReq.Attributes.Add("disabled", "disabled");
                cboTipoReq.Attributes.Add("disabled", "disabled");
                divBuscar.Visible = false;
                gvMateriales.Enabled = false;
                btnGuardarP.Visible = false;
            }
            else
            {
                txtFechaReq.ReadOnly = false;
                txtFechaReq.Attributes.Remove("disabled");
                cboTipoReq.Attributes.Remove("disabled");
                divBuscar.Visible = true;
                gvMateriales.Enabled = true;
                btnGuardarP.Visible = true;
                Utilidades.CargaCombo(ref combobox, AtencionPeluqueriaBuss.BuscarMaterialesGen(cboTipoReq.SelectedValue), "IdMaterial", "Descripcion", true);

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
                CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 1,0);

                lblModalPTitle.Text = "Registro de Movimiento";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
                //EDITAR
            }
            if (e.CommandName == "Anular")
            {

                idMovimientoT.Value = e.CommandArgument.ToString();
                idTipo.Value = "A";
                lblConfirmacionTitulo.Text = "Confirmación";
                lblConfirmacion.Text = "Confirmación:¿Desea continuar con la anulación del registro?";
                lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                upModalConfirmacion.Update();
            }
            if (e.CommandName == "Cerrar")
            {

                idMovimientoT.Value = e.CommandArgument.ToString();
                idTipo.Value = "C";

                lblConfirmacionTitulo.Text = "Confirmación";
                lblConfirmacion.Text = "Confirmación:¿Desea cerrar el requerimiento de Material?";
                lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                upModalConfirmacion.Update();
            }
            if (e.CommandName == "Recepcionar")
            {

                idMovimientoR.Value = e.CommandArgument.ToString();
                CargarDataDetalle3(Int32.Parse(idMovimientoR.Value));
                lblModalRTitle.Text = "Recepción de materiales";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalR", "$('#myModalR').modal();", true);
                upModalR.Update();
            }
        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);
           

            if ((new ProgramacionCita()).GrabarMovimientoTipo(Int32.Parse(idMovimientoT.Value), idTipo.Value))
            {
                lblMensajeTitulo.Text = "Informativo";
                if (idTipo.Value == "A")
                {
                    lblMensaje.Text = "Información: Se realizó la anulación del registro con éxito.";
                }
                else
                {
                    lblMensaje.Text = "Información: Se cerro el requerimiento de materiales.";
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
                CargarDataDetalle2(Int32.Parse(idMovimiento.Value), 0, Int32.Parse(idAlmacen.Value));
                lblModalPTitle.Text = "Registro de Requerimiento";
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

            DataTable Dt = new DataTable();
            Dt.Columns.Add("MaterialID");
            Dt.Columns.Add("Precio", typeof(Decimal));
            Dt.Columns.Add("Cantidad", typeof(Decimal));

            foreach (GridViewRow gvRow in gvMateriales.Rows)
            {
                DataRow Dr = Dt.NewRow();
                Int32 rowIndex = gvRow.RowIndex;
                Int32 idMaterial = (Int32)gvMateriales.DataKeys[rowIndex]["IdMaterial"];
                TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                Dr[0] = idMaterial;
                Dr[1] = 0;
                Dr[2] = txtCantidad.Text;
                Dt.Rows.Add(Dr);

            }


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
            else if (gvMateriales.Rows.Count==0 || Dt.Select("Cantidad>0").Count() == 0)
            {
                MENSAJE = MENSAJE + " lista de materiales";
                VAL = false;
            }
            else
            {
                MENSAJE = "";
                VAL = true;

            }
               
            if (VAL )
            {
                if ((new ProgramacionCita()).GrabarMovimiento(Int32.Parse(idMovimiento.Value), Dt, txtFechaReq.Text,  cboTipoReq.SelectedValue, "0", Int32.Parse(idAlmacen.Value )))
                {

                    lblMensajeTitulo.Text = "Informativo";
                    lblMensaje.Text = "Informativo: Se procedió a registrar el requerimiento.";
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;

                    txtNroReq.Text = "";
                    txtFechaReq.Text = "";
                    txtSede.Text = "";
                    cboTipoReq.ClearSelection();

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

                DataRow Dr = DtMateriales.Select("IdMaterial=" + idMaterial.ToString())[0];
                Dr[4] = txtCantidad.Text;


            }

            if (DtMateriales.Select("IdMaterial=" + combobox.SelectedValue).Count() == 0)
            {
                DataTable Ds = AtencionPeluqueriaBuss.BuscarMaterialesxCodigo(Int32.Parse(combobox.SelectedValue), Int32.Parse(idAlmacen.Value));

                DataRow Dr = DtMateriales.NewRow();

                if (Ds.Rows.Count > 0)
                {
                    Dr[0] = Ds.Rows[0]["IdMaterial"].ToString();
                    Dr[1]= Ds.Rows[0]["material"].ToString();
                    Dr[2] = Ds.Rows[0]["descripcion"].ToString();
                    Dr[3] = Ds.Rows[0]["umedida"].ToString();
                    Dr[4] = Ds.Rows[0]["Cantidad"].ToString();
                    Dr[5] = Ds.Rows[0]["Precio"].ToString();
                    DtMateriales.Rows.Add(Dr);
                }


                gvMateriales.DataSource = DtMateriales;
                gvMateriales.DataBind();
            }
            else
            {

                lblModalValTitle.Text = "Error";
                lblVal.Text = "El material ya se encuentra agregado en la lista;";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }
            combobox.SelectedValue = "0";
        }

        protected void cboTipoReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilidades.CargaCombo(ref combobox, AtencionPeluqueriaBuss.BuscarMaterialesGen(cboTipoReq.SelectedValue), "IdMaterial", "Descripcion", true);
            upModalP.Update();
        }
    }
    }
