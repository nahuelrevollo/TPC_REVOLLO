<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Direccion_Envio.aspx.cs" Inherits="WEBZONE.Direccion_Envio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Confirme direccion de envio</h1>


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
                        
                        

                        <td><a href="CompraFinalizada.aspx?id_Direc_select=<% = direccion.ID.ToString() %>" class="btn btn-primary">Seleccionar</a></td>
                    </tr>


                    <% } %>
                </table>

            </div>

        </div>

        <a href="Nueva_Direccion.aspx" class="btn btn-primary">Agregar Nueva Direccicon</a>
        <asp:Button Text="Retirar por el local" runat="server" class="btn btn-success" OnClick="Retira_Local" />
        

      </div>


    


</asp:Content>
