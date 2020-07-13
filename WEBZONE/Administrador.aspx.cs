using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO_DTO;

namespace WEBZONE
{
    public partial class Administrador : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session[Session.SessionID + "sesionAdmin"];

            if (Session[Session.SessionID + "sesionAdmin"] == null)
            {
                Response.Redirect("DefaultExpiroSesion");


            }

           



        }

       
    }
}