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
    public partial class Admin_ListRazas : System.Web.UI.Page
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
                    Listado_Razas = neg_raza.Listar();

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