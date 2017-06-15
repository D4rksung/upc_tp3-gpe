using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.Comun;
using Entidades.Petcenter;
using Negocio.Petcenter;
using System.Data;

namespace Web.Petcenter
{
    public partial class EditarHojaServicio : System.Web.UI.Page
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
            Utilidades.CargaCombo(ref cbojaula, AtencionPeluqueriaBuss.ParametroListar("005"), "Parametro", "DscParametro", true);
        }

        private void ConfigurarFechas()
        {
            try
            {
                System.Globalization.CultureInfo objCulture = new System.Globalization.CultureInfo("es-PE");
                txtfecharegistro.Text = DateTime.Today.AddMonths(-1).ToString("dd/MM/yyyy", objCulture);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizarHojaServicio.aspx");
        }

        protected void btnbuscarcita_Click(object sender, EventArgs e)
        {
            try
            {
                int idcita = Utilidades.ToInt(txtcodigocita.Text);
                if (idcita > 0)
                {

                    DataSet data = AtencionPeluqueriaBuss.GetDatosCita(idcita);


                    if (data.Tables[0].Rows.Count > 0)
                    {

                        txtcodigocliente.Text = data.Tables[0].Rows[0]["idcliente"].ToString();
                        txtnombrecliente.Text = data.Tables[0].Rows[0]["NombreCliente"].ToString();
                        txtcodigomascota.Text = data.Tables[0].Rows[0]["idMascota"].ToString();
                        txtnombremascota.Text = data.Tables[0].Rows[0]["nombreMascota"].ToString();
                        txtespeciemascota.Text = data.Tables[0].Rows[0]["descripcionEspecie"].ToString();
                        txtedadmascota.Text = data.Tables[0].Rows[0]["Edad"].ToString();
                        txtsexomascota.Text = data.Tables[0].Rows[0]["DscSexoMascota"].ToString();
                        txttamañomascota.Text = data.Tables[0].Rows[0]["tamaño"].ToString();

                        //detalle

                        this.grvresultado.DataSource = data.Tables[1];
                        this.grvresultado.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('La cita para el código ingresado no existe, o no esta pendiente.')", true);
                    }

                }
                else
                {

                    lblModalTitle.Text = "Buscar Cita";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }

        protected void btngrabar_Click(object sender, EventArgs e)
        {
            try
            {
                 if(txtcodigocliente.Text==string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('Debe realizar primero la busqueda de la cita.')", true);
                    return;
                }

                int idcita = Utilidades.ToInt(txtcodigocita.Text);
                DataSet data = AtencionPeluqueriaBuss.GetDatosCita(idcita);


                if (data.Tables[0].Rows.Count > 0)
                {

                    txtcodigocliente.Text = data.Tables[0].Rows[0]["idcliente"].ToString();
                    txtnombrecliente.Text = data.Tables[0].Rows[0]["NombreCliente"].ToString();
                    txtcodigomascota.Text = data.Tables[0].Rows[0]["idMascota"].ToString();
                    txtnombremascota.Text = data.Tables[0].Rows[0]["nombreMascota"].ToString();
                    txtespeciemascota.Text = data.Tables[0].Rows[0]["descripcionEspecie"].ToString();
                    txtedadmascota.Text = data.Tables[0].Rows[0]["Edad"].ToString();
                    txtsexomascota.Text = data.Tables[0].Rows[0]["DscSexoMascota"].ToString();
                    txttamañomascota.Text = data.Tables[0].Rows[0]["tamaño"].ToString();

                    //detalle

                    this.grvresultado.DataSource = data.Tables[1];
                    this.grvresultado.DataBind();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('La cita para el código ingresado no existe, o no esta pendiente.')", true);
                    return;
                }

                HojaServicio hoja = new HojaServicio();
                hoja.idEmpleado = 1;
                hoja.FechaEmision = txtfecharegistro.Text;
                hoja.NumHojaServicio = 0;
                hoja.Canil = cbojaula.SelectedValue;
                hoja.idCita = Utilidades.ToInt(txtcodigocita.Text);
                hoja.Observaciones = txtobservaciones.Text.ToUpper();
                AtencionPeluqueriaBuss.GrabarHojaServicio(hoja, null, 1);
                Response.Redirect("ActualizarHojaServicio.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }




        protected void btnbuscarcitapopup_Click(object sender, EventArgs e)
        {
            try
            {
                Cita cita = new Cita();
                cita.FechaInicial = txtfechainicita.Text;
                cita.FechaFinal = txtfechafincita.Text;
                cita.Cliente = txtnombreclicita.Text;

                DataTable citas = AtencionPeluqueriaBuss.BusquedaCita(cita);

                this.grvResultadoPopup.DataSource = citas;
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
            string idcita = grvResultadoPopup.DataKeys[index].Values[0].ToString();
            txtcodigocita.Text = idcita;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "callbusqueda(" + idcita + ");", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
        }

       


    }
}