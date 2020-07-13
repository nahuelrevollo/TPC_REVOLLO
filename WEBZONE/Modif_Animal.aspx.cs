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
    public partial class Modif_Animal : System.Web.UI.Page
    {
        public List<Animal> Listado_Animales { get; set; }

        public Animal animal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                    BL_Animal neg_animal = new BL_Animal();
                    Listado_Animales = neg_animal.Listar();

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