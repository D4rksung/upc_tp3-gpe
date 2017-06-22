<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GestionHojaServicio.aspx.cs" Inherits="Web.Petcenter.GestionHojaServicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        function AsignarValor() {

            window.location.href = "GestionHojaServicio.aspx";
        }
        $(function () {
            $("#<%= txtfechaIni.ClientID%>").datepicker({
                todayBtn: "linked",
                language: "it",
                autoclose: true,
                todayHighlight: true,
                dateFormat: 'dd/mm/yy'
            });
        });

            $(function () {
                $("#<%= txtFechaFinal.ClientID%>").datepicker({
                    todayBtn: "linked",
                    language: "it",
                    autoclose: true,
                    todayHighlight: true,
                    dateFormat: 'dd/mm/yy'

                });
            });

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
                    <h2 class="text-center">Actualizar Hoja de Servicio</h2>
                    <br>
                </section>
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">

                            <div class="input-group">
                                <div class="input-group-addon">Fecha Inicio:<font size="2" color="red"></font></div>
                                <asp:TextBox ID="txtfechaIni" runat="server" class="form-control" ReadOnly="true" placeholder="Fecha Inicial"></asp:TextBox>


                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-addon">Fecha Fin:<font size="2" color="red"></font></div>
                                <asp:TextBox ID="txtFechaFinal" runat="server" class="form-control" ReadOnly="true" placeholder="Fecha Final"></asp:TextBox>


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
                <br />

                <section>
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de Asignaciones del día
                                <asp:Label ID="lbldia" runat="server"></asp:Label></h3>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">

                                    <div class="input-group">
                                        <div id="table-responsive" class="table-responsive">
                                            <asp:GridView ID="gvDetalle" runat="server" class="table table-bordered" Width="100%"
                                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                                OnRowCommand="gvDetalle_RowCommand" DataKeyNames="iddetalleCita">

                                                <Columns>
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
                                                    <asp:BoundField DataField="especieMascota" HeaderText="ESPECIE">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="generoMascota" HeaderText="GENERO">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="razaMascota" HeaderText="RAZA">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="tamanioMascota" HeaderText="TAMAÑO">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="canilMascota" HeaderText="NRO CANIL">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EstadoCita" HeaderText="ESTADO">
                                                        <ItemStyle VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="ACCION">
                                                        <ItemTemplate>
                                                            <asp:Button ID="ibtnEjecutar" runat="server" AlternateText="Ejecutar" CausesValidation="false" Visible='<%# Eval("Ejecutar") %>'
                                                                CommandArgument='<%# Bind("iddetalleCita") %>' CommandName="Ejecutar" Text="Ejecutar" CssClass="btn btn-default" Style="min-width: 70px" Height="20px" Font-Size="X-Small" />

                                                            <asp:Button ID="ibtnFinalizar" runat="server" AlternateText="Finalizar" CausesValidation="false" Visible='<%# Eval("Finalizar") %>'
                                                                CommandArgument='<%# Bind("iddetalleCita") %>' CommandName="Finalizar" Text="Finalizar" CssClass="btn btn-default" Style="min-width: 70px" Height="20px" Font-Size="X-Small" />

                                                            <itemstyle width="5%" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>


                                                </Columns>
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
                                <asp:Label ID="lblModalPTitle" runat="server" Text=""></asp:Label></h4>
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
                                                            <asp:DropDownList ID="cboEstado" runat="server" Enabled="false" class="form-control" Height="30px">
                                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                            </asp:DropDownList>

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


                            <div class="row">
                                <div class="col-sm-12">

                                    <div class="modal-content">

                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="container">
                                                                <ul class="nav nav-tabs">
                                                                    <li><a data-toggle="tab" href="#Comentarios">Comentarios</a></li>
                                                                    <li class="active"><a data-toggle="tab" href="#Materiales">Materiales</a></li>
                                                                    <li><a data-toggle="tab" href="#Tracking">Tracking</a></li>
                                                                </ul>
                                                                <div class="tab-content">
                                                                    <div id="Comentarios" class="tab-pane fade ">

                                                                        <div class="row">
                                                                            <asp:TextBox ID="txtComent" runat="server" TextMode="MultiLine" Width="800px" Rows="2" class="form-control" placeholder="Ingrese Comentario y presione Enter"></asp:TextBox>
                                                                        </div>
                                                                        <div style="height:150px">
                                                                            <asp:GridView ID="gvComents" runat="server" class="table table-bordered" Width="400px" Height="100px"
                                                                                AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="false" ShowHeader="false" PageSize="3">

                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="ACCION">
                                                                                        <ItemTemplate>   <asp:Label ID="lblUser" Width="100%" runat="server" Text='<%# Eval("UserComent") %>'></asp:Label>
                                                                                           
                                                                                                            <asp:Label ID="lblComment" Width="300px" runat="server" Text='<%# Eval("Coment") %>'></asp:Label>
                                                                                                     
                                                                                            <itemstyle width="5%" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <RowStyle Font-Size="8pt" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                    <div id="Materiales" class="tab-pane fade in active">
                                                                        <div style="height:200px">
                                                                        <asp:GridView ID="gvMateriales" runat="server" class="table table-bordered" Width="400px" Height="100px"
                                                                            AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="false" ShowHeader="true" PageSize="3">

                                                                            <Columns>

                                                                                <asp:BoundField DataField="material" HeaderText="MATERIAL">
                                                                                    <ItemStyle VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="CANTIDAD">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox ID="txtCantidad" Width="50px" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>

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
                                                                        <div style="height:200px">
                                                                        <asp:GridView ID="gvTracking" runat="server" class="table table-bordered" Width="400px" Height="100px"
                                                                            AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="false" ShowHeader="true" PageSize="3">

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
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>


                             </div>
                            <%--fin de contenido--%>

                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="idDetalleCita" />

                                <asp:Button runat="server" Text="Guardar" CssClass="btn btn-default" ID="btnGuardarP" Style="width: 30%" OnClick="btnGuardarP_Click" />
                                <asp:Button runat="server" Text="Cancelar" data-dismiss="modal" CssClass="btn btn-default" ID="btnCancelarP" Style="width: 30%" />

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
                            <asp:Button runat="server" Text="Aceptar" CssClass="btn btn-default" ID="btnAceptar" Style="width: 30%" OnClick="btnAceptar_Click" />

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

                            <button class="btn btn-info" data-dismiss="modal" style="width: 30%" aria-hidden="true">NO</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
