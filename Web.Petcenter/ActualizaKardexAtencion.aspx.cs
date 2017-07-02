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
    public partial class ActualizaKardexAtencion : System.Web.UI.Page
    {
        public static DataTable dtMateriales;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombo();
                CargarDetalle();
            }
        }
        
        void CargarDetalle()
        {
            DataTable data = AtencionPeluqueriaBuss.BuscarMovimientosAtencion(Int32.Parse(cboAlmacen.SelectedValue), txtMaterial.Text, txtReq.Text);
            grvresultado.DataSource = data;
            grvresultado.DataBind();
            
        }
         private void CargarCombo()
        {

            Utilidades.CargaCombo(ref cboAlmacen, AtencionPeluqueriaBuss.GetAlmacen(), "idAlmacen", "descripcion", true);
                  
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdDetReqMaterial");
            dt.Columns.Add("Precio", typeof(Decimal));
            dt.Columns.Add("Cantidad", typeof(Decimal));

            foreach (GridViewRow gvRow in grvresultado.Rows)
            {
                DataRow dr = dt.NewRow();
                Int32 rowIndex = gvRow.RowIndex;
                Int32 idMaterial = (Int32)grvresultado.DataKeys[rowIndex]["idMovimiento"];
                TextBox txtCantidad = (TextBox)gvRow.Cells[0].FindControl("txtCantidad");
                if (Decimal.Parse(txtCantidad.Text) > 0)
                {
                    dr[0] = idMaterial;
                    dr[1] = 0;
                    dr[2] = txtCantidad.Text;
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                if ((new ProgramacionCita()).GrabarMovimientoAtencion(dt))
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

        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado.PageIndex = e.NewPageIndex;
            CargarDetalle();
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);
            CargarDetalle();
            UpdatePanel2.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM1", "UpdateDatos();", true);

        }

        void ActualizarParent()
        {


            string script = "$(document).ready(function () { $('[id*=btnBuscar]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
            
        }
       

       
    }
    }
