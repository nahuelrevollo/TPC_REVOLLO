<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Descripcion.aspx.cs" Inherits="WEBZONE.Descripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Detalle de articulo </h1>

    <div class="card" style="width: 25%">
            <img src="<% = articulo.Imagen_Url%>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><% = articulo.Nombre %></h5>
                <h6 class="card-title"><%=articulo.Marca.Descripcion %></h6>
                <p class="card-text"><% = articulo.Descripcion %></p>
                <p class="card-text"><% = "$ "+ decimal.Round(articulo.Precio.PrecioVenta, 2, MidpointRounding.AwayFromZero) %>  </p>
                <a  href="Listado_Articulos.aspx" class="btn btn-primary" >Regresar</a>
                <a  href="Carrito_Compra.aspx?idcompra=<% =articulo.ID.ToString()%>" class="btn btn-primary">Agregar al carrito</a>

                
            </div>
        </div>


</asp:Content>
