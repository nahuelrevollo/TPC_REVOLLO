<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Modif_Articulo.aspx.cs" Inherits="WEBZONE.Modif_Articulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h1>Modificar Articulo </h1>

      

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

                        <td><a href="Articulo_Modificado.aspx?idModificar=<% = mod_art.ID.ToString() %>" class="btn btn-primary">Modificar</a></td>
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>





</asp:Content>
