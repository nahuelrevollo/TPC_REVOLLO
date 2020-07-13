<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Modif_Raza.aspx.cs" Inherits="WEBZONE.Modif_Raza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    
    <h1>Modificar Razas </h1>

      

  <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                       

                      <td style="font-weight:bold;">Nombre</td>
                       
                        
                    </tr>
                    <%foreach (var mod_art in Listado_Razas)                    
                      
                        {%>
                          
                    <tr>                       
                        
                        <td style="justify-content:center"><% = mod_art.Descripcion %></td>
                      
                       
                        <td><a href="Raza_Modificada.aspx?idModificar=<% = mod_art.ID.ToString() %>" class="btn btn-primary">Modificar</a></td>
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>


      </div>





</asp:Content>
