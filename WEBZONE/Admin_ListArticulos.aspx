<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Admin_ListArticulos.aspx.cs" Inherits="WEBZONE.Admin_ListArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <h1>Listado de Articulos </h1>
    <div>

        <a href="Administrador.aspx"class="btn btn-primary">Volver a menu principal </a>
    </div>
      

  <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                        <td></td>                        
                        
                        <td style="font-weight:bold;">Nombre</td>
                        <td style="font-weight:bold;">Stock</td>
                        <td style="font-weight:bold;">Descripcion</td>
                        <td style="font-weight:bold;">Marca</td>
                        <td style="font-weight:bold;">Raza</td>
                        <td style="font-weight:bold;">Edad</td>
                        <td style="font-weight:bold;">Animal</td>
                        <td style="font-weight:bold;">Precio</td>
                        <td style="font-weight:bold;">Precio Unitario</td>
                    </tr>
                    <%foreach (var mod_art in Listado_articulos)
                        {%>

                    <tr>
                        <td> <img src="<%=mod_art.Imagen_Url%>" style="max-height: 50px; max-width: 50px;"></td>

                        
                        <td><% = mod_art.Nombre %></td>
                        <td><% = mod_art.Precio.Stock %></td>
                        <td><% = mod_art.Descripcion %></td>
                        <td><% = mod_art.Marca %></td>
                        <td><% = mod_art.Raza %></td>
                        <td><% = mod_art.Edad %></td>
                        <td><% = mod_art.Animal %></td>
                        
                        <td><% = "$"+ decimal.Round(mod_art.Precio.PrecioVenta, 2, MidpointRounding.AwayFromZero) %></td>
                        <td><% = "$"+ decimal.Round(mod_art.Precio.PrecioCompra, 2, MidpointRounding.AwayFromZero) %></td>

                       
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>






</asp:Content>
