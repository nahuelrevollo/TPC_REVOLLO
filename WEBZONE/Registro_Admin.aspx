<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Registro_Admin.aspx.cs" Inherits="WEBZONE.Nuevo_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

    
     <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;"> Registratar nuevo administrador</h1>
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
                            <label class="form-check-label text-dark">Nombre de usuario:</label>
                            <asp:TextBox ID="nickname_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            
                            <div class="row">
                    <asp:Label Text="" Visible="false" CssClass="alert alert-danger ml-1 mt-1" ID="lblNickExistente" runat="server" />
                </div>
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Contraseña:</label>
                            <asp:TextBox Type="password" ID="password_u" CssClass="form-control btn-secondary" runat="server" required="" />
                            <small class="form-text text-muted">Debe tener entre 4-6 caracteres con letras y numeros.</small>
                <asp:RegularExpressionValidator ErrorMessage="Clave invalida!" ControlToValidate="password_u" CssClass="alert alert-danger" runat="server" ValidationExpression="^(?=.*\d).{4,6}$" />
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



                    </div>
                </div>

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">


                        
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


                        <div class="row">
                            <label class="form-check-label text-dark">Pais:</label>
                            <asp:DropDownList ID="Lista_Paises" AutoPostBack="true"  CssClass="form-control btn-secondary" runat="server" OnSelectedIndexChanged="Pais_selecccionado"  />


                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Provincia:</label>
                            <asp:DropDownList ID="Lista_Provincia" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        
                        </div>
                        
                    </div>
                </div>
                      <asp:Button Text="Guardar" runat="server" class="btn btn-success" OnClick="Guardar_Usuario" />
                        <a href="Administrador.aspx" class="btn btn-danger">Cancelar</a>
            

            </div>
    
        </div>
  
         

     <div class="modal fade" id="modalNuevoAdmin" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">Administrador creado con exito!</asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="">Inicia sesion para empezar</asp:Label>
                        </div>
                        <div class="modal-footer">
                            <a href="Admin_ListAdmin.aspx" class="btn btn-info">Continuar</a>
                          
                        </div>
                    </div>
                </ContentTemplate>


            </asp:UpdatePanel>
        </div>
    </div>


    
                <div class="modal fade" id="modalErrorForm" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="">Error!</asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="Label2" runat="server" Text="">Debés completar todos los campos antes de continuar.</asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>



</asp:Content>
