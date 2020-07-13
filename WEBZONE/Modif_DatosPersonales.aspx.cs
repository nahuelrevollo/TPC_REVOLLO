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
    public partial class Modif_DatosPersonales : System.Web.UI.Page

        
    {

        public List<Pais> Listado_Paises { get; set; }
        public List<Provincia> Listado_Provincias { get; set; }
        public Usuario usuario { get; set; }
        public Usuario usuario_aux { get; set; }
        public Direccion direccion { get; set; }

      

        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session[Session.SessionID + "sesionUsuario"] != null)

            {
                try
                {

                    usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];
                    if(!IsPostBack)
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
                        
                        Session["listaProvincia"] = Listado_Provincias;
                        int id = int.Parse(Lista_Paises.SelectedItem.Value);
                        Lista_Provincia.DataSource = ((List<Provincia>)Session["listaProvincia"]).FindAll(x => x.IDpais == id);
                        Lista_Provincia.DataTextField = "Descripcion";
                        Lista_Provincia.DataValueField = "Id";
                        Lista_Provincia.DataBind();

                        nombre_u.Text = usuario.Nombre;
                        apellido_u.Text = usuario.Apellido;
                        Lista_Paises.SelectedValue = usuario.Direccion.Provincia.IDpais.ToString();
                        Lista_Provincia.SelectedValue = usuario.IDprovincia.ToString();
                        nickname_u.Text = usuario.Nick_name;
                        dni_u.Text =Convert.ToString(usuario.Dni);
                        sexo_u.Text = Convert.ToString(usuario.Sexo);
                        mail_u.Text = usuario.Mail;
                        telefono_u.Text = Convert.ToString(usuario.Telefono);
                        fechanac_u.Text = Convert.ToString(usuario.Fecha_Nac.ToShortDateString());


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


        protected void Btn_ModificarDP(object sender, EventArgs e)
        { 
        
            if(Session[Session.SessionID + "sesionUsuario"] != null)

            {
                try
                {

                    BL_Usuario neg_usuario = new BL_Usuario();

                    usuario = new Usuario();
                    usuario_aux = new Usuario();
                    usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

                    usuario.Nombre = nombre_u.Text;
                    usuario.Apellido = apellido_u.Text;
                    usuario.IDprovincia = int.Parse(Lista_Provincia.SelectedValue);
                    usuario.Nick_name = nickname_u.Text;
                    usuario.Dni = Convert.ToInt32(dni_u.Text);
                    usuario.Sexo =Convert.ToChar(sexo_u.Text);
                    usuario.Fecha_Nac =Convert.ToDateTime(fechanac_u.Text);
                    usuario.Mail = mail_u.Text;
                    usuario.Telefono =Convert.ToInt32(telefono_u.Text);

                  

                        //hasta aca entra lo mas bien pero no se activa el modal
                        neg_usuario.ModificarDatos_Personales(usuario);

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Modif_DPu", "$('#Modal_Modif_DPu').modal();", true);
                        upModal.Update();

                        Response.Redirect("Perfil_Usuario.aspx");

                    //}







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