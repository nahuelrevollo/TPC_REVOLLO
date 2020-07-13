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
    public partial class Log_IN : System.Web.UI.Page
    {

        public Usuario usuario { get; set; }
        public Usuario aux { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {

            usuario = new Usuario();
            aux = new Usuario();
            BL_Usuario neg_usuario = new BL_Usuario();

            try
            {
                usuario.Nick_name = Convert.ToString(nickname_u.Text);
                usuario.Contraseña = Convert.ToString(password_u.Text);

                aux = neg_usuario.Loguearse(usuario.Nick_name, usuario.Contraseña);

                if (aux.ID != 0)

                {

                    if (aux.IDtipo == 1)
                    {

                        Session[Session.SessionID + "sesionAdmin"] = aux;

                        Session[Session.SessionID + "sesionNickName"] = aux.Nick_name;



                        Response.Redirect("Administrador.aspx");
                    }
                    else if (aux.IDtipo == 2)
                    {
                        Session[Session.SessionID + "sesionUsuario"] = aux;

                        Session[Session.SessionID + "sesionNickName"] = aux.Nick_name;


                        Response.Redirect("Listado_Articulos.aspx");

                    }




                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorLogin", "$('#modalErrorLogin').modal();", true);
                }


            }
            catch (Exception ex)
            {

                throw ex;


            }

        }
    }
}