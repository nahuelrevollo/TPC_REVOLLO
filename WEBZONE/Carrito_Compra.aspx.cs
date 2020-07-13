using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO_DTO;
using NEGOCIO_BL;
namespace WEBZONE
{
    public partial class Carrito_Compra : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        public List<Carrito> Listado_compra { get; set; }
        public List<Articulo> Listado_articulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal total_compra = 0;
            int cant_total = 0;

            usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

            if (usuario != null)

            {


                try
                {

               

                    if (Session[Session.SessionID + "Listado_compra"] != null)
                        Listado_compra = (List<Carrito>)Session[Session.SessionID + "Listado_compra"];

                    Listado_articulos = (List<Articulo>)Session[Session.SessionID + "Lista_art"];

                    var Quitar_compra = Request.QueryString["idquitar"];


                    if (Quitar_compra != null)
                    {
                        Carrito compra = Listado_compra.Find(J => J.ID == int.Parse(Quitar_compra));

                        if (compra.Cantidad == 1 /*&& cant_total == 1*/)

                        {

                            Listado_compra.Remove(compra);
                            Session[Session.SessionID + "Listado_compra"] = Listado_compra;

                           

                           



                        }
                        else
                        {


                            foreach (var item in Listado_compra)

                            {
                                if (compra.ID == item.ID)
                                {
                                    item.Cantidad--;
                                    
                                    
                                }


                            }
                        }


                    }

                    else if (Request.QueryString["idcompra"] != null)
                    {

                        List<Articulo> art_list = (List<Articulo>)Session[Session.SessionID + "Lista_art"];

                        var Art_select = Convert.ToInt32(Request.QueryString["idcompra"]);


                        Articulo art_comprado = art_list.Find(J => J.ID == Art_select);

                        Carrito compra = new Carrito();

                        compra.ID = art_comprado.ID;
                        compra.Nombre = art_comprado.Nombre;
                        compra.Marca = art_comprado.Marca.Descripcion;
                        compra.Raza = art_comprado.Raza.Descripcion;
                        compra.Codigo = art_comprado.Codigo;
                        compra.Imagen_Url = art_comprado.Imagen_Url;
                        compra.Precio = art_comprado.Precio.PrecioVenta;
                        compra.Cantidad = 1;

                        if (Listado_compra == null)
                            Listado_compra = new List<Carrito>();

                        Carrito var_1 = Listado_compra.Find(j => j.ID == Art_select);

                        if (var_1 == null)

                        {

                            Listado_compra.Add(compra);
                            Session[Session.SessionID + "Listado_compra"] = Listado_compra;

                            
                           

                        }
                        else
                        {


                            foreach (var item in Listado_compra)

                            {
                                if (Art_select == item.ID)
                                {
                                    item.Cantidad++;

                                   
                                   
                                }


                            }
                        }


                    }

                    if (Listado_compra != null)
                    {

                        foreach (var Item_compra in Listado_compra)
                        {

                            decimal t_aux = Item_compra.Cantidad * Item_compra.Precio;
                            total_compra += t_aux;

                            cant_total += Item_compra.Cantidad;


                        }

                    }


                    LblMontototal.Text = "Monto total de compra: $ " + Convert.ToString(total_compra);
                    Session[Session.SessionID + "Total_Compra"] = total_compra;
                    Session[Session.SessionID + "Cantidad_carrito"] = cant_total;

                }
                catch (Exception ex)
                {
                    Session["Error" + Session.SessionID] = "Aun no tenes favoritos";
                    Response.Redirect("Error");
                }
            }

            else
            {

                Response.Redirect("DefaultExpiroSesion");


            }
        }
    }
}