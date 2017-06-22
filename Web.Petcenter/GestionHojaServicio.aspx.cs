using Negocio.Petcenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class GestionHojaServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtfechaIni.Text = DateTime.Now.ToShortDateString();
                txtFechaFinal.Text = DateTime.Now.ToShortDateString();
                CargarDetalle();
                CargarCombo();
            }
        }

        private void CargarCombo()
        {
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetEstadosCita(), "idEstado", "descripcion", true);
        }
        void CargarDetalle()
        {
            DataTable data = AtencionPeluqueriaBuss.BuscarServicioHoy(0, txtfechaIni.Text, txtFechaFinal.Text);
            gvDetalle.DataSource = data;
            gvDetalle.DataBind();
        }

        void CargarDataDetalle(Int32 iddetalleCita, Int32 tipo)
        {

            DataSet data = AtencionPeluqueriaBuss.BuscarServicioDetalle(iddetalleCita);

            if (data.Tables[0].Rows.Count > 0)
            {
                imgMascota.ImageUrl = data.Tables[0].Rows[0]["Foto"].ToString();

                txtNombreMascota.Text = data.Tables[0].Rows[0]["nombreMascota"].ToString();
                txtEspecieMascota.Text = data.Tables[0].Rows[0]["especieMascota"].ToString();
                txtRazaMascota.Text = data.Tables[0].Rows[0]["razaMascota"].ToString();
                txtAlertas.Text = data.Tables[0].Rows[0]["observaciones"].ToString();
                cboEstado.SelectedValue = data.Tables[0].Rows[0]["estado"].ToString();

                gvComents.DataSource = data.Tables[2];
                gvComents.DataBind();

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
        protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ejecutar")
            {
                idDetalleCita.Value = e.CommandArgument.ToString();
                CargarDataDetalle( Int32.Parse(idDetalleCita.Value),1);

                lblModalPTitle.Text = "Hoja de servicio peluquería";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP" , "$('#myModalP').modal();", true);
                upModalP.Update();
                //EDITAR
            }
            if (e.CommandName == "Finalizar")
            {
                idDetalleCita.Value = e.CommandArgument.ToString();

                CargarDataDetalle(Int32.Parse(idDetalleCita.Value), 2);
                lblModalPTitle.Text = "Hoja de servicio peluquería";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP" , "$('#myModalP').modal();", true);
                upModalP.Update();
            }
        }

        protected void btnGuardarP_Click(object sender, EventArgs e)
        {
                if (1==1)//(new ProgramacionCita()).GrabarHojaServicio(Int32.Parse(idServicioP.Value), Citasstr, EmpleadosAsig, Int32.Parse(idDetalleCitaP.Value), Int32.Parse(cboSector.SelectedValue.ToString()), 1, txtMotivoAnulacion.Text))
                {

                    lblMensajeTitulo.Text = "MENSAJE INFORMATIVO";
                    lblMensaje.Text = "Mensaje informativo: Se procedió a asignar recursos al servicio.";
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;


                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                    upModalMensaje.Update();
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM", "UpdateDatos();", true);

        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);
            
            if (1==1)//(new ProgramacionCita()).GrabarProgramación(Int32.Parse(idServicioA.Value), Citasstr, EmpleadosAsig, Int32.Parse(idDetalleCitaA.Value), Int32.Parse(cboSector.SelectedValue.ToString()), 2, txtMotivoAnulacion.Text))
            {
                lblMensajeTitulo.Text = "INFORMATIVO";
                lblMensaje.Text = "Informativo:Se procedió a Anular planificación de atención.";
                lblMensaje.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalA", "$('#myModalA').modal('hide');", true);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                upModalMensaje.Update();
            }
            else
            {


                lblModalValTitle.Text = "ERROR";
                lblVal.Text = "Error:Valide la información con el administrador del sistema.";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();


            }

        }

    }
}