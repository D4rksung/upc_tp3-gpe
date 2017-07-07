<%@ Page Title="" Language="C#" MasterPageFile="~/MasterGraficos.Master" AutoEventWireup="true" CodeBehind="ResumenGeneralGrafico.aspx.cs" Inherits="Web.Petcenter.ResumenGeneralGrafico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="col-lg-12">
        <section class="box nobox ">
            <div class="content-body">

                <h4>MONITOREO DEL DÍA</h4>
                <hr />
                <div class="row">
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="r4_counter db_box">
                            <i class='pull-left fa fa-bookmark icon-md icon-rounded icon-primary'></i>
                            <div class="stats">
                                <h4><strong>
                                    <asp:Label ID="lblServicioHoy" runat="server"></asp:Label></strong></h4>
                                <span>Total de Servicios para hoy</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="r4_counter db_box">
                            <i class='pull-left fa fa-database icon-md icon-rounded icon-accent'></i>
                            <div class="stats">
                                <h4><strong>
                                    <asp:Label ID="lblServicioPendientes" runat="server"></asp:Label></strong></h4>
                                <span>Servicios Pendientes</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="r4_counter db_box">
                            <i class='pull-left glyphicon glyphicon-check icon-md icon-rounded icon-purple'></i>
                            <div class="stats">
                                <h4><strong>
                                    <asp:Label ID="lblServicioFinalizados" runat="server"></asp:Label></strong></h4>
                                <span>Servcios Finalizados</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="r4_counter db_box">
                            <i class='pull-left fa fa-users icon-md icon-rounded icon-warning'></i>
                            <div class="stats">
                                <h4><strong>
                                    <asp:Label ID="lblTotalEmpleados" runat="server"></asp:Label></strong></h4>
                                <span>Total Empleados</span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>
    </div>

    <%-- Grafico por servicio--%>
    <div class="col-lg-12">
        <section class="box ">

            <div class="content-body">
                <div class="row">
                    <div class="col-xs-4">
                        <h5>Demanda semanal (prom.) por Servicio</h5>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-4">
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-addon">Filtro:</div>
                                <asp:DropDownList ID="cboGrafico1" runat="server" class="form-control">
                                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div id="morris_bar_graph"></div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <%--Gráfico por empleado--%>
    <div class="col-lg-12">
        <section class="box ">

            <div class="content-body">
                <div class="row">
                    <div class="col-xs-4">
                        <h5>Indicador de Actividad por empleado</h5>
                    </div>
                </div>
                <hr />
                <div class="row" >
                    <div class="col-xs-4">
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-addon">Filtro:</div>
                                <asp:DropDownList ID="cboGrafico2" runat="server" class="form-control">
                                    <asp:ListItem Value="">Seleccione</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-8">

                        <div class="row flot-chart-area">
                            <div class="col-xs-11">
                                <div class="flot-demo-container">
                                    <div id="flotpie" class="flot-demo-placeholder"></div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-xs-4">
                        <div class="col-xs-12">
                            <h5>Leyenda</h5>
                            <hr />
                        </div>
                        <div class="map_progress col-xs-12 col-sm-12">
                            <table style="position: initial; top: 5px; right: 5px; font-size: smaller; color: #545454">
                                <tbody>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid rgb(240,32,61); overflow: hidden">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">&nbsp;0% a 30%    Actividad ligera</td>
                                    </tr>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid rgb(233,152,47); overflow: hidden">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">&nbsp;31% a 60%     Actividad moderada</td>
                                    </tr>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid rgb(80,170,10); overflow: hidden">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">&nbsp;61% a 100%   Actividad pesada</td>
                                    </tr>
                                </tbody>
                            </table>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12">
                                    <span class='text-muted'><small>[1] Total de carga = Promedio de  Sumatoria(Puntaje  * Cantidad) de asignaciones del día.<br />
                                        [2] Cada empleado tendrá un máx. de 150 puntos que es el 100% de su capacidad operativa.<br />
                                        [3] Cada Servicio tendrá un puntaje asignado por el administrador.
</small></span>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="col-lg-12">
                <section class="box nobox ">
                    <div class="content-body">

                        <div class="row">
                            <div class="col-xs-12">
                                <div class="wid-vectormap db_box">
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <h5>Indicador  de Eficiencia de Recurso por Rol de Servicio</h5>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">Rol:</div>
                                                    <asp:DropDownList ID="cbografico4" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="cbografico4_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-8">
                                            <asp:GridView ID="gvEmpleados" runat="server" class="table table-bordered" Width="100%"
                                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false" ShowHeaderWhenEmpty="True" ShowHeader="false">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="ACCIÓN">
                                                        <ItemTemplate>

                                                            <div class="map_progress col-xs-12 col-sm-12">
                                                                <h4><%# Eval("EmpleadoNombre") %></h4>
                                                                <span class='text-muted'><small><%# Eval("Avance") %>%</small></span>
                                                                <div class="progress">
                                                                    <div class="progress-bar progress-bar-primary" role="progressbar" aria-valuenow='<%# Eval("Avance") %>' aria-valuemin="0" aria-valuemax="100" style='width: <%# Eval("Avance") %>%; background-color: <%# Eval("Color") %> !important'></div>
                                                                </div>
                                                                <br>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="col-xs-4">
                                            <div class="col-xs-12">
                                                <h5>Leyenda</h5>
                                                <hr />
                                            </div>
                                            <div class="map_progress col-xs-12 col-sm-12">
                                                <table style="position: initial; top: 5px; right: 5px; font-size: smaller; color: #545454">
                                                    <tbody>
                                                        <tr>
                                                            <td class="legendColorBox">
                                                                <div style="border: 1px solid #ccc; padding: 1px">
                                                                    <div style="width: 4px; height: 0; border: 5px solid rgb(240,32,61); overflow: hidden">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="legendLabel">&nbsp;0% - 25%   Poco eficiente</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="legendColorBox">
                                                                <div style="border: 1px solid #ccc; padding: 1px">
                                                                    <div style="width: 4px; height: 0; border: 5px solid rgb(233,152,47); overflow: hidden">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="legendLabel">&nbsp;25.1 % - 60 %  Eficiente</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="legendColorBox">
                                                                <div style="border: 1px solid #ccc; padding: 1px">
                                                                    <div style="width: 4px; height: 0; border: 5px solid rgb(80,170,10); overflow: hidden">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="legendLabel">&nbsp;60.1 % - 100 %  Muy Eficiente</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- End .row -->
                        <div class="clearfix spacer20"></div>

                    </div>
                </section>
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <%--Grafico por xxxx--%>

    <div class="col-xs-12">
        <section class="box ">

            <div class="content-body">
                <div class="row">
                    <div class="col-xs-4">
                        <h5>Indicador de Penetración de cada Servicio por Sede</h5>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-4">
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-addon">Servicio:</div>
                                <asp:DropDownList ID="filtroservicio" runat="server" class="form-control">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-offset-4 col-sm-offset-4 col-xs-offset-3 col-xs-6 col-sm-4" id="contentpolar">
                        <canvas id="polar-chartjs" width="300" height="300"></canvas>
                    </div>
                    <div class="col-xs-4">
                        <div class="col-xs-12">
                            <h5>Leyenda</h5>
                            <hr />
                        </div>
                        <div class="map_progress col-xs-12 col-sm-12">
                            <table style="position: initial; top: 5px; right: 5px; font-size: smaller; color: #545454">
                                <tbody>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid rgb(240,32,61); overflow: hidden">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">&nbsp;0 - 2   Baja demanda</td>
                                    </tr>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid rgb(233,152,47); overflow: hidden">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">&nbsp;3 a 6 Demanda media</td>
                                    </tr>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid rgb(80,170,10); overflow: hidden">
                                                </div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">&nbsp;7 a 10 Demanda Alta</td>
                                    </tr>
                                </tbody>
                            </table>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12">
                                    <span class='text-muted'><small>Por cada servicio se tiene en cuenta para el cálculo  que cada 5 servicios solicitados es un punto.</small></span>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <br />
        <br />
        <br />
        <br />
    </div>

    <script>

        //llamada a la gráfica 1
        callservidor = function (valor) {
            var senddata = "{idServcio:\"" + valor + "\"}";
            $.ajax({
                type: "POST",
                url: 'ServicioGraficas.asmx/ObtenerGraficaDemandaSemanal',
                data: senddata,
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    var dataSet = jQuery.parseJSON(data.d);
                    var tabla1 = dataSet["Servicios"];
                    var tabla2 = dataSet["Etiquetas"];
                    var dataykeys = [];
                    var datalabels = [];
                    var Colores = [];

                    $.each(tabla2, function (i) {
                        dataykeys.push(this['idServicio']);
                        datalabels.push(this['Servicio']);
                        Colores.push(GetBaseColores2(i));
                    });


                    $('#morris_bar_graph').empty();
                    if ($("#morris_bar_graph").length) {
                        Morris.Bar({
                            barGap: 4,
                            barSizeRatio: 0.60,
                            element: 'morris_bar_graph',
                            data: tabla1,
                            resize: true,
                            redraw: true,
                            xkey: 'Dia',
                            ykeys: dataykeys,
                            labels: datalabels,
                            barColors: ['#673AB7', '#3F51B5', '#E91E63', '#79444E']
                        }).on('click', function (i, row) {
                            console.log(i, row);
                        });


                    };


                }

            });
        }

        //llamada a la gráfica 2
        callservidor2 = function (valor) {
            var senddata = "{opcion:\"" + valor + "\"}";
            $.ajax({
                type: "POST",
                url: 'ServicioGraficas.asmx/ObtenerGraficaIndicadorDeActividadPorEmpleado',
                data: senddata,
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    var dataSet = jQuery.parseJSON(data.d);
                    var tabla1 = dataSet["Empleado"];
                    var Colores = [];
                    for (var i = 0; i < tabla1.length - 1; i++) {
                        Colores.push(GetBaseColores(i));
                    }

                    Grafica2(tabla1, Colores);

                }

            });
        }



        //Gráfica 2
        Grafica2 = function (data, colores) {

            if ($("#flotpie").length) {

                var flotpie = $("#flotpie");

                flotpie.unbind();

                $.plot(flotpie, data, {
                    series: {
                        pie: {
                            show: true,
                            radius: 1,
                            label: {
                                show: true,
                                radius: 1,
                                formatter: labelFormatter,
                                background: {
                                    opacity: 0.8
                                }
                            }
                        }
                    },
                    colors: colores,
                    grid: {
                        hoverable: true,
                        clickable: true
                    },
                    legend: {
                        show: true
                    }
                });
            }

        }

        //llamada a la gráfica 3
        callservidor3 = function (valor) {
            var senddata = "{sede:\"" + valor + "\"}";
            $.ajax({
                type: "POST",
                url: 'ServicioGraficas.asmx/ObtenerGraficaIndicadorDeEficienciaDeRecurso',
                data: senddata,
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    var dataSet = jQuery.parseJSON(data.d);
                    var tabla1 = dataSet["Sede"];
                    Grafica3(tabla1);

                }

            });
        }
        //Gráfica 3
        Grafica3 = function (polarData) {
            var polargrafico = $("#polar-chartjs");

            if (polargrafico.length) {
                $('#polar-chartjs').remove();

                $('#contentpolar').append('<canvas id="polar-chartjs" width="300" height="300"><canvas>');

                var ctxp = document.getElementById("polar-chartjs").getContext("2d");
                window.myPolarArea = new Chart(ctxp).PolarArea(polarData, {
                    responsive: true
                });

            }
        }
        //Utiliarios

        function GetBaseColores(i) {
            var Colores = ["#3F51B5", "#673AB7", "#E91E63", "#FFC107", "#797979"];
            return Colores[i];
        }

        function GetBaseColores2(i) {
            var Colores = ['#555555', '#3F51B5', '#E91E63', '#79444E'];
            return Colores[i];
        }

        function labelFormatter(label, series) {
            return "<div style='font-size:8pt; text-align:center; padding:2px; color:white;'>" + label + "<br/>" + Math.round(series.percent) + "%</div>";
        }

        function GetColorAleatorio() {
            hexadecimal = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F")
            color_aleatorio = "#";
            for (i = 0; i < 6; i++) {
                posarray = aleatorio(0, hexadecimal.length)
                color_aleatorio += hexadecimal[posarray]
            }
            return color_aleatorio
        }

        function aleatorio(inferior, superior) {
            numPosibilidades = superior - inferior
            aleat = Math.random() * numPosibilidades
            aleat = Math.floor(aleat)
            return parseInt(inferior) + aleat
        }


        $(document).ready(function () {
            callservidor(0);
            callservidor2(0);
            callservidor3(1);


        });



        $('#<%=cboGrafico1.ClientID %>').change(function () {
            var valor1 = $('#<%=cboGrafico1.ClientID %> option:selected').val();
            callservidor(valor1);
        });
        $('#<%=cboGrafico2.ClientID %>').change(function () {
            var valor4 = $('#<%=cboGrafico2.ClientID %> option:selected').val();
            callservidor2(valor4);
        });
        $('#<%=filtroservicio.ClientID %>').change(function () {
            var valor3 = $('#<%=filtroservicio.ClientID %> option:selected').val();
            callservidor3(valor3);
        });

    </script>

</asp:Content>
