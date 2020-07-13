<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Perfil_Admin.aspx.cs" Inherits="WEBZONE.Perfil_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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

                    <tr>
                        <td><a href="Modif_DatosAdmin.aspx" class="btn btn-primary">Modificar Datos Personales</a>

                             <a href="Administrador.aspx" class="btn btn-danger">Pagina Principal</a>

                        </td>

                    </tr>
                   
                </table>

            </div>
        </div>

      </div>

     


</asp:Content>
