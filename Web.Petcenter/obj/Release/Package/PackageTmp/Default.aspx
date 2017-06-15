<%@ Page Title="Pagina Principal" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Petcenter.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
        <ul class="nav nav-pills">
            <li role="presentation" class="active"><a href="#">Intranet clínica Veterinaria Pet Center</a></li>
            <li role="presentation"><a href="http://www.petcenter.com.pe/" target="_blank">Página web</a></li>

        </ul>
        <h2></h2>
        <p>PET CENTER es la primera cadena importante de veterinarias del Perú, Fue fundada en el año 2000 contamos con 13 clínicas bien ubicadas en los distritos de: Surco, La Molina, Miraflores, San Borja, Chorrillos, Pachamac Y Lurín. Gracias al esfuerzo de nuestros trabajadores PET CENTER hoy en día es reconocida como la mejor opción Veterinaria. Contamos con un staff de Médicos Veterinarios especializados en diferentes áreas de medicina, personal y auxiliar y una excelente atención de nuestras counter.</p>
        <p>
            <img src="Content/Img/966940.jpg" />
        </p>

    </div>

    <div class="alert alert-success" role="alert">
        Para mas referencia de los componentes que se van a usar leer: <a href="http://getbootstrap.com/components/" class="alert-link" target="_blank">Documentacion de componentes de bootstrap</a>.
    </div>

</asp:Content>
