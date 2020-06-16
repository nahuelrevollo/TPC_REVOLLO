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


	public partial class Listado_Articulos : System.Web.UI.Page
	{

		public List<Articulo> L_art { get; set; }

		public List<Marca> Lista_marca { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{

			try
			{

				BL_Articulo Neg_art = new BL_Articulo();
				L_art = Neg_art.listar();


				//Negocio_marca marca = new Negocio_marca();

				//Lista_marca = marca.Listar();

				//var filtro_marca = Request.QueryString["idmarca"];

				//if (filtro_marca != null)
				//{
				//	List<Articulo> L_art_aux = new List<Articulo>();
				//	foreach (var item in Lista_art)
				//	{
				//		if (item.Marca.ID == int.Parse(filtro_marca))
				//		{
				//			L_art_aux.Add(item);
				//		}
				//	}
				//	Lista_art = L_art_aux;

				//	Session[Session.SessionID + "Lista_art"] = Lista_art;
				//}



				Session[Session.SessionID + "Lista_art"] = L_art;

			}
			catch (Exception ex)
			{

				Session["Error" + Session.SessionID] = "Error de listado";
				Response.Redirect("Error");
			}

		}


	}



}



	
