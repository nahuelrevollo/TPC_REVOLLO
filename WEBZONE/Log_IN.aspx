<%@ Page Title="" Language="C#" MasterPageFile="~/Bienvenida_logIng.Master" AutoEventWireup="true" CodeBehind="Log_IN.aspx.cs" Inherits="WEBZONE.Log_IN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Inicio de sesion </h1>


     <div class="container">
        <div class="row mt-4">
            <div class="col-4 offset-4">
                <div class="form-group">
                    <label>Usuario</label>
                    <asp:TextBox runat="server" ID="nickname_u" CssClass="form-control mb-3" required=""/>
                  <%--  <asp:RegularExpressionValidator ErrorMessage="Ingrese un Email valido!" ControlToValidate="nickname_u" CssClass="alert alert-danger mt-4" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />--%>
                </div>
                <div class="form-group">
                    <label>Contraseña</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="password_u" TextMode="Password" required="" />
                </div>
                    <%--<div class="form-check mb-3">
                        <asp:CheckBox CssClass="form-check-input" runat="server" ID="chkBoxVerContraseña" OnCheckedChanged="chkBoxVerContraseña_CheckedChanged" AutoPostBack="true" />
                        <asp:Label Text="Ver Contraseña" CssClass="form-check-label" runat="server" />
                    </div>--%>
                <asp:Button Text="Iniciar Sesion" ID="btnIniciarSesion" CssClass="btn btn-primary" runat="server" OnClick="BtnAceptar_Click" />
                <div class="form-group">
                    <div class="row mt-2">
                        <div class="col">
                            <a href="Registro_Usuario.aspx" class="">No tengo Cuenta</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    
    <div class="modal fade" id="modalErrorLogin" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text="">Error!</asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" runat="server" Text="">Usuario o Clave incorrectos</asp:Label>
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
