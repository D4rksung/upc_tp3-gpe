<%@ Page Title="Hoja de servicio" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActualizarHojaServicio.aspx.cs" Inherits="Web.Petcenter.ActualizarHojaServicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

        function Confirmar() {
            var answer = confirm('Hoja de servicio! \nRealmente desea Anular la hoja de servicio.?');
            if (!answer) {
                return false;
            }
            return true;
        }

    </script>

    <script>
        function callbusqueda() {
            $get('<%=btnBuscar.ClientID%>').click();
        }

    </script>

    <div class="page-header">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Actualizar Hoja de servicio</h3>
            </div>
            <div class="panel-body">
                <%--contenido aqui--%>

                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="NumHoja" class="col-md-4 control-label">
                                N° Hoja de servicio:</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtNumeroHoja" runat="server" class="form-control" placeholder="N° Hoja" alt="integer"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="servicio" class="col-md-4 control-label">
                                Servicio:</label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="cboservicio" runat="server" class="form-control">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechainicio" class="col-md-4 control-label">
                                Fecha Inicio:</label>
                            <div class="col-md-5">
                                <div class='input-group date' id='datetimepicker3'>
                                    <asp:TextBox ID="txtfechaInicio" runat="server" class="form-control" placeholder="Fecha Inicial"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                                <ajaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfechaInicio"
                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                    CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                    UserDateFormat="DayMonthYear">
                                </ajaxControlToolkit:MaskedEditExtender>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechafin" class="col-md-4 control-label">
                                Fecha Fin:</label>
                            <div class="col-md-5">
                                <div class='input-group date' id='datetimepicker5'>
                                    <asp:TextBox ID="txtFechaFin" runat="server" class="form-control" placeholder="Fecha Final"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                                <ajaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaFin"
                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                    CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                    UserDateFormat="DayMonthYear">
                                </ajaxControlToolkit:MaskedEditExtender>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechainicio" class="col-md-4 control-label">
                                Cliente:</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtcodigocliente" runat="server" class="form-control" placeholder="código del cliente" alt="integer"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-8">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="nombrecliente" class="col-md-2  control-label">
                                Nombre cliente:</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtnombrecliente" runat="server" class="form-control" placeholder="Nombre cliente"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="buscar" class="col-md-2  control-label">
                            </label>
                            <div class="col-md-1">
                                <asp:Button runat="server" Text="Nuevo" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="Listado" class="col-md-2  control-label">
                            </label>
                            <div class="col-md-10">
                                <asp:GridView ID="grvresultado" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
                                    BorderStyle="None" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnRowCommand="grvresultado_RowCommand">
                                    <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                    <Columns>
                                        <asp:BoundField DataField="numhojaservicio" HeaderText="N° HOJA DE SERVICIO"></asp:BoundField>
                                        <asp:BoundField DataField="fechaRegistro" HeaderText="FECHA EMISION"></asp:BoundField>
                                        <asp:BoundField DataField="NombreCliente" HeaderText="CLIENTE"></asp:BoundField>
                                        <asp:BoundField DataField="Servicios" HeaderText="SERVICIOS"></asp:BoundField>
                                        <asp:BoundField DataField="DescripcionEstado" HeaderText="ESTADO"></asp:BoundField>
                                        <asp:TemplateField HeaderText="EJECUTAR">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnVer" runat="server" AlternateText="Ejecutar" CausesValidation="false" Visible='<%# Convert.ToBoolean(Eval("indIcono1")) %>'
                                                    CommandArgument='<%# Bind("idHojaServicio") %>' CommandName="Ejecutar" ImageUrl="~/Content/Img/edit.png" />
                                                <itemstyle width="5%" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ANULAR">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnanular" runat="server" AlternateText="Anular" CausesValidation="false" Visible='<%# Convert.ToBoolean(Eval("indIcono2")) %>'
                                                    CommandArgument='<%# Bind("idHojaServicio") %>' CommandName="Anular" ImageUrl="~/Content/Img/ic_delete.png" OnClientClick="return Confirmar();" />
                                                <itemstyle width="5%" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle Font-Size="8pt" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">

                        <label for="nuevo" class="col-md-2  control-label"></label>
                        <asp:Label ID="lblmsg" runat="server" ForeColor="#993333"></asp:Label>
                        <hr />
                    </div>

                </div>

                <%--fin de contenido--%>
            </div>
        </div>
    </div>

    <%--Ejecutar hoja de servicio--%>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="fecha4" class="col-md-4 control-label">Fecha Emisión:</label>
                                        <div class="col-md-8">
                                            <div class='input-group date' id='datetimepicker1'>
                                                <asp:TextBox ID="txtfechaemisionalt" runat="server" class="form-control" placeholder="Fecha Emision"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                            <ajaxControlToolkit:MaskedEditExtender ID="meeFechaEmisionIni" runat="server" TargetControlID="txtfechaemisionalt"
                                                Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                                CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                                UserDateFormat="DayMonthYear">
                                            </ajaxControlToolkit:MaskedEditExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="fechainicio3" class="col-md-4 control-label"></label>
                                        <div class="col-md-8">
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="nombrecliente2" class="col-md-2  control-label">Observaciones:</label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtobservacionesejecutar" runat="server" class="form-control" placeholder="Observacion" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <div class="col-md-12">
                                            <asp:HiddenField ID="hfidHojaServicio" runat="server" Value="0" />
                                            <hr />
                                        </div>

                                    </div>
                                </div>

                                <div class="col-sm-12">
                                    <div class="form-group">

                                        <div class="col-md-12">
                                            <asp:GridView
                                                ID="grvResultadoPopup" runat="server" AllowPaging="True"
                                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="iddetalleHojaServicio" OnRowDataBound="grvResultadoPopup_RowDataBound"
                                                CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" PageSize="7" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="iddetalleHojaServicio" HeaderText="ID">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="descripcion" HeaderText="Servicio" />
                                                    <asp:TemplateField HeaderText="Hora inicio">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtHorainicio" runat="server" Width="80px" class="form-control" Text='<%# Bind("HoraInicio") %>'  />
                                                            <ajaxControlToolkit:MaskedEditExtender ID="meetxtHorainicio" runat="server" AutoComplete="False" InputDirection="RightToLeft" Mask="99:99" MaskType="Time" TargetControlID="txtHorainicio">
                                                            </ajaxControlToolkit:MaskedEditExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hora Fin">
                                                        <ItemTemplate>

                                                            <asp:TextBox ID="txtHoraFin" runat="server" Text='<%# Bind("HoraFin") %>' Width="80px" class="form-control" ></asp:TextBox>
                                                            <ajaxControlToolkit:MaskedEditExtender ID="meeFechaVencimiento" runat="server" AutoComplete="False" InputDirection="RightToLeft" Mask="99:99" MaskType="Time" TargetControlID="txtHoraFin">
                                                            </ajaxControlToolkit:MaskedEditExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle Font-Size="7pt" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Empleado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cboEmpleadoServ" runat="server" class="form-control">
                                                                <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle Font-Size="7pt" HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Estado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cboEstadoser" runat="server" class="form-control" SelectedValue='<%# Eval("Estado") %>'>
                                                                <asp:ListItem Value="001">PENDIENTE</asp:ListItem>
                                                                <asp:ListItem Value="002">FINALIZADO</asp:ListItem>
                                                                <asp:ListItem Value="003">RECHAZADO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle Font-Size="7pt" HorizontalAlign="Center" />
                                                    </asp:TemplateField>                                                 
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--fin de contenido--%>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                            <asp:Button runat="server" Text="Grabar cambios" CssClass="btn btn-primary" ID="btngrabarejecutar" OnClick="btngrabarejecutar_Click" />
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
