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
    public partial class Eliminar_Animal_aspx : System.Web.UI.Page
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


                    //if(!IsPostBack)
                    Listado_Animales = neg_animal.Listar();

                    var ItemEliminar = Request.QueryString["idEliminar"];
                    Session[Session.SessionID + "idEliminar"] = ItemEliminar;


                    if (ItemEliminar != null)


                    {
                        neg_animal.Eliminar_Logica(Convert.ToInt32(ItemEliminar));

                        Response.Redirect("Eliminar_Animal");



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
    }
}