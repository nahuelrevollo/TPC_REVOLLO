<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="MisVentas.aspx.cs" Inherits="WEBZONE.MisVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>Reporte del Mes </h1>

      

  <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                                               
                        
                        <td style="font-weight:bold;">Año</td>
                        <td style="font-weight:bold;">Mes</td>
                        <td style="font-weight:bold;">Ventas del mes</td>
                        <td style="font-weight:bold;">Envios realizados</td>
                        <td style="font-weight:bold;">Retiros por el local</td>
                        <td style="font-weight:bold;">Total Vendido</td>
                       
                    </tr>
                    

                    <tr>
                        

                        
                        <td><asp:Label ID="LblAño" runat="server"  Font-Bold="true"></asp:Label></td>

                        <td><asp:Label ID="LblMes" runat="server" Font-Bold="true"></asp:Label></td>


                        <td><asp:Label ID="LblVentames" runat="server" Font-Bold="true"></asp:Label></td>

                        <td><asp:Label ID="LblEnvios_mes" runat="server" Font-Bold="true"></asp:Label></td>

                        <td><asp:Label ID="LblRetirosmes" runat="server" Font-Bold="true"></asp:Label></td>


                        <td><asp:Label ID="LblTotalmes" runat="server"  Font-Bold="true"></asp:Label></td>

                       
                    </tr>


                    
                </table>

            </div>

        </div>


      </div>

    <h1>Todas mis Ventas </h1>

      

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
                        <td> <% = + decimal.Round(mis_comp.Total, 2, MidpointRounding.AwayFromZero) %></td>                        
                        <td><% = mis_comp.Estado %></td>
                       
                        

                        <td><a href="DetalleVenta_Admin.aspx?idventa=<% = mis_comp.IDventa.ToString() %>" class="btn btn-primary">Detalle</a></td>
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>



</asp:Content>
