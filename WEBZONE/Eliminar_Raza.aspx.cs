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
    public partial class Eliminar_Raza : System.Web.UI.Page
    {
        public List<Raza> Listado_Razas { get; set; }

        public Raza raza { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                    BL_Raza neg_raza = new BL_Raza();


                    //if(!IsPostBack)
                    Listado_Razas = neg_raza.Listar();

                    var ItemEliminar = Request.QueryString["idEliminar"];
                    Session[Session.SessionID + "ID_Eliminar"] = ItemEliminar;


                    if (ItemEliminar != null)


                    {
                        neg_raza.EliminarCategoria_Logica(Convert.ToInt32(ItemEliminar));
                        Response.Redirect("Eliminar_Raza");

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