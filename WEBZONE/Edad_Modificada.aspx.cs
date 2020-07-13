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
    public partial class Edad_Modificada : System.Web.UI.Page
    {
        public Edades edad { get; set; }

        public List<Edades> Listado_Edades { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                BL_Edades neg_edades = new BL_Edades();
                Listado_Edades = neg_edades.Listar();



                var ItemModificar = Request.QueryString["idModificar"];
                Session[Session.SessionID + "ID_modificar"] = ItemModificar;

                if (!IsPostBack)
                {
                    if (ItemModificar != null)
                    {

                        Edades edad = Listado_Edades.Find(a => a.ID == int.Parse(ItemModificar));


                        nombre_edad.Text = edad.Descripcion;

                    }
                }
            }
            else
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



                    BL_Edades nueva_marca = new BL_Edades();
                    edad = new Edades();




                    edad.Descripcion = Convert.ToString(nombre_edad.Text);
                    edad.ID = Convert.ToInt32(Session[Session.SessionID + "ID_modificar"]);




                    if (edad != null)

                    {
                        nueva_marca.Modificar(edad);

                        Response.Redirect("Modif_Edades");
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