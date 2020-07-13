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
    public partial class Nueva_Direccion : System.Web.UI.Page
    {

        public List<Pais> Listado_Paises { get; set; }
        public List<Provincia> Listado_Provincias { get; set; }

        public Usuario usuario { get; set; }

        public Envio envio { get; set; }

        public Direccion direccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionUsuario"] != null)
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


        protected void Pais_selecccionado(object sender, EventArgs e)
        {

            int id = int.Parse(Lista_Paises.SelectedItem.Value);
            Lista_Provincia.DataSource = ((List<Provincia>)Session["listaProvincia"]).FindAll(x => x.IDpais == id);
            Lista_Provincia.DataBind();

        }



        protected void Guardar_Direccion(object sender, EventArgs e)
        {

            if(Session[Session.SessionID + "sesionUsuario"]!=null)

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
                direccion.Provincia.Descripcion= Lista_Provincia.SelectedItem.Value;
                direccion.Pais = Lista_Paises.SelectedItem.Value;

                

                    Session[Session.SessionID + "nuevadireccion_agregada"] = direccion;



                    if (direccion.IDusuario!=0)
                {

                    //hasta aca entra lo mas bien pero no se activa el modal
                    neg_direccion.Agregar(direccion);

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalNueva_dir", "$('modalNueva_dir').modal();", true);
                    upModal.Update();

                        Response.Redirect("CompraFinalizada");


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


        protected void Direccion_Envio(object sender, EventArgs e)
        {

            if (Session[Session.SessionID + "sesionUsuario"] != null)

            {

                try
                {
                    direccion = new Direccion();
                    direccion.Provincia = new Provincia();

                    direccion.Localidad = Convert.ToString(localidad_u.Text);
                    direccion.CP = Convert.ToInt32(cp_u.Text);
                    direccion.Calle = Convert.ToString(calle_u.Text);
                    direccion.Altura = Convert.ToInt32(altura_u.Text);
                    direccion.Entrecalle1 = Convert.ToString(entrecalle1_u.Text);
                    direccion.Entrecalle2 = Convert.ToString(entrecalle2_u.Text);
                    direccion.Provincia.ID = int.Parse(Lista_Paises.SelectedValue);
                    direccion.Provincia.Descripcion = Lista_Provincia.SelectedItem.Value;
                    direccion.Pais = Lista_Paises.SelectedItem.Value;

                    Session[Session.SessionID + "EnvioUnico"] = direccion;

                    Response.Redirect("CompraFinalizada");

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