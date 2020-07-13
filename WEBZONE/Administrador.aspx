<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MP.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="WEBZONE.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        

     <div class="container">
        <div class="row mt-4">
            <div class="col-4 offset-4">
                <div class="form-group">
                    
             <div class="dropdown" style="text-align:center">
                     <h1>Bienvenido!! </h1>
    <h2>Menu:</h2>
  <button class="btn btn-primary dropdown-toggle" style="text-align:center" type="button" id="dropAltas" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Altas
  </button>
  <div class="dropdown-menu" aria-labelledby="dropAltas">
    
       <a class="dropdown-item" href="Registro_Admin.aspx">Nuevo Administrador</a>
       <a class="dropdown-item" href="Nuevo_Articulo.aspx">Nuevo Articulo</a>
    <a class="dropdown-item" href="Nueva_Marca.aspx">Nueva Marca</a>
    <a class="dropdown-item" href="Nuevo_Animal.aspx">Nuevo tipo de animal</a>
    <a class="dropdown-item" href="Nuevo_Edades.aspx">Nuevo tipo de edades</a>
    <a class="dropdown-item" href="Nueva_Raza.aspx">Nuevo tipo de raza</a>

  </div>
</div>


                    
                </div>
                <div class="form-group">
                  

                                
             <div class="dropdown" style="text-align:center">
  <button class="btn btn-primary dropdown-toggle" style="text-align:center" type="button" id="dropmodificar" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Modificar
  </button>
  <div class="dropdown-menu" aria-labelledby="dropmodificar">
    
    <a class="dropdown-item" href="Modif_Articulo.aspx">Modificar Articulo</a>
    <a class="dropdown-item" href="Modif_Marca.aspx">Modificar Marca</a>
    <a class="dropdown-item" href="Modif_Animal.aspx">Modificar animal</a>
    <a class="dropdown-item" href="Modif_Edades.aspx">Modificar edades</a>
    <a class="dropdown-item" href="Modif_Raza.aspx">Modificar raza</a>

  </div>


  </div>

  </div>

                <div class="form-group">

                      <div class="dropdown" style="text-align:center">
  <button class="btn btn-primary dropdown-toggle" style="text-align:center" type="button" id="dropbajas" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Bajas
  </button>
  <div class="dropdown-menu" aria-labelledby="dropbajas">
    
    <a class="dropdown-item" href="Eliminar_Articulo.aspx">Eliminar Articulo</a>
    <a class="dropdown-item" href="Eliminar_Marca.aspx">Eliminar Marca</a>
    <a class="dropdown-item" href="Eliminar_Animal.aspx">Eliminar Animal</a>
    <a class="dropdown-item" href="Eliminar_Edades.aspx">Eliminar Edades</a>
    <a class="dropdown-item" href="Eliminar_Raza.aspx">Eliminar Raza</a>

  </div>
</div>


                    </div>
                    
                <div class="form-group">
                    <div class="row mt-2">
                        <div class="col">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

























</asp:Content>
