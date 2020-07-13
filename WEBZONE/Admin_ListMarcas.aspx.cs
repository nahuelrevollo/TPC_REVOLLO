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
    public partial class Admin_ListMarcas : System.Web.UI.Page
    {
        public List<Marca> Listado_Marcas { get; set; }

        public Marca marca { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                    BL_Marca neg_marca = new BL_Marca();
                    Listado_Marcas = neg_marca.Listar();

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