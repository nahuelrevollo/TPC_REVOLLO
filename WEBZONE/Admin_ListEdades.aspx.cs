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
    public partial class Admin_ListEdades : System.Web.UI.Page
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
                    Listado_Edades = neg_edad.Listar();

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
