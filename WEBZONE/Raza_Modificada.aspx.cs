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
    public partial class Raza_Modificada : System.Web.UI.Page
    {
        public Raza raza { get; set; }

        public List<Raza> Listado_Raza { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {


                BL_Raza neg_raza = new BL_Raza();
                Listado_Raza = neg_raza.Listar();



                var ItemModificar = Request.QueryString["idModificar"];
                Session[Session.SessionID + "ID_modificar"] = ItemModificar;

                if (!IsPostBack)
                {
                    if (ItemModificar != null)
                    {

                        Raza raza = Listado_Raza.Find(a => a.ID == int.Parse(ItemModificar));


                        nombre_raza.Text = raza.Descripcion;

                    }
                }
            }
            else
            {
                Response.Redirect("DefaultExpiroSesion");
            }

        }

        protected void Btn_GuardarRaza(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {

                if (!IsPostBack) return;



                BL_Raza nueva_raza = new BL_Raza();
                raza = new Raza();




               raza.Descripcion = Convert.ToString(nombre_raza.Text);
               raza.ID = Convert.ToInt32(Session[Session.SessionID + "ID_modificar"]);




                if (raza != null)

                {
                    nueva_raza.Modificar(raza);

                    Response.Redirect("Modif_Raza");
                }



                }
            catch (Exception ex)
                {
                throw ex;

                //Session["Error" + Session.SessionID] = ex.Message;
                //Response.Redirect("Error");
                }
            }
            else
            {
                Response.Redirect("DefaultExpiroSesion");
            }

        }
    }
}