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
    public partial class Modificar_Direccion : System.Web.UI.Page
    {

        public List<Pais> Listado_Paises { get; set; }
        public List<Provincia> Listado_Provincias { get; set; }

        public List<Direccion> Listado_direcciones { get; set; }

        public Usuario usuario { get; set; }

        public Envio envio { get; set; }

        public Direccion direccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[Session.SessionID + "sesionUsuario"] != null)
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

                        Session["listaProvincia"] = Listado_Provincias;
                        int id = int.Parse(Lista_Paises.SelectedItem.Value);
                        Lista_Provincia.DataSource = ((List<Provincia>)Session["listaProvincia"]).FindAll(x => x.IDpais == id);
                        Lista_Provincia.DataTextField = "Descripcion";
                        Lista_Provincia.DataValueField = "Id";
                        Lista_Provincia.DataBind();

                        usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

                        var ItemModificar = Request.QueryString["id_modificar"];
                        Session[Session.SessionID + "id_modificar"] = ItemModificar;

                        BL_Direccion neg_dir = new BL_Direccion();
                        Listado_direcciones = neg_dir.Listar(usuario.ID);


                         if (ItemModificar != null)
                        {

                            Direccion direccion = Listado_direcciones.Find(a => a.ID == int.Parse(ItemModificar));

                            

                            Lista_Paises.SelectedValue = direccion.Pais.ToString();
                            Lista_Provincia.SelectedValue = direccion.Provincia.Descripcion.ToString();
                            localidad_u.Text = direccion.Localidad;
                            cp_u.Text = Convert.ToString(direccion.CP);
                            calle_u.Text = direccion.Calle;
                            altura_u.Text = Convert.ToString(direccion.Altura);
                            entrecalle1_u.Text = direccion.Entrecalle1;
                            entrecalle2_u.Text = direccion.Entrecalle2;


                        }




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


        protected void Guardar_Direccion(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionUsuario"] != null)

            {
                try
                {

                    //if (!IsPostBack) return;

                    usuario = new Usuario();

                    direccion = new Direccion();
                    direccion.Provincia = new Provincia();

                    envio = new Envio();

                    BL_Direccion neg_direccion = new BL_Direccion();


                    usuario = (Usuario)Session[Session.SessionID + "sesionUsuario"];

                    direccion.IDusuario = usuario.ID;
                   
                    direccion.Localidad = Convert.ToString(localidad_u.Text);
                    direccion.CP = Convert.ToInt32(cp_u.Text);
                    direccion.Calle = Convert.ToString(calle_u.Text);
                    direccion.Altura = Convert.ToInt32(altura_u.Text);
                    direccion.Entrecalle1 = Convert.ToString(entrecalle1_u.Text);
                    direccion.Entrecalle2 = Convert.ToString(entrecalle2_u.Text);
                    direccion.Provincia.ID = int.Parse(Lista_Provincia.SelectedValue);
                    direccion.Provincia.Descripcion = Lista_Provincia.SelectedItem.Value;
                    direccion.Pais = Lista_Paises.SelectedItem.Value;


                    var ItemModificar = Session[Session.SessionID + "id_modificar"];
                


                    direccion.ID = Convert.ToInt32(ItemModificar);



                    Session[Session.SessionID + "nuevadireccion_agregada"] = direccion;



                    if (direccion.ID != 0)
                    {

                        //hasta aca entra lo mas bien pero no se activa el modal
                        neg_direccion.Modificar(direccion);

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalNuevaDireccion", "$('#modalNuevaDireccion').modal();", true);
                        upModal.Update();

                        Response.Redirect("Perfil_Usuario");


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