<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ActualizaKardexAtencion.aspx.cs" Inherits="Web.Petcenter.ActualizaKardexAtencion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- Ionicons -->


    <script>


        function AsignarValor() {
            var objO = document.getElementById("<%=btnBuscar.ClientID%>");
            objO.click();
        }
        function UpdateDatos() {

            var objO = document.getElementById("<%=btnBuscar.ClientID%>");
            objO.click();
        }

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
                    <h2 class="text-center">Atención de Requerimientos</h2>
                    <br>
                    <br>

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
                                                <div class="input-group-addon">Material:<font size="2" color="red"> </font></div>
                                                <asp:TextBox ID="txtMaterial" runat="server" class="form-control" placeholder="Material" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <div class="input-group-addon">Requerimiento:<font size="2" color="red"> </font></div>
                                                <asp:TextBox ID="txtReq" runat="server" class="form-control" placeholder="Número requerimiento" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>

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
                                            <h3 class="panel-title">Lista de Requerimientos</h3>
                                        </div>
                                        <div class="panel-body">


                                            <asp:GridView ID="grvresultado" runat="server" class="table table-bordered" Width="100%"
                                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                                OnPageIndexChanging="gvResultado_PageIndexChanging" DataKeyNames="idMovimiento">

                                                <Columns>
                                                    <asp:BoundField DataField="NUMREQ" HeaderText="NUM REQ">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MATERIAL" HeaderText="MATERIAL">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SOL" HeaderText="SOL">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="CANTIDAD">

                                                        <ItemTemplate>

                                                            <asp:TextBox ID="txtCantidad" Width="50px" runat="server" onblur="fn_formatDecimal(0)" type="number" min="0" Style="text-align: center" onkeypress="return PriceMask(this)" Text='<%# Eval("Cantidad") %>'></asp:TextBox>


                                                            <itemstyle width="15%" horizontalalign="Center" />
                                                        </ItemTemplate>

                                                        <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <PagerSettings Position="Top" />
                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                <RowStyle Font-Size="8pt" CssClass="td2" />
                                            </asp:GridView>


                                        </div>
                                    </div>

                                </section>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button runat="server" Text="Grabar" CssClass="btn btn-danger" ID="btnGrabar" Style="min-width: 100px" OnClick="btnGrabar_Click" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>


                </section>
                <br />
                <br />
            </div>
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


</asp:Content>
