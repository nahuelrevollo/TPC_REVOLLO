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
    public partial class Descripcion : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionUsuario"] != null)
            {
                BL_Articulo neg_art = new BL_Articulo();

                List<Articulo> Lista_art;

                try
                {
                    Lista_art = neg_art.listar();

                    var articulo_Seleccionado = Convert.ToInt32(Request.QueryString["idart"]);
                    articulo = Lista_art.Find(J => J.ID == articulo_Seleccionado);


                }
                catch (Exception ex)
                {
                    Session["Error" + Session.SessionID] = ex;
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {


                Response.Redirect("DefaultExpiroSesion");
            }


        }
    }
}
