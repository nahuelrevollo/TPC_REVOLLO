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
    public partial class Perfil_Admin : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }

        public Direccion direccion { get; set; }

        public List<Direccion> Listado_Direcciones { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {
                try
                {
                    usuario = new Usuario();

                    usuario = (Usuario)Session[Session.SessionID + "sesionAdmin"];


                    Lblnombre.Text = "Nombre: " + usuario.Nombre;
                    Lblapellido.Text = "Apellido: " + usuario.Apellido;
                    Lblpais.Text = "Pais: " + usuario.Direccion.Pais;
                    Lblprovincia.Text = "Provincia: " + usuario.Direccion.Provincia.Descripcion;
                    Lblnickname.Text = "Usuario: " + usuario.Nick_name;
                    LblDni.Text = "DNI: " + usuario.Dni;
                    LblMail.Text = "Mail: " + usuario.Mail;
                    Lbltelefono.Text = "Telefono: " + usuario.Telefono;
                    Lblfecha_nac.Text = "Fecha de nacimiento: " + usuario.Fecha_Nac.ToShortDateString();

                    





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