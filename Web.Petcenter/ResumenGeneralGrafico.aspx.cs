﻿using Negocio.Petcenter;
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
    public partial class ResumenGeneralGrafico : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Text.StringBuilder msgError = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    DataSet Data = Negocio.Petcenter.Graficos.BuscarResumen();
                    lblServicioHoy.Text = Data.Tables[0].Rows[0]["ServicioHoy"].ToString();
                    lblServicioPendientes.Text = Data.Tables[0].Rows[0]["ServicioPendientes"].ToString();
                    lblServicioFinalizados.Text = Data.Tables[0].Rows[0]["ServicioFinalizados"].ToString();
                    lblTotalEmpleados.Text = Data.Tables[0].Rows[0]["TotalEmpleados"].ToString();
                    CargarCombos();
                    CargarGrid(0);

                }
                catch (Exception ex)
                {
                    msgError.Clear();
                    msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                    msgError.AppendLine("Descripción:" + ex.Message);
                    msgError.AppendLine("Detalle:" + ex.StackTrace);
                    log.Error(msgError.ToString());
                }
                
            }
        }
        void CargarCombos()
        {

            Utilidades.CargaCombo(ref cboGrafico1, AtencionPeluqueriaBuss.GetServicio(), Utilitario.Comun.Dominios.IdServicio, Utilitario.Comun.Dominios.DescripcionServicio, true);
            Utilidades.CargaCombo(ref cbografico4, AtencionPeluqueriaBuss.GetRoles("0"), Utilitario.Comun.Dominios.IdRol, Utilitario.Comun.Dominios.DescripcionRol, true);
            Utilidades.CargaCombo(ref filtroservicio, AtencionPeluqueriaBuss.GetServicio(), Utilitario.Comun.Dominios.IdServicio, Utilitario.Comun.Dominios.DescripcionServicio, true);
            Utilidades.CargaCombo(ref cboGrafico2, AtencionPeluqueriaBuss.GetServicio(), Utilitario.Comun.Dominios.IdServicio, Utilitario.Comun.Dominios.DescripcionServicio, true);
            
        }

        protected void cbografico4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                CargarGrid(Int32.Parse(cbografico4.SelectedValue));

            }
            catch (Exception ex)
            {
                msgError.Clear();
                msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                msgError.AppendLine("Descripción:" + ex.Message);
                msgError.AppendLine("Detalle:" + ex.StackTrace);
                log.Error(msgError.ToString());
            }
            
        }
        void CargarGrid(Int32 valor)
        {
            DataSet Data = Negocio.Petcenter.Graficos.BuscarGraficoIndicadorDePenetraciónPorServicioYSede(valor);
            gvEmpleados.DataSource = Data;
            gvEmpleados.DataBind();
        }
    }
}