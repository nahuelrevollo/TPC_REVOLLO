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
    public partial class Eliminar_Edades : System.Web.UI.Page
    {
        public List<Edades> Listado_Edades { get; set; }

        public Edades edad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                    BL_Edades neg_edad = new BL_Edades();


                    //if(!IsPostBack)
                    Listado_Edades = neg_edad.Listar();

                    var ItemEliminar = Request.QueryString["idEliminar"];
                    Session[Session.SessionID + "ID_Eliminar"] = ItemEliminar;


                    if (ItemEliminar != null)


                    {
                        neg_edad.Eliminar_Logica(Convert.ToInt32(ItemEliminar));
                        Response.Redirect("Eliminar_Edades");

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