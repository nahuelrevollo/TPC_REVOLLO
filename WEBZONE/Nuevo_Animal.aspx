﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Nuevo_Animal.aspx.cs" Inherits="WEBZONE.Nuevo_Animal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    
    
     <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;">Nuevo tipo de animal</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label text-dark">Nombre:</label>
                            <asp:TextBox ID="nombre_animal" CssClass="form-control btn-secondary" runat="server" required=""/>
                       

                      
                    </div>
                        </div>
                </div>

                </div>
                      <asp:Button Text="Guardar" runat="server" class="btn btn-success" OnClick="Btn_GuardarAnimal" />
                        <a href="Administrador.aspx" class="btn btn-danger">Cancelar</a>
            

            </div>
    
        </div>








</asp:Content>
