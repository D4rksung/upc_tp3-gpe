<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ActualizaKardex.aspx.cs" Inherits="Web.Petcenter.ActualizaKardex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- Ionicons -->


    <script>


        function AsignarValor() {
            var objO = document.getElementById("<%=btnBuscar.ClientID%>");
            objO.click();
            var obj2 = document.getElementById("<%=btnBuscar2.ClientID%>");
            obj2.click();
        }
        function UpdateDatos() {

            var objO = document.getElementById("<%=btnBuscar.ClientID%>");
            objO.click();
            var obj2 = document.getElementById("<%=btnBuscar2.ClientID%>");
            obj2.click();
        }
        function ValidarFecha(obj) {
            var fechaIni = document.getElementById("<%= txtfechaIni.ClientID %>").value;
            var fechaFin = document.getElementById("<%= txtFechaFinal.ClientID %>").value;
            if (validate_fechaMayorQue(fechaIni, fechaFin) == 0) {
                $("#myModalFec").modal();

                obj.value = "";
            }
        }

        function ValidarFechaActual(obj) {
            var f = new Date();
            var fechaIni = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
            var fechaFin = document.getElementById("<%= txtFechaReq.ClientID %>").value;
            if (validate_fechaMayorQue(fechaIni, fechaFin) == 0) {
                $("#myModalFecActual").modal();

                obj.value = "";
            }
        }
        function validate_fechaMayorQue(fechaInicial, fechaFinal) {
            valuesStart = fechaInicial.split("/");
            valuesEnd = fechaFinal.split("/");
            // Verificamos que la fecha no sea posterior a la actual
            var dateStart = new Date(valuesStart[2], (valuesStart[1] - 1), valuesStart[0]);
            var dateEnd = new Date(valuesEnd[2], (valuesEnd[1] - 1), valuesEnd[0]);
            if (dateStart > dateEnd) {
                return 0;
            }
            return 1;
        }
<%--    $(function () {
        $("#<%= txtfechaIni.ClientID%>").datepicker({
                format: "dd/mm/yyyy",
                daysOfWeekHighlighted: "0,6"
            });

            $("#<%= txtFechaFinal.ClientID%>").datepicker({
                format: "dd/mm/yyyy",
                daysOfWeekHighlighted: "0,6"
            });
        });--%>

        function PriceMask(toField) {
            if (window.event.keyCode != 13) {
                var llRetVal = false;
                if ((window.event.keyCode >= 48 && window.event.keyCode <= 57))
                { llRetVal = true; }
                return llRetVal;
            }
            else {
                return false;
            }

        }

        function fn_formatDecimal(nDecimal) {
            fn_formatNumberDecimal(nDecimal, true, true, true, true, true);
        }

        function fn_formatNumberDecimal(DecimalNum, LeadingZero, Parens, Commas, DefaultValue, PreserveValue) {
            var element = event.srcElement;
            var tmpValue = element.value;

            if (tmpValue != '') {

                if (tmpValue == "" && DefaultValue) tmpValue = "0";
                if (tmpValue == "") return true;

                tmpValue = tmpValue.toString().replace(/\$|\,./g, '');
                tmpValue = formatNumber(tmpValue, DecimalNum, LeadingZero, Parens, Commas);

                if (tmpValue == "NaN") {
                    ObjectError = element;
                    alert("El valor ingresado no es válido. Sólo acepta números.");
                    element.focus();
                    return false;
                } else {
                    if (typeof (PreserveValue) != "undefined" || PreserveValue == false) element.value = tmpValue;
                    return true;
                }
            }
        }

        function formatNumber(num, decimalNum, bolLeadingZero, bolParens, bolCommas) {
            if (isNaN(parseInt(num))) return "NaN";

            var tmpNum = num;
            var iSign = num < 0 ? -1 : 1;		// Get sign of number

            // Adjust number so only the specified number of numbers after
            // the decimal point are shown.
            tmpNum *= Math.pow(10, decimalNum);
            tmpNum = Math.round(Math.abs(tmpNum))
            tmpNum /= Math.pow(10, decimalNum);
            tmpNum *= iSign;					// Readjust for sign

            if (isNaN(parseInt(tmpNum))) return "NaN";

            // Create a string object to do our formatting on
            var tmpNumStr = new String(tmpNum);

            // See if we need to strip out the leading zero or not.
            if (!bolLeadingZero && num < 1 && num > -1 && num != 0) {

                if (num > 0) {

                    tmpNumStr = tmpNumStr.substring(0, tmpNumStr.length);
                } else {
                    tmpNumStr = "-" + tmpNumStr.substring(2, tmpNumStr.length);
                }
            }
            // See if we need to put in the commas

            if (bolCommas && (num >= 1000 || num <= -1000)) {
                var iStart = tmpNumStr.indexOf(".");
                if (iStart < 0)
                    iStart = tmpNumStr.length;

                iStart -= 3;
                while (iStart >= 1) {
                    tmpNumStr = tmpNumStr.substring(0, iStart) + "" + tmpNumStr.substring(iStart, tmpNumStr.length)
                    iStart -= 3;
                }
            }

            if (decimalNum > 0) {
                var pos = tmpNumStr.indexOf(".");
                var zeros = ".";
                var decimalpart = "";

                if (pos > 0) {
                    decimalpart = tmpNumStr.substr(pos + 1, tmpNumStr.length);

                    zeros = "";
                }
                for (var i = decimalpart.length; i < decimalNum; i++) zeros += "0";

                tmpNumStr += zeros;
            }

            // See if we need to use parenthesis
            if (bolParens && num < 0)
                tmpNumStr = "(" + tmpNumStr.substring(1, tmpNumStr.length) + ")";

            return tmpNumStr;		// Return our formatted string!
        }
    </script>
    <style type="text/css">
        .hover_row {
            background-color: #AFC9D6;
        }

        .td1 {
            cursor: default;
        }

        .td2 {
            cursor: pointer;
        }
    </style>

    <asp:HiddenField ID="hfMaterialID" runat="server" />
    <div class="col-md-12">
        <div class="box">
            <div class="contenido-ficha">
                <section>
                    <h2 class="text-center">Requerimiento de materiales</h2>
                    <br>
                    <br>
                    <div class="container" style="width: 100%">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#Movimientos">Requerimientos</a></li>
                            <li><a data-toggle="tab" href="#MaterialesG">Materiales</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="Movimientos" class="tab-pane fade in active">

                                <br>

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>



                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Sede:</div>
                                                        <asp:DropDownList ID="cboAlmacen" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Motivo:</div>
                                                        <asp:DropDownList ID="cboMotivo" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Tipo:</div>
                                                        <asp:DropDownList ID="cboTipo" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Fecha Inicio:<font size="2" color="red"> </font></div>
                                                        <asp:TextBox ID="txtfechaIni" runat="server" class="form-control datepicker" placeholder="Fecha Inicial" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
                                                        <span class="input-group-addon">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Fecha Fin :<font size="2" color="red"> </font></div>
                                                        <asp:TextBox ID="txtFechaFinal" runat="server" class="form-control datepicker" placeholder="Fecha Final" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
                                                        <span class="input-group-addon">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Estado:</div>
                                                        <asp:DropDownList ID="cboEstado" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Num req:<font size="2" color="red"> </font></div>
                                                        <asp:TextBox ID="txtNumReq" runat="server" class="form-control" placeholder="Número requerimiento" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-danger" ID="btnBuscar" Style="min-width: 100px" OnClick="btnBuscar_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <section>
                                            <div class="panel panel-danger">
                                                <div class="panel-heading">
                                                    <h3 class="panel-title">Lista de Movimientos</h3>
                                                </div>
                                                <div class="panel-body">


                                                    <asp:GridView ID="grvresultado" runat="server" class="table table-bordered" Width="100%"
                                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                                        OnRowCommand="grvresultado_RowCommand" OnPageIndexChanging="gvResultado_PageIndexChanging" DataKeyNames="idMovimiento">

                                                        <Columns>
                                                            <asp:BoundField DataField="NUMREQ" HeaderText="NUM REQ">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TIPO" HeaderText="TIPO">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="ACCIÓN">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="ibtnModificar" runat="server" AlternateText="Modificar" CausesValidation="false" Visible='<%# Eval("Modificar") %>'
                                                                        CommandArgument='<%# Bind("idMovimiento") %>' CommandName="Modificar" Text="Modificar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                                                    <asp:Button ID="ibtnAnular" runat="server" AlternateText="Anular" CausesValidation="false" Visible='<%# Eval("Anular") %>'
                                                                        CommandArgument='<%# Bind("idMovimiento") %>' CommandName="Anular" Text="Anular" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                                                    <itemstyle width="5%" />
                                                                    <asp:Button ID="Button1" runat="server" AlternateText="Cerrar" CausesValidation="false" Visible='<%# Eval("Cerrar") %>'
                                                                        CommandArgument='<%# Bind("idMovimiento") %>' CommandName="Cerrar" Text="Cerrar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                                                    <itemstyle width="5%" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>


                                                        </Columns>
                                                        <PagerSettings Position="Top" />
                                                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                        <RowStyle Font-Size="8pt" CssClass="td1" />
                                                    </asp:GridView>


                                                </div>
                                            </div>

                                        </section>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Button runat="server" Text="Agregar" CssClass="btn btn-danger" ID="btnNuevo" Style="min-width: 100px" OnClick="btnNuevo_Click" />
                                            </div>

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                            <div id="MaterialesG" class="tab-pane fade ">

                                <br>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Mov. hasta:<font size="2" color="red"> </font></div>
                                                        <asp:TextBox ID="txtFechaMovHasta" runat="server" class="form-control datepicker" placeholder="Mov Hasta" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
                                                        <span class="input-group-addon">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Sede:</div>

                                                        <asp:DropDownList ID="cboAlmacenV" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-danger" ID="btnBuscar2" Style="min-width: 100px" OnClick="btnBuscar2_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <section>
                                            <div class="panel panel-danger">
                                                <div class="panel-heading">
                                                    <h3 class="panel-title">Lista de Materiales</h3>
                                                </div>
                                                <div class="panel-body">


                                                    <asp:GridView ID="grvresultado2" runat="server" class="table table-bordered" Width="100%"
                                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                                        OnRowDataBound="grvresultado2_RowDataBound" OnSelectedIndexChanged="grvresultado2_OnSelectedIndexChanged" OnPageIndexChanging="gvResultado2_PageIndexChanging" DataKeyNames="idMaterial">

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <i class="fa fa-circle" aria-hidden="true" style="color: <%# Eval("Color") %>"></i>
                                                                    <itemstyle width="5%" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="MATERIAL" HeaderText="MATERIAL">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="UNIDAD MEDIDA">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="STOCKMINIMO" HeaderText="STOCK MINIMO">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="STOCKMAXIMO" HeaderText="STOCK MAXIMO">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="STOCKACTUAL" HeaderText="STOCK ACTUAL">
                                                                <ItemStyle VerticalAlign="Middle" />
                                                            </asp:BoundField>



                                                        </Columns>
                                                        <PagerSettings Position="Top" />
                                                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                        <RowStyle Font-Size="8pt" CssClass="td2" />
                                                    </asp:GridView>
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                                            <label for="nuevo" class="col-md-2  control-label"></label>
                                                            <asp:Label ID="Label3" runat="server" ForeColor="#993333"></asp:Label>
                                                            <hr />
                                                        </div>
                                                    </div>


                                                </div>
                                            </div>

                                        </section>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                    </div>

                    <br />

                </section>
                <br />
                <br />
            </div>
        </div>
    </div>



    <%--PROGRAMAR/MODIFICAR--%>
    <div class="modal fade" id="myModalP" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <asp:UpdatePanel ID="upModalP" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalPTitle" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblModalPTitle2" Font-Size="Large" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>


                            <div class="row">
                                <div class="col-sm-12">



                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">Nro Requerimiento:<font size="2" color="red"> </font></div>
                                                    <asp:TextBox ID="txtNroReq" runat="server" ReadOnly="true" class="form-control" placeholder="" Style="width: 100%"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">Sede:<font size="2" color="red"> </font></div>
                                                    <asp:TextBox ID="txtSede" runat="server" ReadOnly="true" class="form-control" placeholder="" Style="width: 100%"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">Fecha Req:<font size="2" color="red"> </font></div>
                                                    <asp:TextBox ID="txtFechaReq" runat="server" class="form-control datepicker" placeholder="Fecha Req" onBlur="javascript:ValidarFechaActual(this)"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">Tipo :</div>

                                                    <asp:DropDownList ID="cboTipoReq" runat="server" class="form-control">
                                                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">Motivo :</div>

                                                    <asp:DropDownList ID="cboMotivoReq" runat="server" class="form-control">
                                                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>

                            <br />
                            <br />

                            <hr />
                            <div class="row">
                                <section>
                                    <div class="col-sm-12">


                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">Buscar Material :</div>

                                                        <asp:DropDownList ID="combobox" Width="100%" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="combobox_SelectedIndexChanged"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div style="height: 180px; width: 100%; overflow: auto" class="col-md-12">
                                                <asp:GridView ID="gvMateriales" runat="server" class="table table-bordered" Width="100%" Height="100px"
                                                    AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="false" ShowHeader="true" PageSize="3"
                                                    DataKeyNames="IdMaterial" FooterStyle-VerticalAlign="Top">

                                                    <Columns>


                                                        <asp:TemplateField HeaderText="MATERIAL">

                                                            <ItemTemplate>

                                                                <asp:Label ID="lblMaterial" runat="server" Text='<%# Eval("material") %>'></asp:Label>


                                                                <itemstyle width="25%" />
                                                            </ItemTemplate>

                                                            <ItemStyle BorderStyle="Solid" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCION">
                                                            <ItemStyle VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="umedida" HeaderText="MEDIDA">
                                                            <ItemStyle VerticalAlign="Middle" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="CANTIDAD">

                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txtCantidad" Width="50px" runat="server" onblur="fn_formatDecimal(0)" type="number" min="0"  Style="text-align: center" onkeypress="return PriceMask(this)" Text='<%# Eval("Cantidad") %>'></asp:TextBox>


                                                                <itemstyle width="15%" />
                                                            </ItemTemplate>

                                                            <ItemStyle BorderStyle="Solid" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle Font-Size="8pt" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>
                                </section>


                            </div>


                            <%--fin de contenido--%>

                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="idMovimiento" />
                                <asp:HiddenField runat="server" ID="idMaterial" />
                                <asp:HiddenField runat="server" ID="idAlmacen" />

                                <asp:Button runat="server" Text="Grabar" CssClass="btn btn-default" ID="btnGuardarP" Style="width: 30%" OnClick="btnGuardarP_Click" />
                                <asp:Button runat="server" Text="Cancelar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnCancelarP" Style="width: 30%" />

                            </div>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>




    <%--VIEW--%>
    <div class="modal fade" id="myModalV" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <asp:UpdatePanel ID="upModalV" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalPTitleV" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblModalPTitleV2" Font-Size="Large" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>

                            <div class="row">
                                <div style="height: 180px; width: 100%; overflow: auto">
                                    <asp:GridView ID="gvMaterialesV" runat="server" class="table table-bordered" Width="100%" Height="100px"
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false" ShowHeaderWhenEmpty="false" ShowHeader="true" PageSize="10"
                                        OnPageIndexChanging="gvMaterialesV_PageIndexChanging" DataKeyNames="IdMaterial">

                                        <Columns>

                                            <asp:BoundField DataField="tipoMovimiento" HeaderText="TIPO MOVIMIENTO">
                                                <ItemStyle VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="material" HeaderText="MATERIAL">
                                                <ItemStyle VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fechaMovimiento" HeaderText="FECHA MOVIMIENTO">
                                                <ItemStyle VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD">
                                                <ItemStyle VerticalAlign="Middle" />
                                            </asp:BoundField>

                                        </Columns>
                                        <RowStyle Font-Size="8pt" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </div>

                        <div class="modal-footer">
                            <asp:Button runat="server" Text="Cerrar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnCancelarV" Style="width: 30%" />

                        </div>

                    </div>
                    <%--fin de contenido--%>

                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

    <%--VALIDACION--%>
    <div class="modal fade" id="myModalVal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalVal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalValTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">

                            <asp:Label ID="lblVal" runat="server" Font-Size="14px" ForeColor="Red"></asp:Label>
                        </div>

                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>


    <%--MENSAJES--%>
    <div class="modal fade" id="myModalMensaje" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalMensaje" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblMensajeTitulo" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">

                            <asp:Label ID="lblMensaje" runat="server" Font-Size="14px" ForeColor="Red"></asp:Label>
                        </div>

                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:Button runat="server" Text="Aceptar" CssClass="btn btn-default" ID="btnAceptar" Style="width: 30%" OnClick="btnAceptar_Click" />

                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
    <%--FECHA--%>
    <div class="modal fade" id="myModalFec" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalFec" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="Mensaje del Sistema"></asp:Label></h4>
                        </div>
                        <div class="modal-body">

                            <asp:Label ID="Label2" runat="server" Font-Size="14px" ForeColor="Red" Text="Ocurrió un error en el sistema: La fecha fin debe de ser mayor a la fecha inicio."></asp:Label>
                        </div>

                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>


    <div class="modal fade" id="myModalFecActual" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalFecActual" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="Label4" runat="server" Text="Mensaje del Sistema"></asp:Label></h4>
                        </div>
                        <div class="modal-body">

                            <asp:Label ID="Label5" runat="server" Font-Size="14px" ForeColor="Red" Text="La Fecha del requerimiento no puede ser menor a hoy"></asp:Label>
                        </div>

                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

    <%--Confirmacion--%>
    <div class="modal fade" id="myModalConfirmacion" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalConfirmacion" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="idTipo" />
                    <asp:HiddenField runat="server" ID="idMovimientoT" />
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblConfirmacionTitulo" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">

                            <asp:Label ID="lblConfirmacion" runat="server" Font-Size="14px" ForeColor="Red"></asp:Label>
                        </div>

                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:Button runat="server" Text="SI" CssClass="btn btn-default" ID="btnSi" Style="width: 30%" OnClick="btnsi_Click" />

                            <button class="btn btn-info" data-dismiss="modal" style="width: 30%" aria-hidden="true">NO</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
