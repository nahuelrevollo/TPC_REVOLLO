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
    public partial class Eliminar_Marca : System.Web.UI.Page
    {
        public List<Marca> Listado_Marcas { get; set; }

        public Marca marcas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                    BL_Marca neg_marca = new BL_Marca();


                    //if(!IsPostBack)
                    Listado_Marcas = neg_marca.Listar();

                    var ItemEliminar = Request.QueryString["idEliminar"];
                    Session[Session.SessionID + "ID_Eliminar"] = ItemEliminar;


                    if (ItemEliminar != null)


                    {
                        neg_marca.EliminarMarca_Logica(Convert.ToInt32(ItemEliminar));

                        Response.Redirect("Eliminar_Marca");



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