<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Articulo_Modificado.aspx.cs" Inherits="WEBZONE.Articulo_Modificado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    
     <h1 class="text-dark" style="margin-left: 50px; margin-top: 20px;"> Modificar Articulo</h1>
    <div class="row" style="margin-left: 500px;">
        <div class="col-md-12">

            <div class="row col-center">

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                       
                        <div class="row">
                            <label class="form-check-label text-dark">Codigo:</label>
                            <asp:TextBox ID="codigo_art" CssClass="form-control btn-secondary" runat="server" required=""/>

                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Nombre:</label>
                            <asp:TextBox ID="nombre_art" CssClass="form-control btn-secondary" runat="server" required="" />
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Stock:</label>
                            <asp:TextBox ID="stock_art" CssClass="form-control btn-secondary" runat="server" required="" />
                        </div>



                        <div class="row">
                            <label class="form-check-label text-dark">Descripcion:</label>
                            <asp:TextBox ID="descripcion_art" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Precio de venta:</label>
                            <asp:TextBox ID="precioV_art" CssClass="form-control btn-secondary" runat="server" required="" />
                        </div>

                        <div class="row">
                            <label class="form-check-label text-dark">Precio de venta:</label>
                            <asp:TextBox ID="precioU_art" CssClass="form-control btn-secondary" runat="server" required="" />
                        </div>


                    </div>
                </div>

                <div class="row">
                    <div class="row col-md-10 form-check" style="margin: 30px;">

                        <div class="row">
                            <label class="form-check-label text-dark">Marca:</label>
                            <asp:DropDownList ID="Lista_Marca"  CssClass="form-control btn-secondary" runat="server"    />


                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Raza:</label>
                            <asp:DropDownList ID="Lista_Raza" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Imagen:</label>
                            <asp:TextBox ID="imagen_art" CssClass="form-control btn-secondary" runat="server" />
                            <asp:RegularExpressionValidator ErrorMessage="Solo ingresar URL" ControlToValidate="imagen_art"  runat="server" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" ></asp:RegularExpressionValidator>
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Edad:</label>
                            <asp:DropDownList ID="Lista_Edad" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        <div class="row">
                            <label class="form-check-label text-dark">Animal:</label>
                            <asp:DropDownList ID="Lista_Animal" CssClass="form-control btn-secondary" runat="server" />
                        </div>
                        

                        </div>
                        
                    </div>
                </div>
                      <asp:Button Text="Modificar" runat="server" class="btn btn-success" OnClick="Btn_ModificarArticulo"/>
                        <a href="Modif_Articulo.aspx" class="btn btn-danger">Cancelar</a>
            

            </div>
    
        </div>
  

</asp:Content>
