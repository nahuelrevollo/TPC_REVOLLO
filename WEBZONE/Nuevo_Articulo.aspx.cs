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
    public partial class Nuevo_Articulo : System.Web.UI.Page
    {

        public Articulo articulo { get; set; }

        public PrecioyStock pys { get; set; }

        public List<Raza> raza { get; set; }
        public List<Marca> marcas { get; set; }
        public List<Edades> edades { get; set; }
        public List<Animal> animales { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    if (!IsPostBack)
                    {

                        BL_Raza Raza_Negocio = new BL_Raza();
                        raza = Raza_Negocio.Listar();
                        Lista_Raza.DataSource = raza;
                        Lista_Raza.DataBind();
                        Lista_Raza.DataTextField = "Descripcion";
                        Lista_Raza.DataValueField = "Id";
                        Lista_Raza.DataBind();

                        BL_Marca marcaNegocio = new BL_Marca();
                        marcas = marcaNegocio.Listar();
                        Lista_Marca.DataSource = marcas;
                        Lista_Marca.DataBind();
                        Lista_Marca.DataTextField = "Descripcion";
                        Lista_Marca.DataValueField = "Id";
                        Lista_Marca.DataBind();

                        BL_Edades edadNegocio = new BL_Edades();
                        edades = edadNegocio.Listar();
                        Lista_Edad.DataSource = edades;
                        Lista_Edad.DataBind();
                        Lista_Edad.DataTextField = "Descripcion";
                        Lista_Edad.DataValueField = "Id";
                        Lista_Edad.DataBind();

                        BL_Animal animalNegocio = new BL_Animal();
                        animales = animalNegocio.Listar();
                        Lista_Animal.DataSource = animales;
                        Lista_Animal.DataBind();
                        Lista_Animal.DataTextField = "Descripcion";
                        Lista_Animal.DataValueField = "Id";
                        Lista_Animal.DataBind();
                    }


                }
                catch (Exception ex)
                {

                    throw ex;
                }

                

            }

            else 
            {
                Response.Redirect("DefaultExpiroSesion");
            }
        }

        protected void Btn_GuardarArticulo(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    if (!IsPostBack) return;



                    BL_Articulo nuevo_art = new BL_Articulo();
                    BL_PrecioyStock nuevo_precio = new BL_PrecioyStock();
                    articulo = new Articulo();
                    pys = new PrecioyStock();
                    articulo.Marca = new Marca();
                    articulo.Raza = new Raza();
                    articulo.Edad = new Edades();
                    articulo.Animal = new Animal();
                    articulo.Precio = new PrecioyStock();


                    articulo.Codigo = Convert.ToString(codigo_art.Text);
                    articulo.Nombre = Convert.ToString(nombre_art.Text);
                    articulo.Descripcion = Convert.ToString(descripcion_art.Text);
                    articulo.Marca.ID = int.Parse(Lista_Marca.SelectedValue);
                    articulo.Raza.ID = int.Parse(Lista_Raza.SelectedValue);
                    articulo.Edad.ID = int.Parse(Lista_Edad.SelectedValue);
                    articulo.Animal.ID = int.Parse(Lista_Animal.SelectedValue);
                    articulo.Imagen_Url = Convert.ToString(imagen_art.Text);
                    articulo.Precio.PrecioVenta = Convert.ToDecimal(precioV_art.Text);
                    articulo.Precio.PrecioCompra = Convert.ToDecimal(precioU_art.Text);
                    articulo.Precio.Stock = Convert.ToInt32(stock_art.Text);




                    if (articulo != null)



                        nuevo_art.Agregar(articulo);
                    pys.IDarticulo = nuevo_art.BuscarUltimo();
                    pys.Stock = articulo.Precio.Stock;
                    pys.PrecioVenta = articulo.Precio.PrecioVenta;
                    pys.PrecioCompra = articulo.Precio.PrecioCompra;

                    nuevo_precio.Agregar(pys);

                    Response.Redirect("Admin_Listarticulos");



                }
                catch (Exception ex)
                {



                    throw ex;
                }

            }
            else
            {

                Response.Redirect("DefaultExpiroSesion");
            }


        }
    }
}