using Entidades.Petcenter;
using Negocio.Petcenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Utilitario.Comun;

namespace Web.Petcenter
{
    public partial class ActualizaProgramacion : System.Web.UI.Page
    {
        public static DataTable EmpleadosAsig = new DataTable();
        public static DataTable Servicios = new DataTable();
        public static DataTable EmpleadosTotal = new DataTable();
        public static DataTable EmpleadosDetalle = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HtmlGenericControl DivProgramacion = (HtmlGenericControl)this.Master.FindControl("liprogramacion");
                DivProgramacion.Attributes.Add("class", "dropdown active");

                HtmlGenericControl DivInicio = (HtmlGenericControl)this.Master.FindControl("liinicio");
                DivInicio.Attributes.Add("class", "");

                this.CargaCombo();
                this.CargaListado();
                //this.CargarInfoSession();
            }
        }
        void CargarInfoSession()
        {

            if (Session["idCitaDetalle"] != null && Session["idCitaDetalle"].ToString() != "")
            {


                foreach (GridViewRow gvRow in grvresultado.Rows)
                {
                    if ((int)grvresultado.DataKeys[gvRow.DataItemIndex]["idCita"] == Int32.Parse(Session["idCitaDetalle"].ToString()))
                    {
                        grvresultado.SelectedIndex = gvRow.DataItemIndex;

                        grvresultado.Rows[grvresultado.SelectedIndex].BackColor = ColorTranslator.FromHtml("#E5E5E5");
                        grvresultado.Rows[grvresultado.SelectedIndex].ToolTip = string.Empty;
                        break;
                    }
                }

                //divDetalle.Visible = true;
                //divDetalle.Style.Add("width", "380px");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mydetallegrilla", "$('#mydetallegrilla').modal();", true);
                //upModalConfirmacion.Update();
                CargarDataDetalle(Int32.Parse(Session["idCitaDetalle"].ToString()));

            }
        }
        private void CargaCombo()
        {
            Utilidades.CargaCombo(ref cboEstado, AtencionPeluqueriaBuss.GetEstadosCita(), Utilitario.Comun.Dominios.IdEstado, Utilitario.Comun.Dominios.DescripcionEstado, true);
        }
        private void CargaListado()
        {
            
            Cita Obj = new Cita();
            Obj.FechaInicial = txtfechaInicio.Text;
            Obj.FechaFinal = txtFechaFin.Text;
            Obj.CodigoEstado = cboEstado.SelectedValue;

            DataTable Data = AtencionPeluqueriaBuss.BuscarCita(Obj);


            this.grvresultado.DataSource = Data;
            this.grvresultado.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaListado();
        }
        protected void grvresultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvresultado, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Ver Detalle";

                GridView gvDetalle = (GridView)e.Row.FindControl("gvDetalle");
                Int32 IdCita = Int32.Parse(grvresultado.DataKeys[e.Row.RowIndex].Values[0].ToString());

                DataSet Data = AtencionPeluqueriaBuss.BuscarCitaDetalle(IdCita);
                gvDetalle.DataSource = Data.Tables[0];
                gvDetalle.DataBind();

            }
        }


        protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Programar")
            {
                idDetalleCitaP.Value = e.CommandArgument.ToString().Split('|')[0];
                idServicioP.Value = e.CommandArgument.ToString().Split('|')[1];
                idCitaP.Value = e.CommandArgument.ToString().Split('|')[2];
                strServicio.Value = e.CommandArgument.ToString().Split('|')[3];
                CargarDataDetalle(idDetalleCitaP.Value, idServicioP.Value, strServicio.Value);

                lblModalPTitle.Text = "Programar Cita";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
                Session["idCitaDetalle"] = "";
                //EDITAR
            }
            if (e.CommandName == "Modificar")
            {
                idDetalleCitaP.Value = e.CommandArgument.ToString().Split('|')[0];
                idServicioP.Value = e.CommandArgument.ToString().Split('|')[1];
                idCitaP.Value = e.CommandArgument.ToString().Split('|')[2];
                strServicio.Value = e.CommandArgument.ToString().Split('|')[3];

                CargarDataDetalle(idDetalleCitaP.Value, idServicioP.Value, strServicio.Value);
                lblModalPTitle.Text = "Modificar Cita";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal();", true);
                upModalP.Update();
                Session["idCitaDetalle"] = "";
            }
            if (e.CommandName == "Anular")
            {
                lblModalATitle.Text = "Anular Cita";
                idDetalleCitaA.Value = e.CommandArgument.ToString().Split('|')[0];
                idServicioA.Value = e.CommandArgument.ToString().Split('|')[1];
                idCitaA.Value = e.CommandArgument.ToString().Split('|')[2];
                strServicio.Value = e.CommandArgument.ToString().Split('|')[3];

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalA", "$('#myModalA').modal();", true);
                upModalA.Update();
                Session["idCitaDetalle"] = "";
            }
        }
        protected void grvresultado_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvresultado.Rows)
            {

                CheckBox Marca = (CheckBox)row.Cells[0].FindControl("chkAsignacion");
                if (!Marca.Checked)
                {
                    if (row.RowIndex == grvresultado.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
                        row.ToolTip = string.Empty;
                        //divDetalle.Visible = true;
                        //divDetalle.Style.Add("width", "380px");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mydetallegrilla", "$('#mydetallegrilla').modal();", true);
                        //upModalConfirmacion.Update();
                        CargarDataDetalle(Int32.Parse(grvresultado.SelectedDataKey.Values[0].ToString()));
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = "Ver Detalle";
                    }
                }
            }
        }
        void CargarDataDetalle(Int32 idCita)
        {
            Session["idCitaDetalle"] = idCita.ToString();

            lblModalPTitleGD.Text = "Ver Cita";

            DataSet Data = AtencionPeluqueriaBuss.BuscarCitaDetalleCompleto(idCita);
            if (idCita != 0)
            {
                if (Data.Tables[0].Rows.Count > 0)
                {
                    txtObservaciones.Text = Data.Tables[0].Rows[0]["Observaciones"].ToString();

                }  //detalle


                Servicios = Data.Tables[1];
                EmpleadosDetalle = Data.Tables[2];

                this.grvresultadodet.DataSource = OrdenarServicios(Servicios, EmpleadosDetalle);
                this.grvresultadodet.DataBind();

            }
        }
        DataTable OrdenarServicios(DataTable Servicios, DataTable EmpleadosTotal2)
        {

            foreach (DataRow dr in Servicios.Rows)
            {
                String empleados = "";
                foreach (DataRow dr2 in EmpleadosTotal2.Select("idServicio=" + dr["idServicio"]))
                {
                    empleados = empleados + "," + dr2["nombreEmpleado"];
                }
                dr["Empleados"] = (empleados == "" ? "" : empleados.Substring(1, empleados.Length - 1));
            }

            return Servicios;
        }
        protected void btnOcultar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in grvresultado.Rows)
            {
                if ((int)grvresultado.DataKeys[gvRow.DataItemIndex]["idCita"] == Int32.Parse(Session["idCitaDetalle"].ToString()))
                {
                    grvresultado.Rows[grvresultado.SelectedIndex].BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    break;
                }
            }

            Session["idCitaDetalle"] = "";

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mydetallegrilla", "$( '#divcerrardetalle').click();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal7", "UpdateDatos();", true);
            //upModalConfirmacion.Update();

            //divDetalle.Visible = false;
            //divDetalle.Style.Add("width", "0px");
        }

        void CargarDataDetalle(String idDetalleCita, String idServicio, String nombreServicio)
        {
            DataSet Data = AtencionPeluqueriaBuss.BuscarCitaDetalleEmpleados(idDetalleCita, idServicio);
            if (idDetalleCita != "0")
            {
                if (Data.Tables[0].Rows.Count > 0)
                {
                    Utilidades.CargaCombo(ref cboSector, AtencionPeluqueriaBuss.GetSectores(idServicio), Utilitario.Comun.Dominios.IdSector, Utilitario.Comun.Dominios.DescripcionSector, true);
                    Utilidades.CargaCombo(ref cboRol, AtencionPeluqueriaBuss.GetRoles(idServicio), Utilitario.Comun.Dominios.IdRol, Utilitario.Comun.Dominios.DescripcionRol, true);
                    cboSector.SelectedValue = Data.Tables[0].Rows[0]["idSector"].ToString();
                    if (cboRol.Items.Count > 0) {
                    cboRol.SelectedIndex = 1;
                    }
                

                }  //detalle

                EmpleadosAsig = new DataTable();
                EmpleadosAsig.Columns.Add("idEmpleado");
                EmpleadosAsig.Columns.Add("nombreEmpleado");
                EmpleadosAsig.Columns.Add("idServicio");
                DataTable EmpleadosTotal = Data.Tables[1];
                if (EmpleadosTotal != null)
                {
                    foreach (DataRow dr in EmpleadosTotal.Select("idServicio=" + idServicio))
                    {
                        DataRow Dr1 = EmpleadosAsig.NewRow();
                        Dr1[0] = dr[0];
                        Dr1[1] = dr[1];
                        Dr1[2] = dr[2];
                        EmpleadosAsig.Rows.Add(Dr1);
                    }
                }
                this.gvEmpleadosAsig.DataSource = EmpleadosAsig;
                this.gvEmpleadosAsig.DataBind();
                CargarEmpleados();

            }
        }
        protected void cboRol_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEmpleados();
        }
        void CargarEmpleados()
        {
            List<Empleado> ListaEmpleados = new List<Empleado>();
            String Citasstr = "";
            Citasstr = idCitaA.Value;
            foreach (GridViewRow gvRow in grvresultado.Rows)
            {
                Int32 rowIndex = gvRow.RowIndex;
                String val = (string)grvresultado.DataKeys[rowIndex]["DescripcionCita"];
                Int32 IdCita = (Int32)grvresultado.DataKeys[rowIndex]["idCita"];
                CheckBox Marca = (CheckBox)gvRow.Cells[0].FindControl("chkAsignacion");
                if (Marca.Checked)
                {
                    Citasstr = Citasstr + ";" + IdCita.ToString();
                }

            }

            DataTable Empleados = AtencionPeluqueriaBuss.BuscarEmpleados(cboRol.SelectedValue, Citasstr);
            foreach (DataRow dr in Empleados.Rows)
            {
                if (EmpleadosAsig.AsEnumerable().Where(c => c.Field<string>("nombreEmpleado").Equals(dr["nombreEmpleado"])).Count() == 0)
                {
                    Empleado Obj = new Empleado();
                    Obj.IdEmpleado = Int32.Parse(dr["idEmpleado"].ToString());
                    Obj.NombreEmpleado = dr["nombreEmpleado"].ToString();
                    ListaEmpleados.Add(Obj);
                }
            }
            gvEmpleados.DataSource = Empleados;
            gvEmpleados.DataBind();
            gvEmpleadosAsig.DataSource = EmpleadosAsig;
            gvEmpleadosAsig.DataBind();
        }
        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EJECUTAR
            if (e.CommandName == "Accion")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvEmpleados.DataKeys[index][0]);

                if (EmpleadosAsig.Rows.Count < 2)
                {
                    DataRow dr = EmpleadosAsig.NewRow();
                    dr[0] = id;
                    dr[1] = gvEmpleados.Rows[index].Cells[0].Text;
                    dr[2] = idServicioP.Value;
                    EmpleadosAsig.Rows.Add(dr);
                    CargarEmpleados();
                }
                else
                {
                    lblModalValTitle.Text = "Advertencia";
                    lblVal.Text = "No puede asignar mas de 2 empleados.";
                    lblVal.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                    upModalVal.Update();
                }
            }



        }
        protected void gvEmpleadosAsig_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EJECUTAR
            if (e.CommandName == "Accion")
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                int Id = Convert.ToInt32(gvEmpleadosAsig.DataKeys[Index][0]);

                EmpleadosAsig.Rows.Remove(EmpleadosAsig.Select("idEmpleado=" + Id)[0]);
                CargarEmpleados();
            }



        }
        protected void btnGuardarP_Click(object sender, EventArgs e)
        {
            if (cboSector.SelectedValue != "0" && cboSector.SelectedValue != "" && gvEmpleadosAsig.Rows.Count > 0)
            {
                String Citasstr = "";
                Citasstr = idCitaP.Value;
                foreach (GridViewRow gvRow in grvresultado.Rows)
                {
                    Int32 rowIndex = gvRow.RowIndex;
                    String val = (string)grvresultado.DataKeys[rowIndex]["DescripcionCita"];
                    Int32 IdCita = (Int32)grvresultado.DataKeys[rowIndex]["idCita"];
                    CheckBox Marca = (CheckBox)gvRow.Cells[0].FindControl("chkAsignacion");
                    if (Marca.Checked)
                    {
                        Citasstr = Citasstr + ";" + IdCita.ToString();
                    }

                }
                if ((new ProgramacionCita()).GrabarProgramación(Int32.Parse(idServicioP.Value), Citasstr, EmpleadosAsig, Int32.Parse(idDetalleCitaP.Value), Int32.Parse(cboSector.SelectedValue.ToString()), 1, txtMotivoAnulacion.Text))
                {
                    EmpleadosAsig = new DataTable();
                    Servicios = new DataTable();
                    EmpleadosTotal = new DataTable();

                    lblMensajeTitulo.Text = "Informativo";
                    lblMensaje.Text = "Informativo: Se procedió a cambiar el(los) recurso(s) asignado(s) al servicio " + strServicio.Value + ".";
                    lblMensaje.ForeColor = System.Drawing.Color.Blue;


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
                lblVal.Text = "Ocurrio un error en el sistema: Debe ingresar el Sector y/o por lo menos un empleado.";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();
            }

        }


        protected void btnGuardarA_Click(object sender, EventArgs e)
        {
            if (txtMotivoAnulacion.Text.Trim() == "")
            {


                lblModalValTitle.Text = "Error";
                lblVal.Text = "Ocurrio un error en el sistema: Debe ingresar el Motivo de Anulación de la planificación del servicio";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();

            }
            else
            {

                lblConfirmacionTitulo.Text = "Confirmación";
                lblConfirmacion.Text = "Confirmación:¿Desea continuar con la anulación de la planificación de servicio?";
                lblConfirmacion.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal();", true);
                upModalConfirmacion.Update();

            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalM", "UpdateDatos();", true);

        }

        protected void btnCancelarP_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalP", "$('#myModalP').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal3", "UpdateDatos();", true);

        }
        protected void btnCancelarA_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalA", "$('#myModalA').modal('hide');", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal4", "UpdateDatos();", true);

        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalConfirmacion", "$('#myModalConfirmacion').modal('hide');", true);
            List<Cita> ListCita = new List<Cita>();
            String Citasstr = "";
            Citasstr = idCitaA.Value;
            foreach (GridViewRow gvRow in grvresultado.Rows)
            {
                Int32 rowIndex = gvRow.RowIndex;
                String val = (string)grvresultado.DataKeys[rowIndex]["DescripcionCita"];
                Int32 IdCita = (Int32)grvresultado.DataKeys[rowIndex]["idCita"];
                CheckBox Marca = (CheckBox)gvRow.Cells[0].FindControl("chkAsignacion");
                if (Marca.Checked)
                {
                    Citasstr = Citasstr + ";" + IdCita.ToString();
                }

            }

            if ((new ProgramacionCita()).GrabarProgramación(Int32.Parse(idServicioA.Value), Citasstr, EmpleadosAsig, Int32.Parse(idDetalleCitaA.Value), Int32.Parse(cboSector.SelectedValue.ToString()), 2, txtMotivoAnulacion.Text))
            {
                lblMensajeTitulo.Text = "Informativo";
                lblMensaje.Text = "Informativo:Se realizó la anulación de la planificación de atención con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Blue;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalA", "$('#myModalA').modal('hide');", true);
                txtMotivoAnulacion.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMensaje", "$('#myModalMensaje').modal();", true);
                upModalMensaje.Update();
                txtMotivoAnulacion.Text = "";
            }
            else
            {


                lblModalValTitle.Text = "Error";
                lblVal.Text = "Ocurrió un error en el sistema. Error de Base de datos.";
                lblVal.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalVal", "$('#myModalVal').modal();", true);
                upModalVal.Update();


            }

        }
        protected void gvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvresultado.PageIndex = e.NewPageIndex;
            CargaListado();
        }
        protected void chkAsignacion_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow Fila = (GridViewRow)(((CheckBox)sender).NamingContainer);
            CheckBox Marca = (CheckBox)Fila.Cells[0].FindControl("chkAsignacion");
            if (Marca.Checked)
            {
                int rowIndex = Fila.RowIndex;
                string val = (string)grvresultado.DataKeys[rowIndex]["DescripcionCita"];
                CargarOtrosServ(val);
            }
            else
            {
                Fila.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            }

        }
        void CargarOtrosServ(String servicios)
        {
            foreach (GridViewRow gvRow in grvresultado.Rows)
            {
                Int32 FilaIndex = gvRow.RowIndex;
                String Val = (string)grvresultado.DataKeys[FilaIndex]["DescripcionCita"];
                Int32 IdCita = (Int32)grvresultado.DataKeys[FilaIndex]["idCita"];
                if (Val == servicios)
                {
                    gvRow.BackColor = ColorTranslator.FromHtml("#E8E5F5");
                    CheckBox Marca = (CheckBox)gvRow.Cells[0].FindControl("chkAsignacion");
                    Marca.Checked = true;
                }
                else
                {
                    gvRow.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    CheckBox Marca = (CheckBox)gvRow.Cells[0].FindControl("chkAsignacion");
                    Marca.Checked = false;

                }
            }
        }
    }
}