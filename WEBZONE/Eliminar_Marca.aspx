﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Eliminar_Marca.aspx.cs" Inherits="WEBZONE.Eliminar_Marca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
    <h1>Eliminar Marca </h1>

      

  <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                       

                      <td style="font-weight:bold;">Nombre</td>
                       
                        
                    </tr>
                    <%foreach (var mod_art in Listado_Marcas)                    
                      
                        {%>
                          
                    <tr>                       
                        
                        <td style="justify-content:center"><% = mod_art.Descripcion %></td>
                      
                       
                        <td><a href="Eliminar_Marca.aspx?idEliminar=<% = mod_art.ID.ToString() %>" class="btn btn-primary">Eliminar</a></td>
                    </tr>


                    <% } %>
                </table>

                

            </div>

        </div>


      </div>



</asp:Content>
