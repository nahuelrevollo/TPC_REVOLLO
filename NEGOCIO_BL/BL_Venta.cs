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
   public class BL_Venta
    {


        public void AgregarVenta_Envio(Venta venta, Envio envio)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_Guardar_VentayEnvio");
                Datos.AgregarParametros("@IDusuario", venta.IDusuario);
                Datos.AgregarParametros("@Fecha_venta", venta.Fecha_V);
                Datos.AgregarParametros("@Total", venta.Total_compra);
                

                Datos.AgregarParametros("@IDprovincia", envio.Provincia.ID);
                Datos.AgregarParametros("@Localidad", envio.Localidad);
                Datos.AgregarParametros("@CP", envio.CP);
                Datos.AgregarParametros("@Calle", envio.Calle);
                Datos.AgregarParametros("@Altura", envio.Altura);
                Datos.AgregarParametros("@Entrecalle1", envio.Entrecalle1);
                Datos.AgregarParametros("@Entrecalle2", envio.Entrecalle2);



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


        public void AgregarVenta(Venta venta)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_Guardar_Venta");
                Datos.AgregarParametros("@IDusuario", venta.IDusuario);
                Datos.AgregarParametros("@Fecha_venta", venta.Fecha_V);
                Datos.AgregarParametros("@Total", venta.Total_compra);



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



        public int BuscarUltimo()


        {

            int ID;

            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_UltimaVenta");

                

                Datos.EjecutarLector();

                Datos.Lector.Read();

                ID = Datos.Lector.GetInt32(0);






                return ID;

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
