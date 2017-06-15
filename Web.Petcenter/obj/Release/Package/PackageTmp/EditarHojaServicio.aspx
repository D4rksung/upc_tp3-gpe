<%@ Page Title="Editar Hoja servicio" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EditarHojaServicio.aspx.cs" Inherits="Web.Petcenter.EditarHojaServicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function callbusqueda(valor) {
            $get('<%=txtcodigocita.ClientID%>').value = valor;
            $get('<%=btnbuscarcita.ClientID%>').click();
        }

        $('<%=txtcodigocita.ClientID%>').keypress(function (e) {
            if (e.which == 13) {
                $get('<%=btnbuscarcita.ClientID%>').click();
            }
        });

    </script>
    <div class="page-header">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Editar Hoja de servicio</h3>
            </div>
            <div class="panel-body">
                <%--contenido aqui--%>

                <div class="row">
                    
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fecha" class="col-md-4 control-label">Fecha Emisión:</label>
                            <div class="col-md-8">
                                <div class='input-group date' id='datetimepicker3'>
                                    <asp:TextBox ID="txtfecharegistro" runat="server" class="form-control" placeholder="Fecha de registro"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                                
                                <ajaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfecharegistro"
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
                            <label for="fechainicio" class="col-md-4 control-label">N° Canil:</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="cbojaula" runat="server" class="form-control">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechafin" class="col-md-4 control-label">Código de Cita:</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtcodigocita" runat="server" class="form-control" alt="integer"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Button runat="server" Text="Buscar Cita" CssClass="btn btn-primary" ID="btnbuscarcita" OnClick="btnbuscarcita_Click" CausesValidation="false" />
                            </div>
                            <div class="col-md-8">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">

                            <label for="nombrecliente" class="col-md-2  control-label"><span class="label label-warning">Datos del cliente</span></label>
                            <div class="col-md-10">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechainicio" class="col-md-4 control-label">Cliente:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtcodigocliente" runat="server" class="form-control" placeholder="código del cliente" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="nombrecliente" class="col-md-2  control-label">Nombre cliente:</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtnombrecliente" runat="server" class="form-control" placeholder="Nombre cliente" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="nombrecliente" class="col-md-2  control-label"><span class="label label-warning">Datos de la mascota</span></label>
                            <div class="col-md-10">
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Codigo:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtcodigomascota" runat="server" class="form-control" placeholder="" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="nommascota" class="col-md-4 control-label">Nombre mascota:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtnombremascota" runat="server" class="form-control" placeholder="" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Especie:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtespeciemascota" runat="server" class="form-control" placeholder="Especie" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Sexo:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtsexomascota" runat="server" class="form-control" placeholder="Sexo" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Edad:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtedadmascota" runat="server" class="form-control" placeholder="" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Tamaño:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txttamañomascota" runat="server" class="form-control" placeholder="" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="nombrecliente" class="col-md-2  control-label">Observaciones:</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtobservaciones" runat="server" class="form-control" placeholder="Observaciones" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="nombrecliente" class="col-md-2  control-label"><span class="label label-warning">Datos del servicio</span></label>
                            <div class="col-md-10">
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="Listado" class="col-md-2  control-label"></label>
                            <div class="col-md-10">
                                <asp:GridView ID="grvresultado" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
                                    BorderStyle="None" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
                                    <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                    <Columns>

                                        <asp:BoundField DataField="item" HeaderText="Item"></asp:BoundField>
                                        <asp:BoundField DataField="idServicio" HeaderText="Cod Servicio"></asp:BoundField>
                                        <asp:BoundField DataField="descripcion" HeaderText="Servicio"></asp:BoundField>

                                    </Columns>

                                    <RowStyle Font-Size="8pt" />
                                </asp:GridView>


                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="buscar" class="col-md-2  control-label"></label>
                            <div class="col-md-1">
                                <asp:Button runat="server" Text="Regresar" CssClass="btn btn-default" ID="btnregresar" OnClick="btnregresar_Click" CausesValidation="false" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button runat="server" Text="Grabar" CssClass="btn btn-default" ID="btngrabar" OnClick="btngrabar_Click" />
                            </div>
                        </div>
                    </div>

                      <div class="col-sm-12">
                        <div class="form-group">
                           
                            <div class="col-md-12">
                                <div style="display:none">
                                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtfecharegistro"
                                    class="form-control" ErrorMessage="Ingrese la fecha de emisión."   />
                                     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcodigocita"
                                    class="form-control" ErrorMessage="Ingrese el codigo de la cita."   />
                                    </div>
                               <asp:ValidationSummary runat="server" CssClass="alert alert-warning"  />
                            </div>
                            
                        </div>
                    </div>

                </div>

                <%--fin de contenido--%>
            </div>
        </div>
    </div>

    <%--busqueda de citas--%>
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
                                        <label for="fecha4" class="col-md-4 control-label">Fecha Inicial:</label>
                                        <div class="col-md-8">
                                            <div class='input-group date' id='datetimepicker1'>
                                                <asp:TextBox ID="txtfechainicita" runat="server" class="form-control" placeholder="Fecha Inicial"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                            <ajaxControlToolkit:MaskedEditExtender ID="meeFechaEmisionIni" runat="server" TargetControlID="txtfechainicita"
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
                                        <label for="fechainicio3" class="col-md-4 control-label">Fecha Final:</label>
                                        <div class="col-md-8">
                                            <div class='input-group date' id='datetimepicker2'>
                                                <asp:TextBox ID="txtfechafincita" runat="server" class="form-control" placeholder="Fecha Final"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                            <ajaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfechafincita"
                                                Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                                CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                                UserDateFormat="DayMonthYear">
                                            </ajaxControlToolkit:MaskedEditExtender>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="nombrecliente2" class="col-md-2  control-label">Nombre cliente:</label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtnombreclicita" runat="server" class="form-control" placeholder="Nombre cliente"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="buscar" class="col-md-2  control-label"></label>
                                        <div class="col-md-10">
                                            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-warning" ID="btnbuscarcitapopup" OnClick="btnbuscarcitapopup_Click" CausesValidation="false" />
                                        </div>

                                    </div>
                                </div>

                                <div class="col-sm-12">
                                    <div class="form-group">
                                        
                                        <div class="col-md-12">
                                            <asp:GridView
                                                ID="grvResultadoPopup" runat="server" AllowPaging="True"
                                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idCita"
                                                CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" PageSize="7" Width="100%" OnSelectedIndexChanged="grvResultadoPopup_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="idCita" HeaderText="Codigo Cita" />
                                                    <asp:BoundField HeaderText="Fecha Cita" DataField="fecharegistro" />
                                                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                                                    <asp:BoundField DataField="Servicios" HeaderText="Servicios" />
                                                    <asp:BoundField DataField="NombreMascota" HeaderText="Mascota" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Content/Img/orange-open-in-browser-16.png"
                                                        ShowSelectButton="True">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                </Columns>
                                                <PagerSettings Position="Top" Visible="False" />
                                                <PagerStyle HorizontalAlign="Right" />
                                            </asp:GridView>


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--fin de contenido--%>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
