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
                    Seguridad Seg = (Seguridad)Session["_Seguridad"];
                    if (Seg.IndiceHabilitado == 0)
                        Response.Redirect("Default.aspx");
                }
                this.CargaCombo();
                this.ConfigurarFechas();
            }
        }

        private void CargaCombo()
        {
            Utilidades.CargaCombo(ref cboTipoMov, AtencionPeluqueriaBuss.ParametroListar("006"), Utilitario.Comun.Dominios.Parametro, Utilitario.Comun.Dominios.DescripcionParametro, true);
        }

        private void ConfigurarFechas()
        {
            try
            {
                System.Globalization.CultureInfo Culture = new System.Globalization.CultureInfo("es-PE");
                txtfecharegistro.Text = DateTime.Today.ToString("dd/MM/yyyy", Culture);

            }
            catch 
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

                int IdMaterial = Utilidades.ToInt(txtcodmaterial.Text);
                DataTable Data = AtencionPeluqueriaBuss.GetDatosMaterial(IdMaterial);

                decimal Cantidad = Utilidades.ToDecimal(txtcantidad.Text);

                if (Cantidad == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Ingrese la cantidad.'});", true);
                    return;
                }

                if (Data.Rows.Count > 0)
                {

                    this.txtnommaterial.Text = Data.Rows[0]["Nombre"].ToString();
                    this.txtDescripciónmat.Text = Data.Rows[0]["Descripcion"].ToString();
                    this.txtcategoria.Text = Data.Rows[0]["Categoria"].ToString();
                    this.txtmodelo.Text = Data.Rows[0]["Modelo"].ToString();
                    this.txtundmedida.Text = Data.Rows[0]["UnidadMedida"].ToString();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('El material para el código ingresado no existe.')", true);
                    limpiarform();
                    return;
                }


                KardexMaterial Kardex = new KardexMaterial();

                Kardex.FechaMovimiento = txtfecharegistro.Text;
                Kardex.Cantidad = Utilidades.ToDecimal(txtcantidad.Text);
                Kardex.PrecioCompra = Utilidades.ToDecimal(txtpreciocompra.Text);
                Kardex.TipoMovimiento = cboTipoMov.SelectedValue;
                Kardex.IdMaterial = Utilidades.ToInt(txtcodmaterial.Text);
                Kardex.NumGuia = txtnumguia.Text.ToUpper();
                AtencionPeluqueriaBuss.GrabarKardexMaterial(Kardex, 1);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Movimiento de kardex ingresado correctamente.'});", true);
                this.limpiarform();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }

        protected void btnbuscarmaterial_Click(object sender, EventArgs e)
        {
            try
            {
                int IdMaterial = Utilidades.ToInt(txtcodmaterial.Text);
                if (IdMaterial > 0)
                {

                    DataTable Data = AtencionPeluqueriaBuss.GetDatosMaterial(IdMaterial);


                    if (Data.Rows.Count > 0)
                    {

                        this.txtnommaterial.Text = Data.Rows[0]["Nombre"].ToString();
                        this.txtDescripciónmat.Text = Data.Rows[0]["Descripcion"].ToString();
                        this.txtcategoria.Text = Data.Rows[0]["Categoria"].ToString();
                        this.txtmodelo.Text = Data.Rows[0]["Modelo"].ToString();
                        this.txtundmedida.Text = Data.Rows[0]["UnidadMedida"].ToString();

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
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }


        protected void btnbuscarmaterialpopup_Click(object sender, EventArgs e)
        {
            try
            {
                Material MaterialEntidad = new Material();
                MaterialEntidad.Nombre = txtnombrepopup.Text;
                MaterialEntidad.DscMaterial = txtdescripcionpopup.Text;
                MaterialEntidad.Categoria = txtcategoriapopup.Text;
                MaterialEntidad.Modelo = txtmodelopopup.Text;

                DataTable Materiales = AtencionPeluqueriaBuss.BusquedaMaterial(MaterialEntidad);
                ViewState["_datapopup"] = Materiales;

                this.grvResultadoPopup.DataSource = Materiales;
                this.grvResultadoPopup.DataBind();
                this.upModal.Update();
            }
            catch
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