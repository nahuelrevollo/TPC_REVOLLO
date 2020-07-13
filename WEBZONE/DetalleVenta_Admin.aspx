<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="DetalleVenta_Admin.aspx.cs" Inherits="WEBZONE.DetalleVenta_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Detalle compra</h1>

    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                       <td style="font-weight:bold;">Datos del Usuario</td>                     
                       <td style="font-weight:bold;">Direccion de envio</td>                     
                                               
              
                    </tr>                  

                    <tr>
                        <td>
                            <asp:Label ID="Lblnombre" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>
                                           

                        </td>

                        <td>

                            <asp:Label ID="Lblpais" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                                           
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Lblapellido" runat="server" style="margin-right:400px" Font-Bold="true"> </asp:Label>    

                        </td>
                        <td>

                            <asp:Label ID="Lblprovincia" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>


                        </td>


                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Lblnickname" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>



                        </td>

                        <td>


                            <asp:Label ID="Lbllocalidad" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>


                    </tr>
                     
                    <tr>
                        <td>

                            

                            <asp:Label ID="Lblfecha_nac" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>
                           
                            
                        </td>


                        <td>    

                            <asp:Label ID="Lblcp" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LblDni" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>
                            

                        </td>
                        <td>

                            <asp:Label ID="Lblcalle" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>


                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Lbltelefono" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>
                        </td>
                        <td>

                             <asp:Label ID="Lblaltura" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                    </tr>

                     <tr>
                        <td>

                            <asp:Label ID="LblMail" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                         <td>

                            <asp:Label ID="Lblentrecalle1" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                         </td>
                    </tr>
                     <tr>
                        <td>


                        </td>
                         <td>

                            <asp:Label ID="Lblentrecalle2" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                         </td>
                    </tr>

                    
                   
                </table>

            </div>
        </div>

      </div>

  

    
    <h3>ARTICULOS COMPRADOS</h3>
      <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                        
                        <td style="font-weight:bold;">Nombre</td>
                        <td style="font-weight:bold;">Descripcion</td>
                        <td style="font-weight:bold;">Marca</td>
                        <td style="font-weight:bold;">Tipo de animal</td>
                        <td style="font-weight:bold;">Tipo de Raza</td>
                        <td style="font-weight:bold;">Tipo de Edades</td>
                        <td style="font-weight:bold;">Cantidad Comprada</td>
                        <td style="font-weight:bold;">Precio unitario</td>
                    </tr>
                    <%foreach (var axv in Listado_axv)
                        {
                    %>

                    <tr>
                        
                        <td><% = axv.Nombre %></td>
                        <td><% = axv.Descripcion %></td>
                        <td><% = axv.Marca.Descripcion %></td>
                        <td><% = axv.Animal.Descripcion %></td>
                        <td><% = axv.Raza.Descripcion %></td>
                        <td><% = axv.Edad.Descripcion %></td>
                        <td><% = axv.Precio.Stock %></td>
                        <td><% = "$ "+ decimal.Round(axv.Precio.PrecioVenta, 2, MidpointRounding.AwayFromZero) %></td>

                        
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>
    </div>
    <div >
        </div>

    <div>

    <asp:Label ID="LblMontototal" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>
    
    </div>
    <div>
        <asp:Label ID="LblCant_total" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

    </div>

    <a href="MisVentas.aspx" class="btn btn-warning">Volver a mis ventas</a>
    <a href="Administrador.aspx" class="btn btn-danger">Pagina Principal</a>

  

</asp:Content>
