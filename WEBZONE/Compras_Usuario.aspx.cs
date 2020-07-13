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
    public partial class Compras_Usuario : System.Web.UI.Page
    {
        public List<MisCompras> Listado_miscompras { get; set; }

        public MisCompras miscompras { get; set; }

        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionUsuario"] != null)
            {
                try
                {

                    usuario = new Usuario();
                    usuario = (Usuario)(Session[Session.SessionID + "sesionUsuario"]);

                    BL_MisCompras neg_miscompras = new BL_MisCompras();
                    

                    //if(!IsPostBack)
                    Listado_miscompras = neg_miscompras.Listado(usuario.ID);
                    Session[Session.SessionID + "ventasUsuario"] = Listado_miscompras;

                    var VentaDetalle = Convert.ToInt32(Request.QueryString["idventa"]);
                    Session[Session.SessionID + "idventa"] = VentaDetalle;

                   

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