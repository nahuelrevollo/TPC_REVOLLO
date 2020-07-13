<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras_Usuario.aspx.cs" Inherits="WEBZONE.Compras_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Mis Compras </h1>

      

  <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                                             
                        
                        <td style="font-weight:bold;">Codigo Compra</td>
                        <td style="font-weight:bold;">Fecha de compra</td>
                        <td style="font-weight:bold;">Cantidad de comprada</td>
                        <td style="font-weight:bold;">Total de compra</td>
                        <td style="font-weight:bold;">Estado</td>
                        
                    </tr>
                    <%foreach (var mis_comp in Listado_miscompras)
                        {%>

                    <tr>
                        

                        
                        <td><% = mis_comp.IDventa %></td>
                        <td><% = mis_comp.Fecha_Venta.ToShortDateString() %></td>
                        <td><% = mis_comp.Cantidadvendida %></td>
                        <td><% = "$"+ decimal.Round(mis_comp.Total, 2, MidpointRounding.AwayFromZero) %></td>                        
                        <td><% = mis_comp.Estado %></td>
                       
                        

                        <td><a href="Detalle_Compra.aspx?idventa=<% = mis_comp.IDventa.ToString() %>" class="btn btn-primary">Detalle</a></td>
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>




</asp:Content>
