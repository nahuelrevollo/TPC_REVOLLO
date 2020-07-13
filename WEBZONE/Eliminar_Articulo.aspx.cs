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
    public partial class Eliminar_Articulo : System.Web.UI.Page
    {
        public List<Articulo> Listado_articulos { get; set; }

        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                    BL_Articulo neg_art = new BL_Articulo();
                    BL_PrecioyStock pys = new BL_PrecioyStock();

                    //if(!IsPostBack)
                    Listado_articulos = neg_art.listar();

                    var ItemEliminar = Request.QueryString["idEliminar"];
                    Session[Session.SessionID + "ID_Eliminar"] = ItemEliminar;


                    if (ItemEliminar != null)


                    {
                        neg_art.EliminarArticulo_Logica(Convert.ToInt32(ItemEliminar));
                        pys.Eliminar(Convert.ToInt32(ItemEliminar));

                        Response.Redirect("Eliminar_Articulo");


                    }


                }





                catch (Exception ex)
                {
                    Session["Error" + Session.SessionID] = ex.Message;
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