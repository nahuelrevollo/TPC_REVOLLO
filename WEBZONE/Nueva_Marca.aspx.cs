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
    public partial class Nueva_Marca : System.Web.UI.Page
    {
        public Marca marca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session[Session.SessionID + "sesionAdmin"] == null)
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




                    if (marca != null)

                        nueva_marca.Agregar(marca);
                    Response.Redirect("Admin_ListMarcas");






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