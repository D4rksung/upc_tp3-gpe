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
    public partial class EditarKardexMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["_Seguridad"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Seguridad seg = (Seguridad)Session["_Seguridad"];
                    if (seg.indHabilitado == 0)
                        Response.Redirect("Default.aspx");
                }
                this.CargaCombo();
                this.ConfigurarFechas();
            }
        }

        private void CargaCombo()
        {
            Utilidades.CargaCombo(ref cboTipoMov, AtencionPeluqueriaBuss.ParametroListar("006"), "Parametro", "DscParametro", true);
        }

        private void ConfigurarFechas()
        {
            try
            {
                System.Globalization.CultureInfo objCulture = new System.Globalization.CultureInfo("es-PE");
                txtfecharegistro.Text = DateTime.Today.ToString("dd/MM/yyyy", objCulture);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizarKardexMaterial.aspx");
        }

        protected void btngrabar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtnommaterial.Text == string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Primero debe realizar la busqueda del material.'});", true);
                    return;
                }

                int idmaterial = Utilidades.ToInt(txtcodmaterial.Text);
                DataTable data = AtencionPeluqueriaBuss.GetDatosMaterial(idmaterial);

                decimal cantidad = Utilidades.ToDecimal(txtcantidad.Text);

                if (cantidad == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Ingrese la cantidad.'});", true);
                    return;
                }

                if (data.Rows.Count > 0)
                {

                    this.txtnommaterial.Text = data.Rows[0]["Nombre"].ToString();
                    this.txtDescripciónmat.Text = data.Rows[0]["Descripcion"].ToString();
                    this.txtcategoria.Text = data.Rows[0]["Categoria"].ToString();
                    this.txtmodelo.Text = data.Rows[0]["Modelo"].ToString();
                    this.txtundmedida.Text = data.Rows[0]["UnidadMedida"].ToString();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('El material para el código ingresado no existe.')", true);
                    limpiarform();
                    return;
                }


                KardexMaterial kardex = new KardexMaterial();

                kardex.FechaMovimiento = txtfecharegistro.Text;
                kardex.Cantidad = Utilidades.ToDecimal(txtcantidad.Text);
                kardex.PrecioCompra = Utilidades.ToDecimal(txtpreciocompra.Text);
                kardex.TipoMovimiento = cboTipoMov.SelectedValue;
                kardex.idMaterial = Utilidades.ToInt(txtcodmaterial.Text);
                kardex.NumGuia = txtnumguia.Text.ToUpper();
                AtencionPeluqueriaBuss.GrabarKardexMaterial(kardex, 1);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Movimiento de kardex ingresado correctamente.'});", true);
                this.limpiarform();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }

        protected void btnbuscarmaterial_Click(object sender, EventArgs e)
        {
            try
            {
                int idmaterial = Utilidades.ToInt(txtcodmaterial.Text);
                if (idmaterial > 0)
                {

                    DataTable data = AtencionPeluqueriaBuss.GetDatosMaterial(idmaterial);


                    if (data.Rows.Count > 0)
                    {

                        this.txtnommaterial.Text = data.Rows[0]["Nombre"].ToString();
                        this.txtDescripciónmat.Text = data.Rows[0]["Descripcion"].ToString();
                        this.txtcategoria.Text = data.Rows[0]["Categoria"].ToString();
                        this.txtmodelo.Text = data.Rows[0]["Modelo"].ToString();
                        this.txtundmedida.Text = data.Rows[0]["UnidadMedida"].ToString();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('El material para el código ingresado no existe.')", true);
                        limpiarform();
                    }
                }
                else
                {

                    lblModalTitle.Text = "Buscar Material";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }


        protected void btnbuscarmaterialpopup_Click(object sender, EventArgs e)
        {
            try
            {
                Material mat = new Material();
                mat.Nombre = txtnombrepopup.Text;
                mat.DscMaterial = txtdescripcionpopup.Text;
                mat.Categoria = txtcategoriapopup.Text;
                mat.Modelo = txtmodelopopup.Text;

                DataTable material = AtencionPeluqueriaBuss.BusquedaMaterial(mat);
                ViewState["_datapopup"] = material;

                this.grvResultadoPopup.DataSource = material;
                this.grvResultadoPopup.DataBind();
                this.upModal.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }

        protected void grvResultadoPopup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = grvResultadoPopup.SelectedIndex;
            string idmat = grvResultadoPopup.DataKeys[index].Values[0].ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "callbusqueda(" + idmat + ");", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
        }

        private void limpiarform()
        {
            this.txtnommaterial.Text = string.Empty;
            this.txtDescripciónmat.Text = string.Empty;
            this.txtcategoria.Text = string.Empty;
            this.txtmodelo.Text = string.Empty;
            this.txtundmedida.Text = string.Empty;
            this.txtcantidad.Text = "0.00";
            this.txtpreciocompra.Text = "0.00";
            this.txtundmedida.Text = string.Empty;
            this.txtcodmaterial.Text = string.Empty;
        }

        protected void grvResultadoPopup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvResultadoPopup.PageIndex = e.NewPageIndex;
            grvResultadoPopup.DataSource = ViewState["_datapopup"];
            this.grvResultadoPopup.DataBind();
        }


    }
}