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
    public partial class Nuevo_Animal : System.Web.UI.Page
    {


        public Animal animal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session[Session.SessionID + "sesionAdmin"] == null)
            {

                Response.Redirect("DefaultExpiroSesion");
            }

        }

        protected void Btn_GuardarAnimal(object sender, EventArgs e)
        {


            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    if (!IsPostBack) return;



                    BL_Animal nuevo_animal = new BL_Animal();
                    animal = new Animal();




                    animal.Descripcion = Convert.ToString(nombre_animal.Text);




                    if (animal != null)

                        nuevo_animal.Agregar(animal);


                    Response.Redirect("Admin_ListAnimales");



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