<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ActualizaProgramacion.aspx.cs" Inherits="Web.Petcenter.ActualizaProgramacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
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
            var fechaIni = document.getElementById("<%= txtfechaInicio.ClientID %>").value;
            var fechaFin = document.getElementById("<%= txtFechaFin.ClientID %>").value;
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
       <%-- $(function () {
            $("#<%= txtfechaInicio.ClientID%>").datepicker({
                format: "dd/mm/yyyy",
                daysOfWeekHighlighted: "0,6"
            });

            $("#<%= txtFechaFin.ClientID%>").datepicker({
                format: "dd/mm/yyyy",
                daysOfWeekHighlighted: "0,6"
            });
        });
        --%>

    </script>
    <style type="text/css">
        .td1 {
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
                    <h2 class="text-center">Realizar programación de atención de servicios</h2>
                    <br>
                    <br>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Inicio:<font size="2" color="red"> </font></div>
                                    <asp:TextBox ID="txtfechaInicio" runat="server" class="form-control datepicker" placeholder="Fecha Inicial" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
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
                                    <asp:TextBox ID="txtFechaFin" runat="server" class="form-control datepicker" placeholder="Fecha Final" onBlur="javascript:ValidarFecha(this)"></asp:TextBox>
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
                                    <div class="input-group-addon">Estado:</div>
                                    <asp:DropDownList ID="cboEstado" runat="server" class="form-control">
                                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                                    </asp:DropDownList>

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
                            <h3 class="panel-title">Lista de citas</h3>
                        </div>
                        <div class="panel-body">
                            <div id="table-responsive" class="table-responsive">
                                <asp:GridView ID="grvresultado" runat="server" class="table table-bordered" Width="100%" OnPageIndexChanging="gvResultado_PageIndexChanging"
                                    AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                    OnRowDataBound="grvresultado_RowDataBound" OnSelectedIndexChanged="grvresultado_OnSelectedIndexChanged" DataKeyNames="idCita,DescripcionCita">

                                    <Columns>
                                        <asp:TemplateField HeaderText="COMÚN">
                                            <ItemTemplate>

                                                <asp:CheckBox ID="chkAsignacion" runat="server" OnCheckedChanged="chkAsignacion_CheckedChanged" AutoPostBack="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ControlStyle BackColor="#CCCCCC" />
                                        </asp:TemplateField>
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
                                        <asp:BoundField HeaderText="ESPECIE" DataField="especieMascota">
                                            <ItemStyle VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="GÉNERO" DataField="generoMascota">
                                            <ItemStyle VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="RAZA" DataField="razaMascota">
                                            <ItemStyle VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="TAMAÑO" DataField="tamanioMascota">
                                            <ItemStyle VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fechaCita" HeaderText="FECHA">
                                            <ItemStyle VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EstadoCita" HeaderText="ESTADO">
                                            <ItemStyle VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="SERVICIO" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:GridView ID="gvDetalle" runat="server" Width="100%" CssClass="table table-bordered"
                                                    BorderStyle="None" AutoGenerateColumns="False" ShowHeader="false"
                                                    DataKeyNames="idDetalleCitaServicio" OnRowCommand="gvDetalle_RowCommand">
                                                    <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Servicio" ItemStyle-Width="10%">
                                                            <ItemStyle HorizontalAlign="Left" BorderStyle="None" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Programar">
                                                            <ItemTemplate>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:Button ID="ibtnProgramar" runat="server" AlternateText="Programar" CausesValidation="false" Visible='<%# Eval("Programar") %>'
                                                                            CommandArgument='<%# Bind("idDetalleCitaServicio") %>' CommandName="Programar" Text="Programar" CssClass="btn btn-default" Style="width: 60px; height: 20px" Font-Size="X-Small" />



                                                                        <asp:Button ID="ibtnModificar" runat="server" AlternateText="Modificar" CausesValidation="false" Visible='<%# Eval("Modificar") %>'
                                                                            CommandArgument='<%# Bind("idDetalleCitaServicio") %>' CommandName="Modificar" Text="Modificar" CssClass="btn btn-default" Style="width: 60px; height: 20px" Font-Size="X-Small" />


                                                                        <asp:Button ID="ibtnAnular" runat="server" AlternateText="Anular" CausesValidation="false" Visible='<%#Eval("Modificar") %>'
                                                                            CommandArgument='<%# Bind("idDetalleCitaServicio") %>' CommandName="Anular" Text="Anular" CssClass="btn btn-default" Style="width: 60px; height: 20px" Font-Size="X-Small" />
                                                                        <div style="margin-left: auto; cursor:default; margin-right: auto; text-align: center;" Visible='<%#Eval("Anulado") %>'>
                                                                        <asp:Label ID="lblAnulado"  Text="Anulado" runat="server" Visible='<%#Eval("Anulado") %>'  Style="width: 60px; height: 20px; text-align:center; "  Font-Size="X-Small"  ></asp:Label>
                                                                            </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" BorderStyle="None" Width="90%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle Font-Size="8pt" BorderStyle="Solid" BorderWidth="1" />
                                                </asp:GridView>
                                            </ItemTemplate>
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
                        </div>
                    </div>
                </section>
                <br>
                <br>
            </div>
        </div>
    </div>

    <%--Vista rapida clic grilla--%>
    <div class="modal fade" id="mydetallegrilla" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>

            <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalPTitleGD" runat="server" Text=""></asp:Label></h4>
                        </div>
                <div class="modal-body">
                    <%--contenido--%>

                    <fieldset>
                        <legend style="font-size: 12px"><span class="label label-warning">Observaciones:</span></legend>
                        
                        <div class="modal-header">

                                        <asp:TextBox ID="txtObservaciones" runat="server" ReadOnly="true" class="form-control" placeholder="" Style="width: 100%" TextMode="MultiLine" Rows="5"></asp:TextBox>

                                    </div>
                          

                       

                    </fieldset>
                    <fieldset>
                        <legend style="font-size: 14px"><span class="label label-warning">Servicios:</span></legend>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div id="table-responsive2" class="table-responsive">
                                        <asp:GridView ID="grvresultadodet" runat="server" CssClass="table table-bordered" Width="100%"
                                            BorderStyle="None" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="true">
                                            <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                            <Columns>
                                                <asp:BoundField DataField="Servicio" HeaderText="Servicio"></asp:BoundField>
                                                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio"></asp:BoundField>
                                                <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin"></asp:BoundField>
                                                <asp:BoundField DataField="Empleados" HeaderText="Empleado(s)"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Estado">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="Motivo" Text='<%# Bind("Estado") %>' ToolTip='<%# Bind("MotivoAnulacion") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle Font-Size="8pt" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </fieldset>



                    <%--fin de contenido--%>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" Text="Ocultar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnOcultar" Style="width: 30%" OnClick="btnOcultar_Click" />
                </div>
            </div>
            <%--              </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    <%--fin de vista rapida--%>


    <%--PROGRAMAR/MODIFICAR--%>
    <div class="modal fade" id="myModalP" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <asp:UpdatePanel ID="upModalP" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalPTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <div class="input-group-addon">Rol:</div>
                                            <asp:DropDownList ID="cboRol" runat="server" class="form-control" OnSelectedIndexChanged="cboRol_OnSelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <div class="input-group-addon">Sector rabajo:</div>
                                            <asp:DropDownList ID="cboSector" runat="server" class="form-control">
                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-sm-6">
                                    <label class="col-md-12  control-label">Empleado(s):</label>


                                </div>
                                <div class="col-sm-6">
                                    <label class="col-md-12  control-label">Asignado(s):</label>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6" style="height: 150px; overflow: scroll">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <asp:GridView ID="gvEmpleados" runat="server" CssClass="table table-bordered" Width="100%"
                                                    BorderStyle="None" AutoGenerateColumns="False" AllowSorting="False" AllowPaging="False" ShowHeaderWhenEmpty="False" ShowHeader="false"
                                                    DataKeyNames="idEmpleado" OnRowCommand="gvEmpleados_RowCommand">

                                                    <Columns>
                                                        <asp:BoundField DataField="nombreEmpleado"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Accion">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ibtnVer" runat="server" AlternateText="Accion" CausesValidation="false"
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Accion" ImageUrl="~/Content/Img/right.png" />
                                                                <itemstyle width="5%" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6" style="height: 150px; overflow: scroll">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <asp:GridView ID="gvEmpleadosAsig" runat="server" CssClass="table table-bordered"  Width="100%"
                                                    BorderStyle="None" AutoGenerateColumns="False" AllowSorting="False" AllowPaging="False" ShowHeaderWhenEmpty="False" ShowHeader="false"
                                                    DataKeyNames="idEmpleado" OnRowCommand="gvEmpleadosAsig_RowCommand">

                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Accion">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ibtnVer" runat="server" AlternateText="Accion" CausesValidation="false"
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Accion" ImageUrl="~/Content/Img/left.png" />
                                                                <itemstyle width="5%" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="nombreEmpleado"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label for="buscar" class="col-md-4  control-label">
                                    </label>
                                    <div class="col-md-8">
                                    </div>

                                </div>
                            </div>

                        </div>



                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:HiddenField runat="server" ID="idCitaP" />
                            <asp:HiddenField runat="server" ID="idServicioP" />
                            <asp:HiddenField runat="server" ID="idDetalleCitaP" />
                            <asp:HiddenField runat="server" ID="strServicio" />

                            <asp:Button runat="server" Text="Guardar" CssClass="btn btn-default" ID="btnGuardarP" Style="width: 30%" OnClick="btnGuardarP_Click" />
                            <asp:Button runat="server" Text="Cancelar" data-dismiss="modal" CssClass="btn btn-danger" ID="btnCancelarP" Style="width: 30%" />

                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>


    <%--ANULAR--%>
    <div class="modal fade" id="myModalA" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalA" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalATitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>

                            <fieldset id="fsAnulacion" runat="server">

                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtMotivoAnulacion" runat="server" TextMode="MultiLine" class="form-control" placeholder="Motivo de Anulacion" Style="width: 100%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>

                        </div>



                        <%--fin de contenido--%>

                        <div class="modal-footer">
                            <asp:HiddenField runat="server" ID="idServicioA" />
                            <asp:HiddenField runat="server" ID="idDetalleCitaA" />
                            <asp:HiddenField runat="server" ID="idCitaA" />

                            <asp:Button runat="server" Text="Anular" CssClass="btn btn-default" ID="btnGuardarA" Style="width: 30%" OnClick="btnGuardarA_Click" />
                            <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelarA" Style="width: 30%" data-dismiss="modal" />

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
