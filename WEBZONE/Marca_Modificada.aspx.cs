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
    public partial class Marca_Modificada : System.Web.UI.Page
    {
        public Marca  marca { get; set; }

        public List<Marca> Listado_Marca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {


                BL_Marca neg_marca = new BL_Marca();
                Listado_Marca = neg_marca.Listar();



                var ItemModificar = Request.QueryString["idModificar"];
                Session[Session.SessionID + "ID_modificar"] = ItemModificar;

                if (!IsPostBack)
                {
                    if (ItemModificar != null)
                    {

                        Marca marca = Listado_Marca.Find(a => a.ID == int.Parse(ItemModificar));


                        nombre_marca.Text = marca.Descripcion;

                    }
                }
            }
            else
            {

                Response.Redirect("DefaultExpiroSesion");
            }

        }

        protected void Btn_GuardarMarca(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    if (!IsPostBack) return;



                    BL_Marca nueva_marca = new BL_Marca();
                    marca = new Marca();




                    marca.Descripcion = Convert.ToString(nombre_marca.Text);
                    marca.ID = Convert.ToInt32(Session[Session.SessionID + "ID_modificar"]);




                    if (marca != null)

                    {
                        nueva_marca.Modificar(marca);

                        Response.Redirect("Modif_Marca");
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
           