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
    public partial class Nuevo_Edades : System.Web.UI.Page
    {

        public Edades edad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] == null)
            {

                Response.Redirect("DefaultExpiroSesion");
            }
        }

        protected void Btn_GuardarEdad(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    if (!IsPostBack) return;



                    BL_Edades nueva_edad = new BL_Edades();
                    edad = new Edades();




                    edad.Descripcion = Convert.ToString(nombre_Edad.Text);




                    if (edad != null)

                        nueva_edad.Agregar(edad);

                    Response.Redirect("Admin_ListEdades");




                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }
            else
            {

                Response.Redirect("DefaultExpiroSesion");
            }

        }




    }
}