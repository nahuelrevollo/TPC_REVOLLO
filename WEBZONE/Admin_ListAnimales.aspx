<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Admin_ListAnimales.aspx.cs" Inherits="WEBZONE.Admin_ListAnimales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <h1>Listado de Animales </h1>

      <div>

        <a href="Administrador.aspx"class="btn btn-primary">Volver a menu principal </a>
    </div>

  <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                       

                      <td style="font-weight:bold;">Nombre</td>
                       
                        
                    </tr>
                    <%foreach (var mod_art in Listado_Animales)                    
                      
                        {%>
                          
                    <tr>                       
                        
                        <td style="justify-content:center"><% = mod_art.Descripcion %></td>
                      
                       
                        
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>



</asp:Content>
