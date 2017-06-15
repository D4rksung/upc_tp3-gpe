using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Petcenter;
using Negocio.Petcenter;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class ActualizarHojaServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                try
                {
                    if(Session["_Seguridad"] == null){
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Seguridad seg = (Seguridad)Session["_Seguridad"];
                        if(seg.indHabilitado==0)
                            Response.Redirect("Default.aspx");
                    }
                      
                this.CargaCombo();
                   ListarHojas();
                }
                catch (ArgumentException ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
                    //lblmsg.Text = ex.Message;
                }
            }

        }

        private void CargaCombo()
        {
            Utilidades.CargaCombo(ref cboservicio, AtencionPeluqueriaBuss.GetServicio(), "idServicio", "descripcion", true);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarHojaServicio.aspx");
        }

        private void ListarHojas()
        {
            HojaServicio hoja = new HojaServicio();
            hoja.NumHojaServicio = Utilidades.ToInt(txtNumeroHoja.Text);
            hoja.idServicio = Utilidades.ToInt(cboservicio.SelectedValue);
            hoja.FechaInicial = txtfechaInicio.Text;
            hoja.FechaFinal = txtFechaFin.Text;
            hoja.idCliente = Utilidades.ToInt(txtcodigocliente.Text);
            hoja.NombreCliente = txtnombrecliente.Text;

            DataTable data = AtencionPeluqueriaBuss.BusquedaHojaServicio(hoja);

            if (data.Rows.Count == 0)
                lblmsg.Text = "Sin registros para mostrar";
            else
                lblmsg.Text = "";

            this.grvresultado.DataSource = data;
            this.grvresultado.DataBind();
        }


        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListarHojas();
            }
            catch (ArgumentException ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
                //lblmsg.Text = ex.Message;
            }
        }

        protected void grvresultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EJECUTAR
            if (e.CommandName == "Ejecutar")
            {
                int idHoja = Utilidades.ToInt(e.CommandArgument.ToString());
                try
                {
                    DataSet data = AtencionPeluqueriaBuss.GetDatosHojaServicioEjecutar(idHoja);


                    if (data.Tables[0].Rows.Count > 0)
                    {
                        hfidHojaServicio.Value = data.Tables[0].Rows[0]["idHojaServicio"].ToString();
                        txtfechaemisionalt.Text = data.Tables[0].Rows[0]["fechaRegistro"].ToString();
                        txtobservacionesejecutar.Text = data.Tables[0].Rows[0]["Observaciones"].ToString();

                        //detalle

                        this.grvResultadoPopup.DataSource = data.Tables[1];
                        this.grvResultadoPopup.DataBind();


                        lblModalTitle.Text = "Ejecutar Hoja de servicio";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        upModal.Update();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "alert('No existe servicios agregados en la Hoja de servicio')", true);
                    }


                }
                catch (Exception ex)
                {
                    //this.lblmsg.Text = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
                }

                //EDITAR
            }

            else if (e.CommandName == "Anular")
            {
                try
                {
                    int idHoja = Utilidades.ToInt(e.CommandArgument.ToString());
                    GridViewRow gvr = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                    int RowIndex = gvr.RowIndex;

                    HojaServicio hoja = new HojaServicio() { idHojaServicio = idHoja };
                    AtencionPeluqueriaBuss.GrabarHojaServicio(hoja, (new List<DetalleServicio>()), 3);
                    ListarHojas();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
                }

            }

        }

        protected void btngrabarejecutar_Click(object sender, EventArgs e)
        {
            try
            {

                //Validando campos obligatorios
                if (txtfechaemisionalt.Text == string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Ingrese la fecha de emisión.'});", true);
                    return;
                }
                //Guardando cabecera
                HojaServicio hoja = new HojaServicio();
                hoja.idHojaServicio = Utilidades.ToInt(hfidHojaServicio.Value);
                hoja.FechaEmision = txtfechaemisionalt.Text;
                hoja.Observaciones = txtobservacionesejecutar.Text;

                //Guardando detalles
                List<DetalleServicio> lista = new List<DetalleServicio>();
                DropDownList ddestado = default(DropDownList);
                DropDownList empleado = default(DropDownList);
                TextBox txthorainicio = default(TextBox);
                TextBox txthorafin = default(TextBox);

                DetalleServicio item = null;
                for (Int32 i = 0; i <= grvResultadoPopup.Rows.Count - 1; i++)
                {
                    item = new DetalleServicio();

                    item.iddetalleHojaServicio = Utilidades.ToInt(this.grvResultadoPopup.DataKeys[i].Values[0].ToString());
                    ddestado = (DropDownList)grvResultadoPopup.Rows[i].FindControl("cboEstadoser");
                    empleado = (DropDownList)grvResultadoPopup.Rows[i].FindControl("cboEmpleadoServ");
                    txthorainicio = (TextBox)grvResultadoPopup.Rows[i].FindControl("txtHorainicio");
                    txthorafin = (TextBox)grvResultadoPopup.Rows[i].FindControl("txtHoraFin");

                    if(ddestado.SelectedValue == "002")
                    {
                    if(txthorainicio.Text == string.Empty)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Ingrese la hora de inicio.'});", true);
                            return;
                        }

                        if (txthorafin.Text == string.Empty)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Ingrese la hora de Fin.'});", true);
                            return;
                        }

                        if (empleado.SelectedValue =="0")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Seleccione el empleado que ejecuto el servicio.'});", true);
                            return;
                        }

                    }

                    item.Estado = ddestado.SelectedValue;
                    item.HoraInicio = txthorainicio.Text;
                    item.HoraFin = txthorafin.Text;
                    lista.Add(item);
                }


                AtencionPeluqueriaBuss.GrabarHojaServicio(hoja, lista, 2);
                ListarHojas();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "callbusqueda();", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "$.growl.warning({ title: 'Mensaje Sistema', message: 'Error interno del sistema.'});", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                //this.lblmsg.Text = ex.Message;
            }
        }

        protected void grvResultadoPopup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = e.Row.FindControl("cboEmpleadoServ") as DropDownList;
                if (ddl != null)
                {
                    Utilidades.CargaCombo(ref ddl, AtencionPeluqueriaBuss.GetEmpleados(), "idEmpleado", "nombres", true);
                }
            }
        }


    }
}