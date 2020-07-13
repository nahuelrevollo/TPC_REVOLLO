using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO_DTO;
using CONEXION_DB;
using System.Data.SqlClient;

namespace NEGOCIO_BL
{
   public class BL_ArticuloxVenta
    {

        public void AgregarArticuloxVenta(ArticuloxVenta articuloxventa)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_GuardarArticulosxVenta");
                Datos.AgregarParametros("@IDventa", articuloxventa.IDventa);
                Datos.AgregarParametros("@IDarticulo", articuloxventa.IDarticulo);
                Datos.AgregarParametros("@Precio", articuloxventa.Precio);
                Datos.AgregarParametros("@Cantidad_vendida", articuloxventa.Cantidad_Vendida);



                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {

                Datos.CerrarConexion();

            }
        }
   }
}
