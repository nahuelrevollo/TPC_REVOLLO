<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modif_DatosPersonales.aspx.cs" Inherits="WEBZONE.Modif_DatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

      <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Modificar datos personales</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                       
                        <div class="row">
                            <label class="form-check-label text-dark">Nombre:</label>
                            <asp:TextBox ID="nombre_u" CssClass="form-control btn-secondary" runat="server" required=""/>
<asp:RegularExpressionValidator ErrorMessage="No puede contener numeros!" ControlToValidate="nombre_u" CssClass="alert alert-danger" runat="server" ValidationExpression="^[a-zA-Z ]*$" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Apellido:</label>
                            <asp:TextBox ID="apellido_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            <asp:RegularExpressionValidator ErrorMessage="No puede contener numeros!" ControlToValidate="apellido_u" CssClass="alert alert-danger" runat="server" ValidationExpression="^[a-zA-Z ]*$" />
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Pais:</label>
                            <asp:DropDownList ID="Lista_Paises" AutoPostBack="true"  CssClass="form-control btn-secondary" runat="server" OnSelectedIndexChanged="Pais_selecccionado"  />


                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Provincia:</label>
                            <asp:DropDownList ID="Lista_Provincia" CssClass="form-control btn-secondary" runat="server" />
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Nombre de usuario:</label>
                            <asp:TextBox ID="nickname_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            
                            <div class="row">
                    <asp:Label Text="" Visible="false" CssClass="alert alert-danger ml-1 mt-1" ID="lblNickExistente" runat="server" />
                </div>
                        </div>

                        
                        <div class="row">
                            <label class="form-check-label text-dark">Dni:</label>
                            <asp:TextBox type="number" ID="dni_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            <asp:RegularExpressionValidator runat="server" CssClass="alert alert-danger" ControlToValidate="dni_u" Display="Dynamic" ErrorMessage="DNI invalido" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Sexo:</label>
                            <asp:TextBox ID="sexo_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            <small class="form-text text-muted">Solo ingresar M,F u O.</small>
                            <asp:RegularExpressionValidator  ErrorMessage="Sin caracteres especiales!" ControlToValidate="sexo_u" CssClass="alert alert-danger mt-4" runat="server" ValidationExpression="[0-9a-zA-Z #,-]+" />
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Fecha de nacimiento:</label>
                            <asp:TextBox Type="date" ID="fechanac_u" CssClass="form-control btn-secondary" runat="server" required="" />
                     
                        </div>


                        <div class="row">
                            <label class="form-check-label text-dark">Email:</label>
                            <asp:TextBox ID="mail_u" CssClass="form-control btn-secondary" runat="server"  require=""/>
                            <asp:RegularExpressionValidator ErrorMessage="Ingrese un Email valido!" ControlToValidate="mail_u" CssClass="alert alert-danger mt-4" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

                            <div class="row">
                    <asp:Label Text="" Visible="false" CssClass="alert alert-danger ml-1 mt-1" ID="lblEmailExistente" runat="server" />
                </div>
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Telefono:</label>
                            <asp:TextBox Type="number" ID="telefono_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            <asp:RegularExpressionValidator runat="server" CssClass="alert alert-danger" ControlToValidate="telefono_u" Display="Dynamic" ErrorMessage="Solo numeros" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </div>



                    </div>

                    <asp:Button Text="Modificar" runat="server" class="btn btn-success" OnClick="Btn_ModificarDP"/>
                        <a href="Perfil_Usuario.aspx" class="btn btn-danger">Cancelar</a>
                </div>
                </div>
            </div>
        </div>

   
            




     <div class="modal fade" id="Modal_Modif_DPu" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">Modificacion con exito!</asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="">Vuelve a tu perfil para ver los cambios</asp:Label>
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
