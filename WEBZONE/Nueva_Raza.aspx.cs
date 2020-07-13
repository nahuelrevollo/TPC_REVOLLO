using DOMINIO_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO_BL;

namespace WEBZONE
{
    public partial class Nueva_Raza : System.Web.UI.Page
    {

        public Raza raza { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] == null)
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




                    if (raza != null)

                        nueva_raza.Agregar(raza);


                    Response.Redirect("Admin_ListRazas");



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