<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraFinalizada.aspx.cs" Inherits="WEBZONE.CompraFinalizada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

                            
                             <asp:Label ID="Lbltelefono" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>
                           
                           
                            
                        </td>


                        <td>    

                            <asp:Label ID="Lblcp" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td>
                           
                            <asp:Label ID="LblMail" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                        <td>

                            <asp:Label ID="Lblcalle" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>


                        </td>
                    </tr>

                    <tr>
                       
                        <td></td>

                        <td>

                             <asp:Label ID="Lblaltura" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label>

                        </td>
                    </tr>

                     <tr>
                          <td></td>
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
                     
                        <td style="font-weight:bold;">Marca</td>
                        
                        <td style="font-weight:bold;">Tipo de Raza</td>
                        
                        <td style="font-weight:bold;">Cantidad Comprada</td>
                        <td style="font-weight:bold;">Precio unitario</td>
                    </tr>
                    <%foreach (var axv in Listado_compra)
                        {
                    %>

                    <tr>
                        
                        <td><% = axv.Nombre %></td>
                        
                        <td><% = axv.Marca%></td>
                        <td><% = axv.Raza%></td>
                        <td><% = axv.Cantidad %></td>
                        
                        <td><% = "$ "+ decimal.Round(axv.Precio, 2, MidpointRounding.AwayFromZero) %></td>

                        
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


    <asp:Button Text="Confirmar compra" runat="server" class="btn btn-success" OnClick="Confirmar_compra" />
    <asp:Button Text="Volver al paso anterior" runat="server" class="btn btn-primary" OnClick="Volver_pasoanterior" />
    <asp:Button Text="Cancelar" runat="server" class="btn btn-danger" OnClick="Cancelar_compra" />

  

  
</asp:Content>
