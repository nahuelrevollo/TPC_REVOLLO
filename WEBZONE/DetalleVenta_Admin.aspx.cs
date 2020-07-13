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
    public partial class DetalleVenta_Admin : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }

        public Direccion direccion { get; set; }
        public List<MisCompras> Lista_miscompras { get; set; }

        public MisCompras miscompras { get; set; }

        public List<Articulo> Listado_axv { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

            Lista_miscompras = (List<MisCompras>)Session[Session.SessionID + "MisVentas"];




            var VentaDetalle = Convert.ToInt32(Request.QueryString["idventa"]);
            Session[Session.SessionID + "idventa"] = VentaDetalle;


            BL_Articulo neg_art = new BL_Articulo();
            BL_Direccion neg_direc = new BL_Direccion();
            BL_Usuario neg_usuario = new BL_Usuario();

            if (Session[Session.SessionID + "sesionAdmin"] != null)
            {

                try
                {

                    if (VentaDetalle != 0)


                    {


                        Listado_axv = neg_art.listar_AxV(VentaDetalle);

                        miscompras = new MisCompras();
                        miscompras = Lista_miscompras.Find(J => J.IDventa == VentaDetalle);

                    }


                    direccion = new Direccion();

                    direccion = neg_direc.BuscarEnvio(VentaDetalle);

                    usuario = neg_usuario.BuscarUsuarioX_ID(miscompras.IDusuario);


                    if (direccion != null) 
                    {
                        Lblpais.Text = "Pais: " + direccion.Pais;
                        Lblprovincia.Text = "Provincia: " + direccion.Provincia.Descripcion;
                        Lbllocalidad.Text = "Localidad: " + direccion.Localidad;
                        Lblcp.Text = "Codigo Postal: " + Convert.ToString(direccion.CP);
                        Lblcalle.Text = "Calle: " + direccion.Calle;
                        Lblaltura.Text = "Altura" + Convert.ToString(direccion.Altura);
                        Lblentrecalle1.Text = "Entre Calle 1: " + direccion.Entrecalle1;
                        Lblentrecalle2.Text = "Entre Calle 2: " + direccion.Entrecalle2;


                    }
                    else
                    {



                        Lblpais.Text = "Pais: Argentina";
                        Lblprovincia.Text = "Provincia: Buenos Aires";
                        Lbllocalidad.Text = "Localidad: Tigre,Gral. Pacheco";
                        Lblcp.Text = "Codigo Postal: 1617";
                        Lblcalle.Text = "Calle: Retira por el local,calle Buenos aire ";
                        Lblaltura.Text = "Altura: 1150";
                        Lblentrecalle1.Text = "Entre Calle 1: Lope de vega";
                        Lblentrecalle2.Text = "Entre Calle 2: Monteros ";



                    }


                    Lblnickname.Text = "Usuario: " + usuario.Nick_name;
                    LblDni.Text = "DNI: " + usuario.Dni;
                    LblMail.Text = "Mail: " + usuario.Mail;
                    Lbltelefono.Text = "Telefono: " + usuario.Telefono;
                    Lblfecha_nac.Text = "Fecha de nacimiento: " + usuario.Fecha_Nac.ToShortDateString();
                    Lblnombre.Text = "Nombre: " + usuario.Nombre;
                    Lblapellido.Text = "Apellido: " + usuario.Apellido;



                    LblMontototal.Text = "Monto total de compra: $ " + Convert.ToString(miscompras.Total);
                    LblCant_total.Text = "Cantidad total de articulos " + Convert.ToString(miscompras.Cantidadvendida);


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