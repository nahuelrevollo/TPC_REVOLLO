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
    public partial class Animal_Modificado : System.Web.UI.Page
    {
        public Animal animal { get; set; }

        public List<Animal> Listado_Animales { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                BL_Animal neg_animales = new BL_Animal();
                Listado_Animales = neg_animales.Listar();



                var ItemModificar = Request.QueryString["idModificar"];
                Session[Session.SessionID + "ID_modificar"] = ItemModificar;

                if (!IsPostBack)
                {
                    if (ItemModificar != null)
                    {

                        Animal animal = Listado_Animales.Find(a => a.ID == int.Parse(ItemModificar));


                        nombre_animal.Text = animal.Descripcion;

                    }
                }
            }
            else
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
                    animal.ID = Convert.ToInt32(Session[Session.SessionID + "ID_modificar"]);




                    if (animal != null)

                    {
                        nuevo_animal.Modificar(animal);

                        Response.Redirect("Modif_Animal");
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