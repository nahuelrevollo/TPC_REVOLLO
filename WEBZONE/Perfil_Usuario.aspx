<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil_Usuario.aspx.cs" Inherits="WEBZONE.Perfil_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Mi Perfil</h1>

    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                       <td style="font-weight:bold;">Datos Personales</td>                     
                                               
              
                    </tr>                  

                    <tr>
                        <td><asp:Label ID="Lblnombre" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label> </td>
                                           
                    </tr>
                    <tr>
                        <td><asp:Label ID="Lblapellido" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="Lblpais" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="Lblprovincia" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="Lblnickname" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="LblDni" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>

                     <tr>
                        <td><asp:Label ID="LblMail" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>
                     <tr>
                        <td><asp:Label ID="Lbltelefono" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="Lblfecha_nac" runat="server" style="margin-right:400px" Font-Bold="true"></asp:Label></td>

                    </tr>
                   
                </table>

            </div>
        </div>

      </div>

     <a href="Modif_DatosPersonales.aspx" class="btn btn-primary">Modificar Datos Personales</a>


    <h3 style="font-weight:bold;">Mis Direciones</h3>

     <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                                             
                        
                        <td style="font-weight:bold;">Pais</td>
                        <td style="font-weight:bold;">Provincia</td>
                        <td style="font-weight:bold;">Localidad</td>
                        <td style="font-weight:bold;">Codigo Postal</td>
                        <td style="font-weight:bold;">Calle</td>
                        <td style="font-weight:bold;">Altura</td>
                        <td style="font-weight:bold;">Entre calle 1</td>
                        <td style="font-weight:bold;">Entre calle 2</td>
                      

                        
                    </tr>
                    <%foreach (var direccion in Listado_Direcciones)
                        {%>

                    <tr>
                                                
                        <td><% =direccion.Pais %></td>
                        <td><% =direccion.Provincia.Descripcion %></td>
                        <td><% =direccion.Localidad %></td>
                        <td><% =direccion.CP %></td>
                        <td><% =direccion.Calle %></td>
                        <td><% =direccion.Altura %></td>
                        <td><% =direccion.Entrecalle1 %></td>
                        <td><% =direccion.Entrecalle2 %></td>
                        
                        

                        <td><a href="Perfil_Usuario.aspx?id_eliminar=<% = direccion.ID.ToString() %>" class="btn btn-danger">Eliminar</a></td>
                        <td><a href="Modificar_Direccion.aspx?id_modificar=<% = direccion.ID.ToString() %>" class="btn btn-warning">Modificar</a></td>
                        

                    </tr>


                    <% } %>
                </table>

            </div>

        </div>

        <a href="Perfil_NuevaDireccion.aspx" class="btn btn-primary">Agregar Nueva Direccicon</a>
        
        

      </div>








</asp:Content>
