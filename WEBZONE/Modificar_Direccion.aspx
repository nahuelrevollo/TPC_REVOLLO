<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modificar_Direccion.aspx.cs" Inherits="WEBZONE.Modificar_Direccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

    
     <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Nueva Direccion</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

            <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label text-dark">Pais:</label>
                            <asp:DropDownList ID="Lista_Paises" AutoPostBack="true"  CssClass="form-control btn-secondary" runat="server" OnSelectedIndexChanged="Pais_selecccionado"  />


                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Provincia:</label>
                            <asp:DropDownList ID="Lista_Provincia" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Localidad:</label>
                            <asp:TextBox ID="localidad_u" CssClass="form-control btn-secondary" runat="server" required=""/>
                          <asp:RegularExpressionValidator ErrorMessage="No puede contener numeros!" ControlToValidate="localidad_u" CssClass="alert alert-danger" runat="server" ValidationExpression="^[a-zA-Z ]*$" />
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">CP:</label>
                            <asp:TextBox type="numbre" ID="cp_u" CssClass="form-control btn-secondary" runat="server" />
                            <asp:RegularExpressionValidator runat="server" CssClass="alert alert-danger" ControlToValidate="cp_u" Display="Dynamic" ErrorMessage="Solo numeros" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Calle:</label>
                            <asp:TextBox ID="calle_u" CssClass="form-control btn-secondary" runat="server" required=""/>
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Altura:</label>
                            <asp:TextBox type="numbre" ID="altura_u" CssClass="form-control btn-secondary" runat="server" />
                            <asp:RegularExpressionValidator runat="server" CssClass="alert alert-danger" ControlToValidate="altura_u" Display="Dynamic" ErrorMessage="Solo numeros" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Entre calle 1:</label>
                            <asp:TextBox ID="entrecalle1_u" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Entre calle 2:</label>
                            <asp:TextBox ID="entrecalle2_u" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                        </div>
                        
                    </div>
                </div>
                      <asp:Button Text="Guardar" runat="server" class="btn btn-success" OnClick="Guardar_Direccion" />
                      
                        <a href="Perfil_Usuario.aspx" class="btn btn-danger">Cancelar</a>
            

            </div>
    
        </div>
  
         

     <div class="modal fade" id="modalNuevaDireccion" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">Direccion agregada con exito!</asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="">Datos correctos, continua para finalizar</asp:Label>
                        </div>
                        <div class="modal-footer">
                            <a href="Perfil_Usuario.aspx" class="btn btn-info">Continuar</a>
                          
                        </div>
                    </div>
                </ContentTemplate>


            </asp:UpdatePanel>
        </div>
    </div>


    

        




</asp:Content>
