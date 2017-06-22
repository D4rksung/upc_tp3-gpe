<%@ Page Title="Ingreso Mov" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EditarKardexMaterial.aspx.cs" Inherits="Web.Petcenter.EditarKardexMaterial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function callbusqueda(valor) {
            $get('<%=txtcodmaterial.ClientID%>').value = valor;
            $get('<%=btnbuscarmaterial.ClientID%>').click();
        }

        $('<%=txtcodmaterial.ClientID%>').keypress(function (e) {
            if (e.which == 13) {
                $get('<%=btnbuscarmaterial.ClientID%>').click();
            }
        });

    </script>
    <div class="page-header">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Ingreso Movimiento Kardex Material</h3>
            </div>
            <div class="panel-body">
                <%--contenido aqui--%>

                <div class="row">

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fecha" class="col-md-4 control-label">Fecha Movimiento:</label>
                            <div class="col-md-4">
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
                            <label for="fechainicio" class="col-md-4 control-label">Tipo Movimiento:</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="cboTipoMov" runat="server" class="form-control">
                                    <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechafin" class="col-md-4 control-label">Código Material:</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtcodmaterial" runat="server" class="form-control" alt="integer"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Button runat="server" Text="Buscar Material" CssClass="btn btn-primary" ID="btnbuscarmaterial" CausesValidation="false" OnClick="btnbuscarmaterial_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Nombre:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtnommaterial" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Descripción:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtDescripciónmat" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Categoría:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtcategoria" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Modelo:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtmodelo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Und. Medidad:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtundmedida" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Precio compra:</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtpreciocompra" runat="server" class="form-control" alt="decimal-us">0.00</asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Cantidad:</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtcantidad" runat="server" class="form-control" alt="decimal-us">0.00</asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="codmascota" class="col-md-4 control-label">Doc. Referencia:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtnumguia" runat="server" class="form-control" placeholder="N° Guía"></asp:TextBox>

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
                                <div style="display: none">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtfecharegistro"
                                        class="form-control" ErrorMessage="Ingrese la fecha del movimiento." />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcodmaterial"
                                        class="form-control" ErrorMessage="Ingrese el codigo del material." />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cboTipoMov"
                                        class="form-control" ErrorMessage="Seleccione el tipo de movimiento" InitialValue="0" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcantidad"
                                        class="form-control" ErrorMessage="Ingrese la cantidad" InitialValue="0.00" />
                                </div>
                                <asp:ValidationSummary runat="server" CssClass="alert alert-warning" />
                            </div>

                        </div>
                    </div>

                </div>


                <%--fin de contenido--%>
            </div>
        </div>
    </div>

    <%--Busqueda--%>
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
                                        <label for="fecha4" class="col-md-4 control-label">Nombre:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtnombrepopup" runat="server" class="form-control" placeholder="nombre"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="fechainicio3" class="col-md-4 control-label">Descripción:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtdescripcionpopup" runat="server" class="form-control" placeholder="Descripción"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="fecha4" class="col-md-4 control-label">Categoría:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtcategoriapopup" runat="server" class="form-control" placeholder="Categoría"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="fechainicio3" class="col-md-4 control-label">Modelo:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtmodelopopup" runat="server" class="form-control" placeholder="Modelo"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="buscar" class="col-md-2  control-label"></label>
                                        <div class="col-md-10">
                                            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-warning" ID="btnbuscarmaterialpopup" OnClick="btnbuscarmaterialpopup_Click" CausesValidation="false" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">

                                        <div class="col-md-12">
                                            <asp:GridView
                                                ID="grvResultadoPopup" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataKeyNames="idMaterial" PagerSettings-Position="Top"
                                                CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" PageSize="5" Width="100%" OnPageIndexChanging="grvResultadoPopup_PageIndexChanging" OnSelectedIndexChanged="grvResultadoPopup_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="idMaterial" HeaderText="Codigo Material" />
                                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                                    <asp:BoundField DataField="UnidadMedida" HeaderText="Und. Medida" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Content/Img/orange-open-in-browser-16.png"
                                                        ShowSelectButton="True">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                </Columns>
                                                <HeaderStyle CssClass="bg-primary" />
                                                <PagerSettings Position="Top" />
                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
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
