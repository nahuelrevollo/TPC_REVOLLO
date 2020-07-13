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
    public partial class Admin_ListArticulos : System.Web.UI.Page
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
                    Listado_articulos = neg_art.listar();



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