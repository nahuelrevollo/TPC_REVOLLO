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
    public partial class Direccion_Envio : System.Web.UI.Page
    {

        public List<Direccion> Listado_Direcciones { get; set; }

        public Direccion direccion { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

            if(usuario!=null)

            {

            BL_Direccion neg_dire = new BL_Direccion();
            Listado_Direcciones = neg_dire.Listar(usuario.ID);


            }





        }

        protected void Retira_Local(object sender, EventArgs e)

        {




            direccion = new Direccion();
            direccion.Provincia = new Provincia();

            direccion.Pais = "Argentina";
            direccion.Calle = "Retira por el local,calle Buenos aires";
            direccion.Altura = 1150;
            direccion.CP = 1617;
            direccion.Provincia.Descripcion = "Buenos Aires";
            direccion.Localidad = "Tigre,Gral. Pacheco";
            direccion.Entrecalle1 = "Lope de vega";
            direccion.Entrecalle2 = "Monteros";


            Session[Session.SessionID + "Retiro_local"] = direccion;

            Response.Redirect("CompraFinalizada");



        }


    }
}