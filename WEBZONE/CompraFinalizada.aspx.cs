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
    public partial class CompraFinalizada : System.Web.UI.Page
    {

        public Usuario usuario { get; set; }

        public Venta venta { get; set; }
        public Envio envio { get; set; }
        public ArticuloxVenta axv { get; set; }
        public Direccion direccion_agregada { get; set; }
        public Direccion retira_local { get; set; }
        public List<Carrito> Listado_compra { get; set; }
        public List<Direccion> Listado_Direcciones { get; set; }
        public Direccion envio_unico { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

            retira_local = new Direccion();
            retira_local = (Direccion)Session[Session.SessionID + "Retiro_local"];

            envio_unico = new Direccion();
            envio_unico = (Direccion)Session[Session.SessionID + "EnvioUnico"];

            direccion_agregada = new Direccion();
            direccion_agregada = (Direccion)Session[Session.SessionID + "nuevadireccion_agregada"];

            var id_direc_select = Request.QueryString["id_Direc_select"];

            Listado_compra = (List<Carrito>)Session[Session.SessionID + "Listado_compra"];

            if (usuario != null)

            {



                try


                {

                    if (!IsPostBack)
                    {






                        if (retira_local != null)
                        {

                            Lblnombre.Text = "Nombre: " + usuario.Nombre;
                            Lblapellido.Text = "Apellido: " + usuario.Apellido;
                            Lblnickname.Text = "Usuario: " + usuario.Nick_name;
                            Lbltelefono.Text = "Telefono de contacto: " + Convert.ToString(usuario.Telefono);
                            LblMail.Text = "Mail: " + usuario.Mail;

                            Lblpais.Text = "Pais: " + retira_local.Pais;
                            Lblprovincia.Text = "Provincia: " + retira_local.Provincia.Descripcion;
                            Lbllocalidad.Text = "Localidad: " + retira_local.Localidad;
                            Lblcp.Text = "Codigo Postal: " + Convert.ToString(retira_local.CP);
                            Lblcalle.Text = "Calle: " + retira_local.Calle;
                            Lblaltura.Text = "Altura: " + Convert.ToString(retira_local.Altura);
                            Lblentrecalle1.Text = "Entre Calle 1: " + retira_local.Entrecalle1;
                            Lblentrecalle2.Text = "Entre Calle 2: " + retira_local.Entrecalle2;


                        }

                        else if (direccion_agregada != null)
                        {

                            Lblnombre.Text = "Nombre: " + usuario.Nombre;
                            Lblapellido.Text = "Apellido: " + usuario.Apellido;
                            Lblnickname.Text = "Usuario: " + usuario.Nick_name;
                            Lbltelefono.Text = "Telefono de contacto: " + Convert.ToString(usuario.Telefono);
                            LblMail.Text = "Mail: " + usuario.Mail;

                            Lblpais.Text = "Pais: " + direccion_agregada.Pais;
                            Lblprovincia.Text = "Provincia: " + direccion_agregada.Provincia.Descripcion;
                            Lbllocalidad.Text = "Localidad: " + direccion_agregada.Localidad;
                            Lblcp.Text = "Codigo Postal: " + Convert.ToString(direccion_agregada.CP);
                            Lblcalle.Text = "Calle: " + direccion_agregada.Calle;
                            Lblaltura.Text = "Altura: " + Convert.ToString(direccion_agregada.Altura);
                            Lblentrecalle1.Text = "Entre Calle 1: " + direccion_agregada.Entrecalle1;
                            Lblentrecalle2.Text = "Entre Calle 2: " + direccion_agregada.Entrecalle2;
                        }
                        else if (envio_unico != null)
                        {
                            Lblnombre.Text = "Nombre: " + usuario.Nombre;
                            Lblapellido.Text = "Apellido: " + usuario.Apellido;
                            Lblnickname.Text = "Usuario: " + usuario.Nick_name;
                            Lbltelefono.Text = "Telefono de contacto: " + Convert.ToString(usuario.Telefono);
                            LblMail.Text = "Mail: " + usuario.Mail;

                            Lblpais.Text = "Pais: " + envio_unico.Pais;
                            Lblprovincia.Text = "Provincia: " + envio_unico.Provincia.Descripcion;
                            Lbllocalidad.Text = "Localidad: " + envio_unico.Localidad;
                            Lblcp.Text = "Codigo Postal: " + Convert.ToString(envio_unico.CP);
                            Lblcalle.Text = "Calle: " + envio_unico.Calle;
                            Lblaltura.Text = "Altura: " + Convert.ToString(envio_unico.Altura);
                            Lblentrecalle1.Text = "Entre Calle 1: " + envio_unico.Entrecalle1;
                            Lblentrecalle2.Text = "Entre Calle 2: " + envio_unico.Entrecalle2;

                        }
                        else if (id_direc_select != null)
                        {
                            BL_Direccion neg_dire = new BL_Direccion();
                            Listado_Direcciones = neg_dire.Listar(usuario.ID);


                            Direccion direc_usuario = Listado_Direcciones.Find(a => a.ID == int.Parse(id_direc_select));


                            Lblnombre.Text = "Nombre: " + usuario.Nombre;
                            Lblapellido.Text = "Apellido: " + usuario.Apellido;
                            Lblnickname.Text = "Usuario: " + usuario.Nick_name;
                            Lbltelefono.Text = "Telefono de contacto: " + Convert.ToString(usuario.Telefono);
                            LblMail.Text = "Mail: " + usuario.Mail;

                            Lblpais.Text = "Pais: " + direc_usuario.Pais;
                            Lblprovincia.Text = "Provincia: " + direc_usuario.Provincia.Descripcion;
                            Lbllocalidad.Text = "Localidad: " + direc_usuario.Localidad;
                            Lblcp.Text = "Codigo Postal: " + Convert.ToString(direc_usuario.CP);
                            Lblcalle.Text = "Calle: " + direc_usuario.Calle;
                            Lblaltura.Text = "Altura: " + Convert.ToString(direc_usuario.Altura);
                            Lblentrecalle1.Text = "Entre Calle 1: " + direc_usuario.Entrecalle1;
                            Lblentrecalle2.Text = "Entre Calle 2: " + direc_usuario.Entrecalle2;


                        }



                        LblMontototal.Text = "Monto total de compra: $ " + Session[Session.SessionID + "Total_Compra"];
                        LblCant_total.Text = "Cantidad total de articulos " + Session[Session.SessionID + "Cantidad_carrito"];

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

        protected void Confirmar_compra(object sender, EventArgs e)
        {

            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

            retira_local = new Direccion();
            retira_local = (Direccion)Session[Session.SessionID + "Retiro_local"];

            envio_unico = new Direccion();
            envio_unico = (Direccion)Session[Session.SessionID + "EnvioUnico"];

            direccion_agregada = new Direccion();
            direccion_agregada = (Direccion)Session[Session.SessionID + "nuevadireccion_agregada"];

            var id_direc_select = Request.QueryString["id_Direc_select"];

            Listado_compra = (List<Carrito>)Session[Session.SessionID + "Listado_compra"];

            if (usuario != null)
            {
                try
                {
                    BL_Venta neg_venta = new BL_Venta();
                    BL_ArticuloxVenta neg_axv = new BL_ArticuloxVenta();

                    venta = new Venta();
                    envio = new Envio();
                    axv = new ArticuloxVenta();
                    envio.Provincia = new Provincia();



                    if (retira_local != null)
                    {

                        venta.IDusuario = usuario.ID;
                        venta.Fecha_V = DateTime.Now.Date;
                        venta.Total_compra = Convert.ToInt32(Session[Session.SessionID + "Total_Compra"]);

                        neg_venta.AgregarVenta(venta);

                        var IDventa = neg_venta.BuscarUltimo();

                        if (IDventa != 0)

                        {
                            foreach (var artxvent in Listado_compra)

                            {
                                axv.IDventa = IDventa;
                                axv.IDarticulo = artxvent.ID;
                                axv.Cantidad_Vendida = artxvent.Cantidad;
                                axv.Precio = artxvent.Precio;

                                neg_axv.AgregarArticuloxVenta(axv);


                            }


                        }
                        Session[Session.SessionID + "Listado_compra"] = null;
                        Session[Session.SessionID + "Cantidad_carrito"] = 0;
                        retira_local = null;
                        Session[Session.SessionID + "Retiro_local"] = retira_local;

                        envio_unico = null;
                        Session[Session.SessionID + "EnvioUnico"] = envio_unico;

                        direccion_agregada = null;
                        Session[Session.SessionID + "nuevadireccion_agregada"] = direccion_agregada;

                        Session[Session.SessionID + "sesionUsuario"] = usuario;



                    }

                    else if (direccion_agregada != null)

                    {
                        venta.IDusuario = usuario.ID;
                        venta.Fecha_V = DateTime.Now.Date;
                        venta.Total_compra = Convert.ToInt32(Session[Session.SessionID + "Total_Compra"]);

                        envio.Provincia.ID = direccion_agregada.Provincia.ID;
                        envio.Localidad = direccion_agregada.Localidad;
                        envio.CP = direccion_agregada.CP;
                        envio.Calle = direccion_agregada.Calle;
                        envio.Altura = direccion_agregada.Altura;
                        envio.Entrecalle1 = direccion_agregada.Entrecalle1;
                        envio.Entrecalle2 = direccion_agregada.Entrecalle2;


                        neg_venta.AgregarVenta_Envio(venta, envio);


                        var IDventa = neg_venta.BuscarUltimo();

                        if (IDventa != 0)

                        {
                            foreach (var artxvent in Listado_compra)

                            {
                                axv.IDventa = IDventa;
                                axv.IDarticulo = artxvent.ID;
                                axv.Cantidad_Vendida = artxvent.Cantidad;
                                axv.Precio = artxvent.Precio;

                                neg_axv.AgregarArticuloxVenta(axv);


                            }

                        }
                        Session[Session.SessionID + "Listado_compra"] = null;
                        Session[Session.SessionID + "Cantidad_carrito"] = 0;
                        retira_local = null;
                        Session[Session.SessionID + "Retiro_local"] = retira_local;

                        envio_unico = null;
                        Session[Session.SessionID + "EnvioUnico"] = envio_unico;

                        direccion_agregada = null;
                        Session[Session.SessionID + "nuevadireccion_agregada"] = direccion_agregada;

                        Session[Session.SessionID + "sesionUsuario"] = usuario;

                    }

                    else if (envio_unico != null)

                    {
                        venta.IDusuario = usuario.ID;
                        venta.Fecha_V = DateTime.Now.Date;
                        venta.Total_compra = Convert.ToInt32(Session[Session.SessionID + "Total_Compra"]);

                        envio.Provincia.ID = envio_unico.Provincia.ID;
                        envio.Localidad = envio_unico.Localidad;
                        envio.CP = envio_unico.CP;
                        envio.Calle = envio_unico.Calle;
                        envio.Altura = envio_unico.Altura;
                        envio.Entrecalle1 = envio_unico.Entrecalle1;
                        envio.Entrecalle2 = envio_unico.Entrecalle2;


                        neg_venta.AgregarVenta_Envio(venta, envio);

                        var IDventa = neg_venta.BuscarUltimo();

                        if (IDventa != 0)

                        {
                            foreach (var artxvent in Listado_compra)

                            {
                                axv.IDventa = IDventa;
                                axv.IDarticulo = artxvent.ID;
                                axv.Cantidad_Vendida = artxvent.Cantidad;
                                axv.Precio = artxvent.Precio;

                                neg_axv.AgregarArticuloxVenta(axv);


                            }

                        }
                        Session[Session.SessionID + "Listado_compra"] = null;
                        Session[Session.SessionID + "Cantidad_carrito"] = 0;

                        retira_local = null;
                        Session[Session.SessionID + "Retiro_local"] = retira_local;

                        envio_unico = null;
                        Session[Session.SessionID + "EnvioUnico"] = envio_unico;

                        direccion_agregada = null;
                        Session[Session.SessionID + "nuevadireccion_agregada"] = direccion_agregada;

                        Session[Session.SessionID + "sesionUsuario"] = usuario;

                    }
                    else if (id_direc_select != null)
                    {
                        BL_Direccion neg_dire = new BL_Direccion();
                        Listado_Direcciones = neg_dire.Listar(usuario.ID);


                        Direccion direc_usuario = Listado_Direcciones.Find(a => a.ID == int.Parse(id_direc_select));

                        venta.IDusuario = usuario.ID;
                        venta.Fecha_V = DateTime.Now.Date;
                        venta.Total_compra = Convert.ToInt32(Session[Session.SessionID + "Total_Compra"]);


                        envio.Provincia.ID = direc_usuario.Provincia.ID;
                        envio.Localidad = direc_usuario.Localidad;
                        envio.CP = direc_usuario.CP;
                        envio.Calle = direc_usuario.Calle;
                        envio.Altura = direc_usuario.Altura;
                        envio.Entrecalle1 = direc_usuario.Entrecalle1;
                        envio.Entrecalle2 = direc_usuario.Entrecalle2;


                        neg_venta.AgregarVenta_Envio(venta, envio);


                        var IDventa = neg_venta.BuscarUltimo();

                        if (IDventa != 0)

                        {
                            foreach (var artxvent in Listado_compra)

                            {
                                axv.IDventa = IDventa;
                                axv.IDarticulo = artxvent.ID;
                                axv.Cantidad_Vendida = artxvent.Cantidad;
                                axv.Precio = artxvent.Precio;
                                

                                neg_axv.AgregarArticuloxVenta(axv);


                            }

                        }

                        Session[Session.SessionID + "Listado_compra"] = null;
                        Session[Session.SessionID + "Cantidad_carrito"] = 0;
                        retira_local = null;
                        Session[Session.SessionID + "Retiro_local"] = retira_local;

                        envio_unico = null;
                        Session[Session.SessionID + "EnvioUnico"] = envio_unico;

                        direccion_agregada = null;
                        Session[Session.SessionID + "nuevadireccion_agregada"] = direccion_agregada;

                        Session[Session.SessionID + "sesionUsuario"] = usuario;

                    }


                    Response.Redirect("Compra_Exitosa");

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

        protected void Cancelar_compra(object sender, EventArgs e)
        {
            retira_local = null;
            Session[Session.SessionID + "Retiro_local"] = retira_local;

            envio_unico = null;
            Session[Session.SessionID + "EnvioUnico"] = envio_unico;

            direccion_agregada = null;
            Session[Session.SessionID + "nuevadireccion_agregada"] = direccion_agregada;

            Session[Session.SessionID + "sesionUsuario"] = usuario;

            Response.Redirect("Listado_Articulos");


        }


        protected void Volver_pasoanterior(object sender, EventArgs e)
        {
            retira_local = null;
            Session[Session.SessionID + "Retiro_local"] = retira_local;

            envio_unico = null;
            Session[Session.SessionID + "EnvioUnico"] = envio_unico;

            direccion_agregada = null;
            Session[Session.SessionID + "nuevadireccion_agregada"] = direccion_agregada;

            Session[Session.SessionID + "sesionUsuario"] = usuario;

            Response.Redirect("Direccion_Envio");


        }




    }
}