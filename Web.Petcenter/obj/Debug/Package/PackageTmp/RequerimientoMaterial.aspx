<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RequerimientoMaterial.aspx.cs" Inherits="Web.Petcenter.RequerimientoMaterial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <script>


        function AsignarValor() {
            var objO = document.getElementById("<%=btnBuscar.ClientID%>");
            objO.click();
        }
        function UpdateDatos() {
            var objO = document.getElementById("<%=btnBuscar.ClientID%>");

        objO.click();
    }
    function ValidarFecha(obj) {
        var fechaIni = document.getElementById("<%= txtfechaIni.ClientID %>").value;
        var fechaFin = document.getElementById("<%= txtFechaFinal.ClientID %>").value;
        if (validate_fechaMayorQue(fechaIni, fechaFin) == 0) {
            $("#myModalFec").modal();

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
        td {
            cursor: pointer;
        }

        .hover_row {
            background-color: #AFC9D6;
        }
    </style>

    <div class="col-xs-12">
        <div class="box">
            <div class="contenido-ficha">
                <section>
                    <h2 class="text-center">Requerimiento de Materiales</h2>
                    <br>
                    <br>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Registro:<font size="2" color="red"> </font></div>
                                    <asp:TextBox ID="txtfechaIni" runat="server" class="form-control datepicker" placeholder="Fecha Inicial" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">al:<font size="2" color="red"> </font></div>
                                    <asp:TextBox ID="txtFechaFinal" runat="server" class="form-control datepicker" placeholder="Fecha Final" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-6">
                            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-danger" ID="btnBuscar" Style="min-width: 100px" OnClick="btnBuscar_Click" />
                        </div>
                    </div>

                </section>
                <br />
                <br />

                <section>
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de Asignaciones del día</h3>
                        </div>
                        <div class="panel-body">


                            <asp:GridView ID="grvresultado" runat="server" class="table table-bordered" Width="100%"
                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                OnRowCommand="grvresultado_RowCommand" OnRowDataBound="grvresultado_RowDataBound" OnSelectedIndexChanged="grvresultado_OnSelectedIndexChanged" OnPageIndexChanging="gvResultado_PageIndexChanging" DataKeyNames="idHojaServicio,horaCita,fechaCita">

                                <Columns>
                                    <asp:BoundField DataField="fechaCita" HeaderText="FECHA">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="horaCita" HeaderText="HORA">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NroCita" HeaderText="CÓDIGO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cliente" HeaderText="CLIENTE">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombreMascota" HeaderText="MASCOTA">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="especieMascota" HeaderText="ESPECIE">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="generoMascota" HeaderText="GÉNERO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="razaMascota" HeaderText="RAZA">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tamanioMascota" HeaderText="TAMAÑO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="canilMascota" HeaderText="CANIL">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EstadoCita" HeaderText="ESTADO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ACCIÓN">
                                        <ItemTemplate>
                                            <asp:Button ID="ibtnEjecutar" runat="server" AlternateText="Ejecutar" CausesValidation="false" Visible='<%# Eval("Ejecutar") %>'
                                                CommandArgument='<%# Bind("idHojaServicio") %>' CommandName="Ejecutar" Text="Ejecutar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                            <asp:Button ID="ibtnFinalizar" runat="server" AlternateText="Finalizar" CausesValidation="false" Visible='<%# Eval("Finalizar") %>'
                                                CommandArgument='<%# Bind("idHojaServicio") %>' CommandName="Finalizar" Text="Finalizar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                            <itemstyle width="5%" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                </Columns>
                                <PagerSettings Position="Top" />
                                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                <RowStyle Font-Size="8pt" />
                            </asp:GridView>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                                    <label for="nuevo" class="col-md-2  control-label"></label>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="#993333"></asp:Label>
                                    <hr />
                                </div>
                            </div>


                        </div>
                    </div>
           
            </section>
                <br>
            <br>
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
                                <div class="col-sm-2">
                                    <asp:Image ID="imgMascota" runat="server" Width="150px" />

                                </div>
                                <div class="col-sm-10">

                                    <div class="modal-content">

                                        <div class="modal-body">

                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Nombre:</div>
                                                            <asp:TextBox ID="txtNombreMascota" runat="server" ReadOnly="true" class="form-control" placeholder="Codigo" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Estado:</div>
                                                            <asp:TextBox ID="txtEstado" runat="server" ReadOnly="true" class="form-control" placeholder="Servicio" Style="width: 100%; font-weight: 200"></asp:TextBox>


                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3" style="display: none">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtServicio" runat="server" ReadOnly="true" class="form-control" placeholder="Servicio" Style="width: 100%; font-weight: 200"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Especie:</div>
                                                            <asp:TextBox ID="txtEspecieMascota" runat="server" ReadOnly="true" class="form-control" placeholder="Codigo" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Raza:</div>
                                                            <asp:TextBox ID="txtRazaMascota" runat="server" ReadOnly="true" class="form-control" placeholder="Codigo" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Alertas:</div>
                                                            <asp:TextBox ID="txtAlertas" runat="server" ReadOnly="true" class="form-control" Style="width: 100%" TextMode="MultiLine" Rows="2"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="container" style="width: 820px">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a data-toggle="tab" href="#Comentarios">Comentarios</a></li>
                                        <li><a data-toggle="tab" href="#Materiales">Materiales</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        <div id="Comentarios" class="tab-pane fade in active">

                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="txtComent" runat="server" TextMode="MultiLine" Width="800px" Rows="2" Height="50px" class="form-control" placeholder="Ingrese Comentario"></asp:TextBox>
                                                    <asp:Button ID="btnSend" Visible="false" runat="server" Text="Enviar" Width="100px" CssClass="btn btn-default" OnClick="btnSend_Click" />

                                                </div>
                                            </div>
                                            <div class="row" style="height: 130px; width: 820px; overflow: auto">
                                                <div class="col-sm-12">
                                                    <asp:GridView ID="gvComents" runat="server" class="table table-bordered" Width="700px" Height="150px"
                                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false" ShowHeaderWhenEmpty="false" ShowHeader="false" PageSize="3">

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ACCION">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUser" Width="100%" runat="server" Text='<%# Eval("UserComent") %>'></asp:Label>

                                                                    <asp:Label ID="lblComment" Width="700px" runat="server" Text='<%# Eval("Coment") %>'></asp:Label>

                                                                    <itemstyle width="5%" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle Font-Size="8pt" HorizontalAlign="Left" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="Materiales" class="tab-pane fade">
                                            <div style="height: 180px; width: 820px; overflow: auto">
                                                <asp:GridView ID="gvMateriales" runat="server" class="table table-bordered" Width="400px" Height="100px"
                                                    AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false" ShowHeaderWhenEmpty="false" ShowHeader="true" PageSize="3"
                                                    DataKeyNames="IdMaterial,idUnidadMedida">

                                                    <Columns>

                                                        <asp:BoundField DataField="material" HeaderText="MATERIAL">
                                                            <ItemStyle VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="CANTIDAD">

                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txtCantidad" Width="50px" runat="server" onblur="fn_formatDecimal(0)" type="number" min="0" Style="text-align: center" onkeypress="return PriceMask(this)" Visible='<%# Eval("HasNumber") %>' Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                                                <asp:CheckBox ID="chkCantidad" Width="50px" runat="server" Style="text-align: center" Checked='<%# Eval("CantidadBit") %>' Visible='<%# Eval("HasBit") %>'></asp:CheckBox>



                                                                <itemstyle width="5%" />
                                                            </ItemTemplate>

                                                            <ItemStyle BorderStyle="Solid" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle Font-Size="8pt" />
                                                </asp:GridView>
                                            </div>

                                        </div>
                                        <div id="Tracking" class="tab-pane fade">
                                            <div style="height: 180px; width: 820px; overflow: scroll">
                                                <asp:GridView ID="gvTracking" runat="server" class="table table-bordered" Width="400px" Height="100px"
                                                    AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="false" ShowHeader="true">

                                                    <Columns>

                                                        <asp:BoundField DataField="Fecha" HeaderText="FECHA">
                                                            <ItemStyle VerticalAlign="Middle" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Estado" HeaderText="ESTADO">
                                                            <ItemStyle VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle Font-Size="8pt" />
                                                </asp:GridView>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>


                        </div>
                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:HiddenField runat="server" ID="idTipo" />
                            <asp:HiddenField runat="server" ID="idHojaServicio" />

                            <asp:Button runat="server" Text="Ejecutar" CssClass="btn btn-default" ID="btnEjecutar" Style="width: 30%" OnClick="btnEjecutar_Click" />
                            <asp:Button runat="server" Text="Guardar" CssClass="btn btn-default" ID="btnGuardarP" Style="width: 30%" OnClick="btnGuardarP_Click" />
                            <asp:Button runat="server" Text="Cancelar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnCancelarP" Style="width: 30%" />

                        </div>
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
                            <asp:Button runat="server" Text="Aceptar" CssClass="btn btn-danger" ID="btnAceptar" Style="width: 30%" OnClick="btnAceptar_Click" />

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

    <%--Confirmacion--%>
    <div class="modal fade" id="myModalConfirmacion" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalConfirmacion" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

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

                            <button class="btn btn-danger" data-dismiss="modal" style="width: 30%" aria-hidden="true">NO</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
