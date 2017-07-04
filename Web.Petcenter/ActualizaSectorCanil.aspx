<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ActualizaSectorCanil.aspx.cs" Inherits="Web.Petcenter.ActualizaSectorCanil" %>

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
        function exportar() {
            var fechaIni = document.getElementById("<%= txtfechaIni.ClientID %>").value;
            var fechaFin = document.getElementById("<%= txtFechaFinal.ClientID %>").value;
            var cboRecurso = document.getElementById("<%= cboRecurso.ClientID %>").value;
            var cboEstado = document.getElementById("<%= cboEstado.ClientID %>").value;
        
           document.getElementById("frmExportar").src = "ExportarSectorCanil.aspx?txtfechaIni=" + fechaIni + "&txtFechaFinal=" + fechaFin + "&cboRecurso=" + cboRecurso + "&cboEstado=" + cboEstado;
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
    <div class="col-xs-12">
        <div class="box">
            <div class="contenido-ficha">
                <section>
                    <h2 class="text-center">Administrar canil y sector de trabajo</h2>
                    <br>
                    <br>
                    <div class="row">
                        <div class="col-md-6">
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Fin:<font size="2" color="red"> </font></div>
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
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Recurso:</div>
                                    <asp:DropDownList ID="cboRecurso" runat="server" class="form-control">
                                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6" >
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
                        <div class="col-md-3">
                            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-danger" ID="btnBuscar" Style="min-width: 100px" OnClick="btnBuscar_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button runat="server" Text="Nuevo Canil" CssClass="btn btn-danger" ID="btnNuevo" Style="min-width: 100px" OnClick="btnNuevo_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button runat="server" Text="Exportar" CssClass="btn btn-danger" ID="btnExportar" Style="min-width: 100px" OnClientClick="javascript:exportar()" />
                          
                        </div>
                    </div>

                </section>
                <br />
                <br />

                <section>
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de canil o sector de trabajo</h3>
                        </div>
                        <div class="panel-body" id="divCanil" runat="server">


                            <asp:GridView ID="grvresultado" runat="server" class="table table-bordered" Width="100%"
                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                OnRowCommand="grvresultado_RowCommand"  OnPageIndexChanging="gvResultado_PageIndexChanging" 
                                 OnRowDataBound="grvresultado_RowDataBound" OnSelectedIndexChanged="grvresultado_OnSelectedIndexChanged" 
                               DataKeyNames="idCanil">

                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="CODIGO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tamanio" HeaderText="TAMAÑO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="estado" HeaderText="ESTADO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="especie" HeaderText="ESPECIE">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="observaciones" HeaderText="OBSERVACIONES">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                  
                                    <asp:TemplateField HeaderText="ACCIÓN">
                                        <ItemTemplate>
                                            <asp:Button ID="ibtnModificar" runat="server" AlternateText="Editar" CausesValidation="false" Visible='<%# Eval("Editar") %>'
                                                CommandArgument='<%# Bind("idCanil") %>' CommandName="Editar" Text="Editar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                            <asp:Button ID="ibtnEliminar" runat="server" AlternateText="Eliminar" CausesValidation="false" Visible='<%# Eval("Eliminar") %>'
                                                CommandArgument='<%# Bind("idCanil") %>' CommandName="Eliminar" Text="Eliminar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                            <itemstyle width="5%" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                </Columns>
                                <PagerSettings Position="Top" />
                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                <RowStyle Font-Size="8pt" CssClass="td1" />
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
                        <div class="panel-body"  id="divSector" runat="server">


                            <asp:GridView ID="grvresultado2" runat="server" class="table table-bordered" Width="100%"
                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                OnRowCommand="grvresultado2_RowCommand" OnPageIndexChanging="gvResultado2_PageIndexChanging" 
                                 OnRowDataBound="grvresultado2_RowDataBound" OnSelectedIndexChanged="grvresultado2_OnSelectedIndexChanged" 
                                DataKeyNames="idSector">

                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="CODIGO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="servicio" HeaderText="SERVICIO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="estado" HeaderText="ESTADO">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="observaciones" HeaderText="OBSERVACIONES">
                                        <ItemStyle VerticalAlign="Middle" />
                                    </asp:BoundField>
                                  
                                    <asp:TemplateField HeaderText="ACCIÓN">
                                        <ItemTemplate>
                                            <asp:Button ID="ibtnModificar" runat="server" AlternateText="Editar" CausesValidation="false" Visible='<%# Eval("Editar") %>'
                                                CommandArgument='<%# Bind("idSector") %>' CommandName="Editar" Text="Editar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                            <asp:Button ID="ibtnEliminar" runat="server" AlternateText="Eliminar" CausesValidation="false" Visible='<%# Eval("Eliminar") %>'
                                                CommandArgument='<%# Bind("idSector") %>' CommandName="Eliminar" Text="Eliminar" CssClass="btn btn-default" Style="min-width: 70px" Font-Size="X-Small" />

                                            <itemstyle width="5%" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                </Columns>
                                <PagerSettings Position="Top" />
                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                <RowStyle Font-Size="8pt" CssClass="td1" />
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
                <br>
                <br>
            </div>
        </div>
    </div>



    <%--PROGRAMAR/MODIFICAR CANIL--%>
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

                                            
                                            <div class="row" runat="server" id="divCodigoCanil">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Codigo:</div>
                                                            <asp:TextBox ID="txtCodigoCanil" runat="server" ReadOnly="true" class="form-control" placeholder="Nombre" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Nombre:</div>
                                                            <asp:TextBox ID="txtNombreCanil" runat="server" ReadOnly="true" class="form-control" placeholder="Nombre" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Tamaño:</div>
                                                            
                                                        <asp:DropDownList ID="cboTamanioCanil" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                </div>
                                                 <div class="row">
                                                <div class="col-sm-6" >
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Especie:</div>
                                                        <asp:DropDownList ID="cboEspecieCanil" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Estado:</div>
                                                        <asp:DropDownList ID="cboEstadoCanil" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Observaciones:</div>
                                                            <asp:TextBox ID="txtObservacionesCanil" runat="server" class="form-control" Style="width: 100%" TextMode="MultiLine" Rows="2"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                       
                                </div>
                            </div>

                        </div>
                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:HiddenField runat="server" ID="idCanil" />

                           <asp:Button runat="server" Text="Guardar" CssClass="btn btn-default" ID="btnGuardarCanil" Style="width: 30%" OnClick="btnGuardarCanil_Click" />
                            <asp:Button runat="server" Text="Cancelar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnCancelarCanil" Style="width: 30%" />

                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>


    
    <%--PROGRAMAR/MODIFICAR SECTOR--%>
    <div class="modal fade" id="myModalS" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <asp:UpdatePanel ID="upModalS" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalSTitle" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblModalSTitle2" Font-Size="Large" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>


                            <div class="row">
                                <div class="col-sm-12">

                                            
                                            <div class="row" runat="server" id="divCodigoSector">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Codigo:</div>
                                                            <asp:TextBox ID="txtCodigoSector" runat="server" ReadOnly="true" class="form-control" placeholder="Nombre" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Nombre:</div>
                                                            <asp:TextBox ID="txtNombreSector" runat="server" ReadOnly="true" class="form-control" placeholder="Nombre" Style="width: 100%"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Servicio:</div>
                                                            
                                                        <asp:DropDownList ID="cboServicioSector" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div> 
						                        <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Estado:</div>
                                                        <asp:DropDownList ID="cboEstadoSector" runat="server" class="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">Observaciones:</div>
                                                            <asp:TextBox ID="txtObservacionesSector" runat="server" class="form-control" Style="width: 100%" TextMode="MultiLine" Rows="2"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                </div>
                            </div>

                        </div>
                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:HiddenField runat="server" ID="idSector" />

                           <asp:Button runat="server" Text="Guardar" CssClass="btn btn-default" ID="btnGuardarSector" Style="width: 30%" OnClick="btnGuardarSector_Click" />
                            <asp:Button runat="server" Text="Cancelar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnCancelarSector" Style="width: 30%" />

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
                    
                    <asp:HiddenField runat="server" ID="idTipo" />
                            <asp:HiddenField runat="server" ID="id" />

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
