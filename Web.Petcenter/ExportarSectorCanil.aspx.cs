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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Int32 colDetalle = 1;
                Int32 conta = 0;
                DataTable data = AtencionPeluqueriaBuss.BuscarCanil(0, Request.QueryString["txtfechaIni"], Request.QueryString["txtFechaFinal"], Request.QueryString["cboRecurso"] , Request.QueryString["cboEstado"]  );
                DataTable data2 = AtencionPeluqueriaBuss.BuscarSector(0, Request.QueryString["txtfechaIni"], Request.QueryString["txtFechaFinal"], Request.QueryString["cboRecurso"], Request.QueryString["cboEstado"]);


                string name = Convert.ToString(DateTime.Now.Ticks);

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("BASE");


                    Int32 int_fila = 2;
                    Int32 int_col = 1;

                    if (data.Rows.Count > 0 && (Request.QueryString["cboRecurso"] =="0" || Request.QueryString["cboRecurso"]=="" || Request.QueryString["cboRecurso"]=="1"))
                    {
                        ExcelRange range = worksheet.Cells[2, 1, 2, 6];
                        range.Merge = true;
                        worksheet.Cells[int_fila, 1].Style.Font.SetFromFont(new Font("Calibri", 16, FontStyle.Bold));
                        worksheet.Cells[int_fila, 1].Style.Font.Color.SetColor(Color.Black);
                        worksheet.Cells[int_fila, 1].Value = "Listado de Canil";
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        int_fila = int_fila + 2;

                        worksheet.Cells[int_fila, 1].Value = "CODIGO";
                        worksheet.Cells[int_fila, 2].Value = "NOMBRE";
                        worksheet.Cells[int_fila, 3].Value = "TAMAÑO";
                        worksheet.Cells[int_fila, 4].Value = "ESTADO";
                        worksheet.Cells[int_fila, 5].Value = "ESPECIE";
                        worksheet.Cells[int_fila, 6].Value = "OBSERVACIONES";


                        ExcelRange rangoDeCeldasNameT2 = worksheet.Cells[int_fila, 1, int_fila, 6];
                        rangoDeCeldasNameT2.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT2.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT2.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT2.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT2.Style.Font.Color.SetColor(Color.Black);
                        rangoDeCeldasNameT2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rangoDeCeldasNameT2.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FACA2C"));
                        rangoDeCeldasNameT2.Style.Font.Bold = true;
                        rangoDeCeldasNameT2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        rangoDeCeldasNameT2.Style.WrapText = true;
                        

                        colDetalle = 1;
                        conta = 0;
                        foreach (DataRow dr2 in data.Rows)
                        {
                            int_fila = int_fila + 1;
                            colDetalle = 1;
                            foreach (DataColumn dr in data.Columns)
                            {
                                if (colDetalle <= 6)
                                {
                                    worksheet.Cells[int_fila, colDetalle].Value = dr2[dr.ColumnName];
                                }
                                colDetalle = colDetalle + 1;
                                conta = conta + 1;
                            }

                            ExcelRange rangeCab6 = worksheet.Cells[int_fila, 1, int_fila, 6];

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
                        int_fila = int_fila + 2;
                    }

                    if (data2.Rows.Count > 0 && (Request.QueryString["cboRecurso"] == "0" || Request.QueryString["cboRecurso"] == "" || Request.QueryString["cboRecurso"] == "2"))
                    { 
                        ExcelRange range5 = worksheet.Cells[int_fila, 1, int_fila, 6];
                        range5.Merge = true;
                        worksheet.Cells[int_fila, 1].Style.Font.SetFromFont(new Font("Calibri", 16, FontStyle.Bold));
                        worksheet.Cells[int_fila, 1].Style.Font.Color.SetColor(Color.Black);
                        worksheet.Cells[int_fila, 1].Value = "Listado de Sectores";
                        range5.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                        int_fila = int_fila + 2;
                        int_col = 1;
                        worksheet.Cells[int_fila, 1].Value = "CODIGO";
                        worksheet.Cells[int_fila, 2].Value = "NOMBRE";
                        worksheet.Cells[int_fila, 3].Value = "SERVICIO";
                        worksheet.Cells[int_fila, 4].Value = "ESTADO";
                        worksheet.Cells[int_fila, 5].Value = "OBSERVACIONES";
                        ExcelRange rangoDeCeldasName5 = worksheet.Cells[int_fila, 5, int_fila, 6];
                        rangoDeCeldasName5.Merge = true;


                        ExcelRange rangoDeCeldasNameT4 = worksheet.Cells[int_fila, 1, int_fila, 6];
                        rangoDeCeldasNameT4.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT4.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT4.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT4.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rangoDeCeldasNameT4.Style.Font.Color.SetColor(Color.Black);
                        rangoDeCeldasNameT4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rangoDeCeldasNameT4.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FACA2C"));
                        rangoDeCeldasNameT4.Style.Font.Bold = true;
                        rangoDeCeldasNameT4.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        rangoDeCeldasNameT4.Style.WrapText = true;
                        

                        colDetalle = 1;
                        conta = 0;
                        foreach (DataRow dr3 in data2.Rows)
                        {
                            int_fila = int_fila + 1;
                            colDetalle = 1;
                            foreach (DataColumn dr4 in data2.Columns)
                            {
                                if (colDetalle <= 5)
                                {
                                    worksheet.Cells[int_fila, colDetalle].Value = dr3[dr4.ColumnName];
                                    if (colDetalle == 5)
                                    {
                                        ExcelRange rangoDeCeldasNamecol5 = worksheet.Cells[int_fila, 5, int_fila, 6];
                                        rangoDeCeldasNamecol5.Merge = true;

                                    }
                                }
                                colDetalle = colDetalle + 1;
                                conta = conta + 1;
                            }

                            ExcelRange rangeCab8 = worksheet.Cells[int_fila, 1, int_fila, 6];

                            rangeCab8.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rangeCab8.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rangeCab8.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rangeCab8.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rangeCab8.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            rangeCab8.Style.Font.Color.SetColor(Color.Black);
                            rangeCab8.Style.Font.Bold = false;
                            rangeCab8.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            rangeCab8.Style.WrapText = true;








                        }


                    }
                        ExcelColumn col1 = worksheet.Column(1);
                        ExcelColumn col2 = worksheet.Column(2);
                        ExcelColumn col3 = worksheet.Column(3);
                        ExcelColumn col4 = worksheet.Column(4);
                        ExcelColumn col5 = worksheet.Column(5);
                        ExcelColumn col6 = worksheet.Column(6);


                        col1.Width = 20;
                        col2.Width = 20;
                        col3.Width = 20;
                        col4.Width = 20;
                        col5.Width = 20;
                        col6.Width = 40;

                        Response.Clear();
                        Response.ContentType = "application/xlsx";
                        Response.AddHeader("content-disposition", "attachment; filename=Reporte_Canil_Sectores.xlsx");
                        Response.BinaryWrite(package.GetAsByteArray());
                        Response.End();

                }
            }
        }
    }
}