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
   public class BL_MisCompras
    {


        public List<MisCompras> Listado (int IDusuario)
        {

            List<MisCompras> listado = new List<MisCompras>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {
                Datos.SettearSP("SP_VentasUsuario");
                Datos.Comando.Parameters.Clear();
                Datos.AgregarParametros("@IDusuario",IDusuario);

                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    MisCompras aux = new MisCompras();
                    



                    
                    aux.IDventa = Datos.Lector.GetInt32(0);
                    aux.IDusuario = Datos.Lector.GetInt32(1);
                    aux.Fecha_Venta= Datos.Lector.GetDateTime(2);
                  
                    aux.Total = Datos.Lector.GetInt32(3);
                    aux.Estado = Datos.Lector.GetString(4);
                    aux.Cantidadvendida = Datos.Lector.GetInt32(5);
                    




                    listado.Add(aux);

                }


                return listado;
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

        public List<MisCompras> Listado_General()
        {

            List<MisCompras> listado = new List<MisCompras>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {
                Datos.SettearSP("SP_VentaGenerales");
                

                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    MisCompras aux = new MisCompras();





                    aux.IDventa = Datos.Lector.GetInt32(0);
                    aux.IDusuario = Datos.Lector.GetInt32(1);
                    aux.Fecha_Venta = Datos.Lector.GetDateTime(2);

                    aux.Total = Datos.Lector.GetInt32(3);
                    aux.Estado = Datos.Lector.GetString(4);
                    aux.Cantidadvendida = Datos.Lector.GetInt32(5);





                    listado.Add(aux);

                }


                return listado;
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
