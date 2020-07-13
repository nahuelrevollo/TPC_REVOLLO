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
    public partial class Nuevo_Admin : System.Web.UI.Page
    {
        bool mail_ok = false;
        bool nick_ok = false;

        public List<Pais> Listado_Paises { get; set; }
        public List<Provincia> Listado_Provincias { get; set; }

        public Usuario usuario { get; set; }
        public Usuario usuario_aux { get; set; }
        


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"]!=null)
            {
                try
                {
                    if (!IsPostBack)

                    {
                        BL_Pais Pais_Negocio = new BL_Pais();
                        Listado_Paises = Pais_Negocio.Listar();
                        Lista_Paises.DataSource = Listado_Paises;
                        Lista_Paises.DataBind();
                        Lista_Paises.DataTextField = "Descripcion";
                        Lista_Paises.DataValueField = "Id";
                        Lista_Paises.DataBind();




                        BL_Provincia provinciaNegocio = new BL_Provincia();
                        Listado_Provincias = provinciaNegocio.Listar();
                        //Lista_Provincia.DataSource = Listado_Provincias;
                        //Lista_Provincia.DataBind();
                        //Lista_Provincia.DataBind();
                        Session["listaProvincia"] = Listado_Provincias;
                        int id = int.Parse(Lista_Paises.SelectedItem.Value);
                        Lista_Provincia.DataSource = ((List<Provincia>)Session["listaProvincia"]).FindAll(x => x.IDpais == id);
                        Lista_Provincia.DataTextField = "Descripcion";
                        Lista_Provincia.DataValueField = "Id";
                        Lista_Provincia.DataBind();

                        //Lista_Paises.DataBind();





                    }


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

        protected void Pais_selecccionado(object sender, EventArgs e)
        {

            int id = int.Parse(Lista_Paises.SelectedItem.Value);
            Lista_Provincia.DataSource = ((List<Provincia>)Session["listaProvincia"]).FindAll(x => x.IDpais == id);
            Lista_Provincia.DataBind();

        }

        protected void Guardar_Usuario(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    //if (!IsPostBack) return;

                    usuario = new Usuario();
                    usuario_aux = new Usuario();

                    BL_Usuario neg_usuario = new BL_Usuario();


                    usuario.Nombre = Convert.ToString(nombre_u.Text);
                    usuario.Apellido = Convert.ToString(apellido_u.Text);
                    usuario.Nick_name = Convert.ToString(nickname_u.Text);
                    usuario.Contraseña = Convert.ToString(password_u.Text);
                    usuario.Dni = Convert.ToInt32(dni_u.Text);
                    usuario.Sexo = Convert.ToChar(sexo_u.Text);
                    usuario.Fecha_Nac = Convert.ToDateTime(fechanac_u.Text);
                    usuario.Mail = Convert.ToString(mail_u.Text);
                    usuario.Telefono = Convert.ToInt32(telefono_u.Text);
                    usuario.IDpais = int.Parse(Lista_Paises.SelectedValue);
                    usuario.IDprovincia = int.Parse(Lista_Provincia.SelectedValue);



                    usuario_aux = neg_usuario.Validar_Usuario(usuario.Nick_name);


                    if (usuario_aux.Activo)
                    {
                        lblNickExistente.Text = "Ya hay un Usuario con ese nombre";
                        lblNickExistente.Visible = true;
                        nickname_u.Text = "";
                        nick_ok = false;
                    }
                    else
                    {

                        lblNickExistente.Visible = false;
                        nick_ok = true;
                    }

                    usuario_aux = neg_usuario.Validar_Email(usuario.Mail);

                    if (usuario_aux.Activo)
                    {
                        lblEmailExistente.Text = "Ya hay un Usuario con ese Email";
                        lblEmailExistente.Visible = true;
                        mail_u.Text = "";
                        mail_ok = false;

                    }
                    else
                    {
                        lblEmailExistente.Visible = false;
                        mail_ok = true;
                    }

                    if (nick_ok && mail_ok)
                    {

                        //hasta aca entra lo mas bien pero no se activa el modal
                        neg_usuario.AgregarAdmin(usuario);

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalNuevoUsuario", "$('#modalNuevoUsuario').modal();", true);
                        upModal.Update();

                        Response.Redirect("Log_IN.aspx");

                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorForm", "$('#modalErrorForm').modal();", true);






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