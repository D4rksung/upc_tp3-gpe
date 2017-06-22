<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ActualizarProgramaciondeAtencion.aspx.cs" Inherits="Web.Petcenter.ActualizarProgramaciondeAtencion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script>
        function AsignarValor(tipo, valor) {
            if (tipo == 1) {
                document.getElementById("ContentPlaceHolder1_txtCodigoCita").value = valor;
            } else {
                document.getElementById("ContentPlaceHolder1_txtCodigoMascota").value = valor;
            }
        }
    </script>
       <style type="text/css">
        
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #FFFFBF;
        }
    </style>
     <div class="page-header">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Actualizar programación de Atención</h3>
            </div>
            <div class="panel-body">
                <%--contenido aqui--%>
                <fieldset>
    <legend>Buscar:</legend>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="NumHoja" class="col-md-4 control-label">
                               Codigo de Cita:</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCodigoCita"  ReadOnly="true" runat="server" class="form-control" placeholder="Codigo de Cita" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                           
                            <div class="col-md-8">
                                <asp:Button runat="server" Text="Buscar Cita" CssClass="btn btn-primary" ID="btnBuscarCita" OnClick="btnBuscarCita_Click" />
                   
                            </div>
                        </div>
                    </div>

                    
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="NumHoja" class="col-md-4 control-label">
                               Codigo de Mascota:</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCodigoMascota"  ReadOnly="true" runat="server" class="form-control" placeholder="Codigo de Mascota" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                           
                            <div class="col-md-8">
                                <asp:Button runat="server" Text="Buscar Mascota" CssClass="btn btn-primary" ID="btnMascota" OnClick="btnMascota_Click" />
                   
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
                                <ajaxcontroltoolkit:maskededitextender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfechaInicio"
                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                    CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                    UserDateFormat="DayMonthYear">
                                </ajaxcontroltoolkit:maskededitextender>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fechainicio" class="col-md-3 control-label">
                                Fecha Fin:</label>
                            <div class="col-md-5">
                                <div class='input-group date' id='datetimepicker5'>
                                    <asp:TextBox ID="txtFechaFin" runat="server" class="form-control" placeholder="Fecha Final"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                                <ajaxcontroltoolkit:maskededitextender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaFin"
                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureThousandsPlaceholder="" CultureDecimalPlaceholder=""
                                    CultureTimePlaceholder="" CultureDatePlaceholder="" MaskType="Date" Mask="99/99/9999"
                                    UserDateFormat="DayMonthYear">
                                </ajaxcontroltoolkit:maskededitextender>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="servicio" class="col-md-4 control-label">
                                Estado:</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="cboEstado" runat="server" class="form-control">
                                    <asp:ListItem Value="">Seleccione</asp:ListItem>
                                </asp:DropDownList>
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
                            <label for="buscar" class="col-md-4  control-label">
                            </label>
                            <div class="col-md-8">
                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" style="width:30%" OnClick="btnBuscar_Click" />
                            </div>

                        </div>
                    </div>

                    
                </div>
</fieldset>
                
                <fieldset>
    <legend></legend>
                <div class="row">

                    
                    <div class="col-sm-4">
                        <div class="form-group">
                           
                            <div class="col-md-12">
                                <asp:Button runat="server" Text="Programar Cita" CssClass="btn btn-primary" ID="btnProgramarCita" style="width:80%" OnClick="btnProgramarCita_Click"  />
                   
                            </div>
                        </div>
                    </div>

                    
                    <div class="col-sm-4">
                        <div class="form-group">
                           
                            <div class="col-md-12">
                                <asp:Button runat="server" Text="Modificar Programación" CssClass="btn btn-primary" ID="btnProgramacion" style="width:80%" OnClick="btnProgramacion_Click" />
                   
                            </div>
                        </div>
                    </div>

                    
                    <div class="col-sm-4">
                        <div class="form-group">
                           
                            <div class="col-md-12">
                                <asp:Button runat="server" Text="Anular Programación" CssClass="btn btn-primary" ID="btnAnularProgramacion" style="width:80%" OnClick="btnAnularProgramacion_Click"  />
                   
                            </div>
                        </div>
                    </div>
 </div>
                    </fieldset>
                <fieldset>
    <legend>Resultado:</legend>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label for="Listado" class="col-md-2  control-label">
                            </label>
                            <div class="col-md-10">
                                <asp:GridView ID="grvresultado" runat="server" CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" Width="100%"
                                    BorderStyle="None" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowHeaderWhenEmpty="true"
                                     OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" DataKeyNames="idCita" >
                                    <HeaderStyle Font-Size="8pt" Font-Names="Arial" />
                                    <Columns>
                                        <asp:BoundField DataField="fechaCita" HeaderText="FECHA DE CITA"></asp:BoundField>
                                        <asp:BoundField DataField="horaCita" HeaderText="HORA DE CITA"></asp:BoundField>
                                        <asp:BoundField DataField="NroCita" HeaderText="CODIGO DE CITA"></asp:BoundField>
                                        <asp:BoundField DataField="Cliente" HeaderText="CLIENTE"></asp:BoundField>
                                        <asp:BoundField DataField="nombreMascota" HeaderText="MASCOTA"></asp:BoundField>
                                        <asp:BoundField DataField="DescripcionCita" HeaderText="SERVICIO"></asp:BoundField>
                                        <asp:BoundField DataField="EstadoCita" HeaderText="ESTADO"></asp:BoundField>
                                        
                                    </Columns>
                                    <RowStyle Font-Size="8pt" />
                                </asp:GridView>
                                
    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=grvresultado] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">

                        <label for="nuevo" class="col-md-2  control-label"></label>
                        <asp:Label ID="lblmsg" runat="server" ForeColor="#993333"></asp:Label>
                        <hr />
                    </div>
               </div>
                    </fieldset>
                <%--fin de contenido--%>
            </div>
        </div>
    </div>

    <%--Buscar Cita--%>
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
                                        <label for="fecha4" class="col-md-4 control-label">Fecha Inicio:</label>
                                        <div class="col-md-8">
                                            <div class='input-group date' id='dtFechaInicioCita'>
                                                <asp:TextBox ID="txtFechaInicioCita" runat="server" class="form-control" placeholder="Fecha Inicio"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                            <ajaxControlToolkit:MaskedEditExtender ID="meeFechaInicioCita" runat="server" TargetControlID="txtFechaInicioCita"
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
                                        <label for="fecha4" class="col-md-4 control-label">Fecha Fin:</label>
                                        <div class="col-md-8">
                                            <div class='input-group date' id='dtFechaFinCita'>
                                                <asp:TextBox ID="txtFechaFinCita" runat="server" class="form-control" placeholder="Fecha Fin"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                            <ajaxControlToolkit:MaskedEditExtender ID="meeFechaFinCita" runat="server" TargetControlID="txtFechaFinCita"
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
                                        <label for="nombrecliente2" class="col-md-4  control-label">Codigo de cita:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCodigoCitaCita" runat="server" class="form-control" placeholder="Codigo de cita" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                       
                                    </div>
                                </div>
                                
                            </div>
                            <fieldset>
                            <legend style="font-size:14px">Datos del Cliente:</legend>
                            <div class="row">
                                
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtCodigoClienteCita" class="col-md-4  control-label">Codigo:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCodigoClienteCita" runat="server" class="form-control" placeholder="Codigo cliente" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtnombreclienteCita" class="col-md-4  control-label">Nombre:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtnombreclienteCita" runat="server" class="form-control" placeholder="Nombre cliente" Style="width:100%" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </fieldset>
                            <fieldset>
                            <legend style="font-size:14px">Datos de la mascota:</legend>
                            <div class="row">
                                
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtCodigoMascotaCita" class="col-md-4  control-label">Codigo:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCodigoMascotaCita" runat="server" class="form-control" placeholder="Codigo Mascota" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtnombreMascotaCita" class="col-md-4  control-label">Nombre:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtnombreMascotaCita" runat="server" class="form-control" placeholder="Nombre Mascota" Style="width:100%" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </fieldset>
                            
                            <div class="col-sm-12">
                        <div class="form-group">
                            <label for="buscar" class="col-md-4  control-label">
                            </label>
                            <div class="col-md-8">
                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscarCitaCita" style="width:30%" OnClick="btnBuscarCitaCita_Click"  />
                            </div>

                        </div>
                    </div>
                           
                            
                                <div class="col-sm-12">
                                    <div class="form-group">

                                        <div class="col-md-12">
                                            <asp:GridView
                                                ID="grvResultadoPopup" runat="server" AllowPaging="True"
                                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idCita" 
                                                CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" PageSize="7" Width="100%" 
                                                 OnRowCommand="grvResultadoPopup_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="NroCita" HeaderText="Codigo Cita">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DescripcionCita" HeaderText="Descripción Servicio" />
                                                    <asp:BoundField DataField="EstadoCita" HeaderText="Estado" />
                                                    <asp:BoundField DataField="ObservacionCliente" HeaderText="Observacion del Cliente" />
                                                      <asp:TemplateField HeaderText="Seleccionar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnVer" runat="server" AlternateText="Seleccionar" CausesValidation="false"  Visible='<%# Convert.ToBoolean(Eval("DescripcionCita")!="") %>'
                                                    CommandArgument='<%# Bind("NroCita") %>' CommandName="Seleccionar" ImageUrl="~/Content/Img/external.png" />
                                                <itemstyle width="5%" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>                                        
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            
                             </div>



                            <%--fin de contenido--%>
                       
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
    
    <%--Buscar Mascota--%>

        <div class="modal fade" id="myModalMasc" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <asp:UpdatePanel ID="upModalMasc" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitleMasc" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <%--contenido--%>
                            <fieldset>
                            <legend style="font-size:14px">Datos del Cliente:</legend>
                            <div class="row">
                                
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtCodigoClienteCita" class="col-md-4  control-label">Codigo:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCodigoClienteMasc" runat="server" class="form-control" placeholder="Codigo cliente" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtnombreclienteCita" class="col-md-4  control-label">Nombre:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtnombreclienteMasc" runat="server" class="form-control" placeholder="Nombre cliente" Style="width:100%" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </fieldset>
                            <fieldset>
                            <legend style="font-size:14px">Datos de la mascota:</legend>
                            <div class="row">
                                
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtCodigoMascotaCita" class="col-md-4  control-label">Codigo:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCodigoMascotaMasc" runat="server" class="form-control" placeholder="Codigo Mascota" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="txtnombreMascotaCita" class="col-md-4  control-label">Nombre:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtnombreMascotaMasc" runat="server" class="form-control" placeholder="Nombre Mascota" Style="width:100%" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </fieldset>
                            
                            <div class="col-sm-12">
                        <div class="form-group">
                            <label for="buscar" class="col-md-4  control-label">
                            </label>
                            <div class="col-md-8">
                                <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscarCitaMasc" style="width:30%"  OnClick="btnBuscarCitaMasc_Click"  />
                            </div>

                        </div>
                    </div>
                           
                            
                                <div class="col-sm-12">
                                    <div class="form-group">

                                        <div class="col-md-12">
                                            <asp:GridView
                                                ID="grvResultadoMascPopup" runat="server" AllowPaging="True"
                                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idCita" 
                                                CssClass="table table-bordered" HeaderStyle-CssClass="bg-primary" PageSize="7" Width="100%" 
                                                 OnRowCommand="grvResultadoMascPopup_RowCommand">
                                                <Columns>
                                                      <asp:BoundField DataField="NroCita" HeaderText="Codigo Cita">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                                    <asp:BoundField DataField="nombreMascota" HeaderText="Mascota" />
                                                      <asp:TemplateField HeaderText="Seleccionar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnVer" runat="server" AlternateText="Seleccionar" CausesValidation="false"  Visible='<%# Convert.ToBoolean(Eval("DescripcionCita")!="") %>'
                                                    CommandArgument='<%# Bind("CodMascota") %>' CommandName="Seleccionar" ImageUrl="~/Content/Img/external.png" />
                                                <itemstyle width="5%" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>                                        
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            
                             </div>



                            <%--fin de contenido--%>
                       
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
 
    
    <%--Alertas--%>
    <div class="modal fade" id="myModalError" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog" role="document">
            <asp:UpdatePanel ID="upModalError" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblErrorTitulo" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">

                             <asp:Label ID="lblError" runat="server" Font-Size="14px" ForeColor="Red"></asp:Label>
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
    
</asp:Content>
