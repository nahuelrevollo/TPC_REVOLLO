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
    public partial class MisVentas : System.Web.UI.Page
    {
        public Reporte_Mensual rp { get; set; }

        public List<MisCompras> Listado_miscompras { get; set; }

        public MisCompras miscompras { get; set; }

        public Usuario usuario { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session[Session.SessionID + "sesionAdmin"] != null)
            { 

            BL_ReporteMensual neg_rp = new BL_ReporteMensual();

            rp = new Reporte_Mensual();

            rp = neg_rp.Traer_Reporte();

                    usuario = new Usuario();
                    usuario = (Usuario)(Session[Session.SessionID + "sesionAdmin"]);

                    BL_MisCompras neg_miscompras = new BL_MisCompras();
            try
            {
                LblAño.Text = Convert.ToString(rp.Año);
                LblMes.Text = Convert.ToString(rp.Mes);
                LblVentames.Text = Convert.ToString(rp.Ventas_Mensual);
                LblEnvios_mes.Text = Convert.ToString(rp.Envios_Mensual);
                LblRetirosmes.Text = Convert.ToString(rp.Retiros_Mensual);
                LblTotalmes.Text = Convert.ToString(rp.Total_Vendido);





                    //if(!IsPostBack)
                    Listado_miscompras = neg_miscompras.Listado_General();
                    Session[Session.SessionID + "MisVentas"] = Listado_miscompras;

                    var VentaDetalle = Convert.ToInt32(Request.QueryString["idventa"]);
                    Session[Session.SessionID + "idventa"] = VentaDetalle;


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