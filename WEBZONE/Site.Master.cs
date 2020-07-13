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
    public partial class SiteMaster : MasterPage
    {

        string cant;

        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            cant =Convert.ToString(Session[Session.SessionID + "Cantidad_carrito"]);


        }


        protected void CerrarSesion(object sender, EventArgs e)
        {
            usuario = new Usuario();


            Session[Session.SessionID + "sesionUsuario"] = usuario;



        }
    }
}