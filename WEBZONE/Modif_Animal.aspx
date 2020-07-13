<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Modif_Animal.aspx.cs" Inherits="WEBZONE.Modif_Animal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <h1>Modificar Tipo de Animales </h1>

      

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
                      
                       
                        <td><a href="Animal_Modificado.aspx?idModificar=<% = mod_art.ID.ToString() %>" class="btn btn-primary">Modificar</a></td>
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>





</asp:Content>
