<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ActualizaProgramacion.aspx.cs" Inherits="Web.Petcenter.ActualizaProgramacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function AsignarValor() {

            window.location.href = "ActualizaProgramacion.aspx";
        }
        function UpdateDatos() {

            window.location.href = "ActualizaProgramacion.aspx";
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

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Actualizar programación de Atención</h3>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend>Lista de Citas:</legend>

                <table>
                    <tr>
                        <td>
                        <td>
                            <div class="row">

                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="buscar" class="col-md-2  control-label">Estado:</label>
                                        <div class="col-md-10" style="max-width: 250px">
                                            <asp:DropDownList ID="cboEstado" runat="server" class="form-control">
                                                <asp:ListItem Value="">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="buscar" class="col-md-4  control-label">Fecha Inicio:</label>
                                        <div class="col-md-6" style="max-width: 250px">
                                            <div class='input-group date' id='datetimepicker3'>
                                                <asp:TextBox ID="txtfechaInicio" runat="server" class="form-control" placeholder="Fecha Inicial"></asp:TextBox>

                                                <ajaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfechaInicio"
                                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                    CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                                    CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                                    UserDateFormat="DayMonthYear">
                                                </ajaxControlToolkit:MaskedEditExtender>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="buscar" class="col-md-4  control-label">Fecha Fin:</label>
                                        <div class="col-md-6" style="max-width: 250px">
                                            <div class='input-group date' id='datetimepicker5'>
                                                <asp:TextBox ID="txtFechaFin" runat="server" class="form-control" placeholder="Fecha Final"></asp:TextBox>

                                                <ajaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaFin"
                                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                    CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                                    CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                                    UserDateFormat="DayMonthYear">
                                                </ajaxControlToolkit:MaskedEditExtender>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">

                                        <div class="col-md-12">
                                            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" Style="min-width: 100px" OnClick="btnBuscar_Click" />
                                        </div>

                                    </div>
                                </div>


                            </div>


                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">

                                        <div class="col-md-12">
                                            <asp:GridView ID="grvresultado" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
                                                BorderStyle="None" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                                OnRowDataBound="grvresultado_RowDataBound" OnSelectedIndexChanged="grvresultado_OnSelectedIndexChanged" DataKeyNames="idCita,DescripcionCita">
                                                <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkAsignacion" runat="server" OnCheckedChanged="chkAsignacion_CheckedChanged" AutoPostBack="true" />
                                                        </ItemTemplate>
                                                        <ControlStyle BackColor="#CCCCCC" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="fechaCita" HeaderText="FECHA">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="horaCita" HeaderText="HORA">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NroCita" HeaderText="CODIGO">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cliente" HeaderText="CLIENTE">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nombreMascota" HeaderText="MASCOTA">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EstadoCita" HeaderText="ESTADO">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="SERVICIO">
                                                        <ItemTemplate>
                                                            <asp:GridView ID="gvDetalle" runat="server" Width="100%" CssClass="table table-bordered"
                                                                BorderStyle="None" AutoGenerateColumns="False" ShowHeader="false"
                                                                DataKeyNames="idDetalleCitaServicio" OnRowCommand="gvDetalle_RowCommand">
                                                                <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Servicio">
                                                                        <ItemStyle HorizontalAlign="Left" BorderStyle="None" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Programar">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="ibtnProgramar" runat="server" AlternateText="Programar" CausesValidation="false" Visible='<%# Eval("Programar") %>'
                                                                                CommandArgument='<%# Bind("idDetalleCitaServicio") %>' CommandName="Programar" Text="Programar" CssClass="btn btn-default" Style="min-width: 100px" />

                                                                            <asp:Button ID="ibtnModificar" runat="server" AlternateText="Modificar" CausesValidation="false" Visible='<%# Eval("Modificar") %>'
                                                                                CommandArgument='<%# Bind("idDetalleCitaServicio") %>' CommandName="Modificar" Text="Modificar" CssClass="btn btn-default" Style="min-width: 100px" />

                                                                            <asp:Button ID="ibtnAnular" runat="server" AlternateText="Anular" CausesValidation="false" Visible='<%#Eval("Modificar") %>'
                                                                                CommandArgument='<%# Bind("idDetalleCitaServicio") %>' CommandName="Anular" Text="Anular" CssClass="btn btn-default" Style="min-width: 100px" />
                                                                            <itemstyle width="5%" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Right" BorderStyle="None" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle Font-Size="8pt" BorderStyle="Solid" BorderWidth="1" />
                                                            </asp:GridView>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                                <RowStyle Font-Size="8pt" />
                                            </asp:GridView>

                                            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                                           
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">

                                    <label for="nuevo" class="col-md-2  control-label"></label>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="#993333"></asp:Label>
                                    <hr />
                                </div>
                            </div>

                        </td>
                        <td style="width: 15px"></td>
                        <td>

                            <%--DETALLE--%>
                            <div runat="server" id="divDetalle" visible="false" style="font-size: 12px">

                                <fieldset>
                                    <legend style="font-size: 12px"><span class="label label-warning">Datos de la cita:</span></legend>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtCodigo" class="col-md-4  control-label">Codigo:</label>
                                                <asp:HiddenField runat="server" ID="hndidCita" />
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="true" class="form-control" placeholder="Codigo" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtEstado" class="col-md-4  control-label">Estado:</label>
                                                <asp:HiddenField runat="server" ID="HiddenField1" />
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEstado" runat="server" ReadOnly="true" class="form-control" placeholder="Codigo" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtFechaCita" class="col-md-4 control-label">
                                                    Fecha :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtFechaCita" runat="server" ReadOnly="true" class="form-control" placeholder="Fecha"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtHoraCita" class="col-md-4 control-label">
                                                    Hora :</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtHoraCita" runat="server" ReadOnly="true" class="form-control" placeholder="Hora"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <div class="col-md-8">
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </fieldset>
                                <fieldset>
                                    <legend style="font-size: 12px"><span class="label label-warning">Datos del Cliente:</span></legend>
                                    <div class="row">

                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <label for="txtnombrecliente" class="col-md-2  control-label">Nombre:</label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtnombrecliente" ReadOnly="true" runat="server" class="form-control" placeholder="Nombre cliente" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>

                                <fieldset>
                                    <legend style="font-size: 12px"><span class="label label-warning">Datos de la mascota:</span></legend>
                                    <div class="row">

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtnombreMascota" class="col-md-4  control-label">Nombre:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtnombreMascota" ReadOnly="true" runat="server" class="form-control" placeholder="Nombre Mascota" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtEspecieMascota" class="col-md-4  control-label">Especie:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEspecieMascota" ReadOnly="true" runat="server" class="form-control" placeholder="Especie" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtRazaMascota" class="col-md-4  control-label">Raza:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtRazaMascota" ReadOnly="true" runat="server" class="form-control" placeholder="Raza" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtTamanioMascota" class="col-md-4  control-label">Tamaño:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtTamanioMascota" ReadOnly="true" runat="server" class="form-control" placeholder="Tamaño" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtGeneroMascota" class="col-md-4  control-label">Genero:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtGeneroMascota" ReadOnly="true" runat="server" class="form-control" placeholder="Genero" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="txtEdadMascota" class="col-md-4  control-label">Edad:</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEdadMascota" ReadOnly="true" runat="server" class="form-control" placeholder="Edad" Style="width: 100%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </fieldset>
                                <fieldset>
                                    <legend style="font-size: 14px"><span class="label label-warning">Servicios:</span></legend>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <label for="Listado" class="col-md-2  control-label">
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grvresultadodet" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
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
                                        <div class="col-sm-12">

                                            <label for="nuevo" class="col-md-2  control-label"></label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#993333"></asp:Label>
                                            <hr />
                                        </div>
                                    </div>
                                </fieldset>


                                <asp:Button runat="server" Text="Ocultar" CssClass="btn btn-primary" ID="btnOcultar" Style="width: 30%" OnClick="btnOcultar_Click" />
                            </div>
                        </td>
                    </tr>
                </table>

            </fieldset>

        </div>
    </div>



    <%--PROGRAMAR/MODIFICAR--%>
    <div class="modal fade" id="myModalP" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
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
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <div class="col-md-8">
                                            <label for="cboRol" class="col-md-6  control-label">Rol:</label>
                                            <asp:DropDownList ID="cboRol" runat="server" class="form-control" OnSelectedIndexChanged="cboRol_OnSelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="cboSector" class="col-md-6  control-label">Sector trabajo:</label>

                                        <div class="col-md-12">
                                            <asp:DropDownList ID="cboSector" runat="server" class="form-control">
                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="col-md-4  control-label">Empleado:</label>
                                            <div class="col-md-12">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <label class="col-md-4  control-label">Asignado:</label>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6" style="height: 150px; overflow: scroll">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <asp:GridView ID="gvEmpleados" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
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
                                                <asp:GridView ID="gvEmpleadosAsig" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
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

                            <asp:Button runat="server" Text="Guardar" CssClass="btn btn-primary" ID="btnGuardarP" Style="width: 30%" OnClick="btnGuardarP_Click" />
                            <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-primary" ID="btnCancelarP" Style="width: 30%" OnClick="btnCancelarP_Click" />

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
                                <legend style="font-size: 14px"></legend>
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

                            <asp:Button runat="server" Text="Anular" CssClass="btn btn-primary" ID="btnGuardarA" Style="width: 30%" OnClick="btnGuardarA_Click" />
                            <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-primary" ID="btnCancelarA" Style="width: 30%" OnClick="btnCancelarA_Click" />

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
                            <asp:Button runat="server" Text="Aceptar" CssClass="btn btn-primary" ID="btnAceptar" Style="width: 30%" OnClick="btnAceptar_Click" />

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
                            <asp:Button runat="server" Text="SI" CssClass="btn btn-primary" ID="btnSi" Style="width: 30%" OnClick="btnsi_Click" />

                            <button class="btn btn-info" data-dismiss="modal" style="width: 30%" aria-hidden="true">NO</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
