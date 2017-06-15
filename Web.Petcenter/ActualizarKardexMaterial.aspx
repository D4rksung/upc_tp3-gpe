<%@ Page Title="Actualizar" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActualizarKardexMaterial.aspx.cs" Inherits="Web.Petcenter.ActualizarKardexMaterial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

        function Confirmar() {
            var answer = confirm('Kardex de Material! \nRealmente desea Anular el Movimiento de Material en el Kardex.?');
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
                <h3 class="panel-title">Movimientos Kardex Material</h3>
            </div>
            <div class="panel-body">
                <%--contenido aqui--%>

                <div class="row">


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
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="NumHoja" class="col-md-2 control-label">
                                Material:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtnombrematerial" runat="server" class="form-control" placeholder="Nombre material"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="buscar" class="col-md-2  control-label">
                            </label>
                            <div class="col-md-1">
                                <asp:Button runat="server" Text="Registrar" CssClass="btn btn-primary" ID="btnIngresar" OnClick="btnIngresar_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group">
                    
                            <div class="col-md-12">

                                <asp:GridView ID="grvIngresoMateriales" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" OnRowCommand="grvIngresoMateriales_RowCommand" PageSize="5" OnPageIndexChanging="grvIngresoMateriales_PageIndexChanging" >
                                     <HeaderStyle Font-Size="8pt" Font-Names="Arial"  />
                                    <Columns>
                                       
                                        <asp:BoundField DataField="FechaIng" HeaderText="FECHA" />
                                        <asp:BoundField DataField="DscMotivoIngreso" HeaderText="TIPO MOVIMIENTO" />
                                        <asp:BoundField DataField="CodMaterial" HeaderText="CODMATERIAL">
                                           
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DscMaterial" HeaderText="MATERIAL">
                                           
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Especificaciones" HeaderText="ESPECIFICACIONES">
                                           
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UniMedida" HeaderText="UNIDAD">
                                           
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="CANTIDAD">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="ESTADO">
                                            
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnAnular" runat="server" AlternateText="Anular"  Visible='<%# Convert.ToBoolean(Eval("indIcono1")) %>' CausesValidation="false" CommandArgument='<%# Bind("idKardex") %>' CommandName="Anular" ImageUrl="~/Content/Img/ic_delete.png" OnClientClick="return Confirmar();" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Position="Top" />
                                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
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
    <%--fin de contenido--%>
</asp:Content>
