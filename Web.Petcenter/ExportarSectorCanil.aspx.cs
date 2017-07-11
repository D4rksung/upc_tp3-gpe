using Negocio.Petcenter;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Petcenter
{
    public partial class ExportarSectorCanil : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Text.StringBuilder msgError = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                try
                {

                    Int32 ColumnaDetalle = 1;
                    Int32 Contador = 0;
                    DataTable Data = AtencionPeluqueriaBuss.BuscarCanil(0, Request.QueryString["txtfechaIni"], Request.QueryString["txtFechaFinal"], Request.QueryString["cboRecurso"], Request.QueryString["cboEstado"]);
                    DataTable Data2 = AtencionPeluqueriaBuss.BuscarSector(0, Request.QueryString["txtfechaIni"], Request.QueryString["txtFechaFinal"], Request.QueryString["cboRecurso"], Request.QueryString["cboEstado"]);


                    string Name = Convert.ToString(DateTime.Now.Ticks);
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet WorkSheet = package.Workbook.Worksheets.Add("BASE");


                        Int32 Fila = 2;


                        if (Data.Rows.Count > 0 && (Request.QueryString["cboRecurso"] == "0" || Request.QueryString["cboRecurso"] == "" || Request.QueryString["cboRecurso"] == "1"))
                        {
                            ExcelRange range = WorkSheet.Cells[2, 1, 2, 6];
                            range.Merge = true;
                            WorkSheet.Cells[Fila, 1].Style.Font.SetFromFont(new Font("Calibri", 16, FontStyle.Bold));
                            WorkSheet.Cells[Fila, 1].Style.Font.Color.SetColor(Color.Black);
                            WorkSheet.Cells[Fila, 1].Value = "Listado de Canil";
                            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            Fila = Fila + 2;

                            WorkSheet.Cells[Fila, 1].Value = "CODIGO";
                            WorkSheet.Cells[Fila, 2].Value = "NOMBRE";
                            WorkSheet.Cells[Fila, 3].Value = "TAMAÑO";
                            WorkSheet.Cells[Fila, 4].Value = "ESTADO";
                            WorkSheet.Cells[Fila, 5].Value = "ESPECIE";
                            WorkSheet.Cells[Fila, 6].Value = "OBSERVACIONES";


                            ExcelRange RangoDeCeldasNameT2 = WorkSheet.Cells[Fila, 1, Fila, 6];
                            RangoDeCeldasNameT2.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT2.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT2.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT2.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT2.Style.Font.Color.SetColor(Color.Black);
                            RangoDeCeldasNameT2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            RangoDeCeldasNameT2.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FACA2C"));
                            RangoDeCeldasNameT2.Style.Font.Bold = true;
                            RangoDeCeldasNameT2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            RangoDeCeldasNameT2.Style.WrapText = true;


                            ColumnaDetalle = 1;
                            Contador = 0;
                            foreach (DataRow dr2 in Data.Rows)
                            {
                                Fila = Fila + 1;
                                ColumnaDetalle = 1;
                                foreach (DataColumn dr in Data.Columns)
                                {
                                    if (ColumnaDetalle <= 6)
                                    {
                                        WorkSheet.Cells[Fila, ColumnaDetalle].Value = dr2[dr.ColumnName];
                                    }
                                    ColumnaDetalle = ColumnaDetalle + 1;
                                    Contador = Contador + 1;
                                }

                                ExcelRange rangeCab6 = WorkSheet.Cells[Fila, 1, Fila, 6];

                                rangeCab6.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                rangeCab6.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                rangeCab6.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                rangeCab6.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                rangeCab6.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                rangeCab6.Style.Font.Color.SetColor(Color.Black);
                                rangeCab6.Style.Font.Bold = false;
                                rangeCab6.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                rangeCab6.Style.WrapText = true;


                            }
                            Fila = Fila + 2;
                        }

                        if (Data2.Rows.Count > 0 && (Request.QueryString["cboRecurso"] == "0" || Request.QueryString["cboRecurso"] == "" || Request.QueryString["cboRecurso"] == "2"))
                        {
                            ExcelRange range5 = WorkSheet.Cells[Fila, 1, Fila, 6];
                            range5.Merge = true;
                            WorkSheet.Cells[Fila, 1].Style.Font.SetFromFont(new Font("Calibri", 16, FontStyle.Bold));
                            WorkSheet.Cells[Fila, 1].Style.Font.Color.SetColor(Color.Black);
                            WorkSheet.Cells[Fila, 1].Value = "Listado de Sectores";
                            range5.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                            Fila = Fila + 2;

                            WorkSheet.Cells[Fila, 1].Value = "CODIGO";
                            WorkSheet.Cells[Fila, 2].Value = "NOMBRE";
                            WorkSheet.Cells[Fila, 3].Value = "SERVICIO";
                            WorkSheet.Cells[Fila, 4].Value = "ESTADO";
                            WorkSheet.Cells[Fila, 5].Value = "OBSERVACIONES";
                            ExcelRange RangoDeCeldasName5 = WorkSheet.Cells[Fila, 5, Fila, 6];
                            RangoDeCeldasName5.Merge = true;


                            ExcelRange RangoDeCeldasNameT4 = WorkSheet.Cells[Fila, 1, Fila, 6];
                            RangoDeCeldasNameT4.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT4.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT4.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT4.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            RangoDeCeldasNameT4.Style.Font.Color.SetColor(Color.Black);
                            RangoDeCeldasNameT4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            RangoDeCeldasNameT4.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FACA2C"));
                            RangoDeCeldasNameT4.Style.Font.Bold = true;
                            RangoDeCeldasNameT4.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            RangoDeCeldasNameT4.Style.WrapText = true;


                            ColumnaDetalle = 1;
                            Contador = 0;
                            foreach (DataRow dr3 in Data2.Rows)
                            {
                                Fila = Fila + 1;
                                ColumnaDetalle = 1;
                                foreach (DataColumn dr4 in Data2.Columns)
                                {
                                    if (ColumnaDetalle <= 5)
                                    {
                                        WorkSheet.Cells[Fila, ColumnaDetalle].Value = dr3[dr4.ColumnName];
                                        if (ColumnaDetalle == 5)
                                        {
                                            ExcelRange RangoDeCeldasNamecol5 = WorkSheet.Cells[Fila, 5, Fila, 6];
                                            RangoDeCeldasNamecol5.Merge = true;

                                        }
                                    }
                                    ColumnaDetalle = ColumnaDetalle + 1;
                                    Contador = Contador + 1;
                                }

                                ExcelRange RangeCab8 = WorkSheet.Cells[Fila, 1, Fila, 6];

                                RangeCab8.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                RangeCab8.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                RangeCab8.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                RangeCab8.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                RangeCab8.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                RangeCab8.Style.Font.Color.SetColor(Color.Black);
                                RangeCab8.Style.Font.Bold = false;
                                RangeCab8.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                RangeCab8.Style.WrapText = true;








                            }


                        }
                        ExcelColumn Col1 = WorkSheet.Column(1);
                        ExcelColumn Col2 = WorkSheet.Column(2);
                        ExcelColumn Col3 = WorkSheet.Column(3);
                        ExcelColumn Col4 = WorkSheet.Column(4);
                        ExcelColumn Col5 = WorkSheet.Column(5);
                        ExcelColumn Col6 = WorkSheet.Column(6);


                        Col1.Width = 20;
                        Col2.Width = 20;
                        Col3.Width = 20;
                        Col4.Width = 20;
                        Col5.Width = 20;
                        Col6.Width = 40;

                        Response.Clear();
                        Response.ContentType = "application/xlsx";
                        Response.AddHeader("content-disposition", "attachment; filename=Reporte_Canil_Sectores.xlsx");
                        Response.BinaryWrite(package.GetAsByteArray());
                        Response.End();

                    }

                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error interno en el sistema contacte a su administrador " + " Detalle:" + ex.Message;
                    msgError.Clear();
                    msgError.AppendLine("Fecha:" + DateTime.Now.ToString());
                    msgError.AppendLine("Descripción:" + ex.Message);
                    msgError.AppendLine("Detalle:" + ex.StackTrace);
                    log.Error(msgError.ToString());
                }
                

                
            }
        }
    }
}