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
                    if (seg.IndiceHabilitado == 0)
                        Response.Redirect("Default.aspx");
                }
                this.CargaCombo();
                this.ConfigurarFechas();
            }

        }

        private void CargaCombo()
        {
            Utilidades.CargaCombo(ref cbojaula, AtencionPeluqueriaBuss.ParametroListar("005"), Utilitario.Comun.Dominios.Parametro, Utilitario.Comun.Dominios.DescripcionParametro, true);
        }

        private void ConfigurarFechas()
        {
            try
            {
                System.Globalization.CultureInfo objCulture = new System.Globalization.CultureInfo("es-PE");
                txtfecharegistro.Text = DateTime.Today.AddMonths(-1).ToString("dd/MM/yyyy", objCulture);

            }
            catch 
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
                int IdCita = Utilidades.ToInt(txtcodigocita.Text);
                if (IdCita > 0)
                {

                    DataSet Data = AtencionPeluqueriaBuss.GetDatosCita(IdCita);


                    if (Data.Tables[0].Rows.Count > 0)
                    {

                        txtcodigocliente.Text = Data.Tables[0].Rows[0]["idcliente"].ToString();
                        txtnombrecliente.Text = Data.Tables[0].Rows[0]["NombreCliente"].ToString();
                        txtcodigomascota.Text = Data.Tables[0].Rows[0]["idMascota"].ToString();
                        txtnombremascota.Text = Data.Tables[0].Rows[0]["nombreMascota"].ToString();
                        txtespeciemascota.Text = Data.Tables[0].Rows[0]["descripcionEspecie"].ToString();
                        txtedadmascota.Text = Data.Tables[0].Rows[0]["Edad"].ToString();
                        txtsexomascota.Text = Data.Tables[0].Rows[0]["DscSexoMascota"].ToString();
                        txttamañomascota.Text = Data.Tables[0].Rows[0]["tamaño"].ToString();

                        //detalle

                        this.grvresultado.DataSource = Data.Tables[1];
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
            catch 
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

                int IdCita = Utilidades.ToInt(txtcodigocita.Text);
                DataSet Data = AtencionPeluqueriaBuss.GetDatosCita(IdCita);


                if (Data.Tables[0].Rows.Count > 0)
                {

                    txtcodigocliente.Text = Data.Tables[0].Rows[0]["idcliente"].ToString();
                    txtnombrecliente.Text = Data.Tables[0].Rows[0]["NombreCliente"].ToString();
                    txtcodigomascota.Text = Data.Tables[0].Rows[0]["idMascota"].ToString();
                    txtnombremascota.Text = Data.Tables[0].Rows[0]["nombreMascota"].ToString();
                    txtespeciemascota.Text = Data.Tables[0].Rows[0]["descripcionEspecie"].ToString();
                    txtedadmascota.Text = Data.Tables[0].Rows[0]["Edad"].ToString();
                    txtsexomascota.Text = Data.Tables[0].Rows[0]["DscSexoMascota"].ToString();
                    txttamañomascota.Text = Data.Tables[0].Rows[0]["tamaño"].ToString();

                    //detalle

                    this.grvresultado.DataSource = Data.Tables[1];
                    this.grvresultado.DataBind();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('La cita para el código ingresado no existe, o no esta pendiente.')", true);
                    return;
                }

                HojaServicio Hoja = new HojaServicio();
                Hoja.IdEmpleado = 1;
                Hoja.FechaEmision = txtfecharegistro.Text;
                Hoja.NumHojaServicio = 0;
                Hoja.Canil = cbojaula.SelectedValue;
                Hoja.IdCita = Utilidades.ToInt(txtcodigocita.Text);
                Hoja.Observaciones = txtobservaciones.Text.ToUpper();
                AtencionPeluqueriaBuss.GrabarHojaServicio(Hoja, null, 1);
                Response.Redirect("ActualizarHojaServicio.aspx");
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
            }
        }




        protected void btnbuscarcitapopup_Click(object sender, EventArgs e)
        {
            try
            {
                Cita CitaEntidad = new Cita();
                CitaEntidad.FechaInicial = txtfechainicita.Text;
                CitaEntidad.FechaFinal = txtfechafincita.Text;
                CitaEntidad.Cliente = txtnombreclicita.Text;

                DataTable Citas = AtencionPeluqueriaBuss.BusquedaCita(CitaEntidad);

                this.grvResultadoPopup.DataSource = Citas;
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
            string IdCita = grvResultadoPopup.DataKeys[index].Values[0].ToString();
            txtcodigocita.Text = IdCita;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "callbusqueda(" + IdCita + ");", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
        }

       


    }
}