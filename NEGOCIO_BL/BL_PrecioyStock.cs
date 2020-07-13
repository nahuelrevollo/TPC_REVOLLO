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
    public class BL_PrecioyStock
    {

        public PrecioyStock Obtener_Precio(int IDart)

        {
            PrecioyStock PyS = new PrecioyStock();
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_ObtenerPrecio");
                Datos.AgregarParametros("@IDarticulo", IDart);
                Datos.EjecutarLector();

                Datos.Lector.Read();

                PyS.IDarticulo = Datos.Lector.GetInt32(0);
                PyS.PrecioVenta = Datos.Lector.GetDecimal(1);
                PyS.PrecioCompra = Datos.Lector.GetDecimal(2);
                PyS.Stock = Datos.Lector.GetInt32(3);
                PyS.Activo = Datos.Lector.GetBoolean(4);

                



                return PyS;

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



        public void Modificar(PrecioyStock Modificacion)
        {

            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update PrecioyStock set IDarticulo=@IDarticulo,Stock=@Stock, " +
                    "PrecioVenta=@PrecioVenta,PrecioCompra=@PrecioCompra,Activo=@Activo where IDarticulo=@IDarticulo");


                datos.AgregarParametros("@IDarticulo", Modificacion.IDarticulo);
                datos.AgregarParametros("@Stock", Modificacion.Stock);
                datos.AgregarParametros("@PrecioVenta", Modificacion.PrecioVenta);
                datos.AgregarParametros("@PrecioCompra", Modificacion.PrecioCompra);
               
                
                datos.AgregarParametros("@Activo", 1);


                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Agregar(PrecioyStock pys)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


               Datos.SettearSP("SP_AgregarPyS");
               Datos.AgregarParametros("@ID", pys.IDarticulo);
               Datos.AgregarParametros("@Stock", pys.Stock);
               Datos.AgregarParametros("@Pventa", pys.PrecioVenta);
               Datos.AgregarParametros("@Pcompra",pys.PrecioCompra);


                Datos.AgregarParametros("@Activo", 1);
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


        public void Eliminar (int IDarticulo)

        {

            PrecioyStock PyS = new PrecioyStock();
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_EliminarPrecio");
                Datos.AgregarParametros("@IDarticulo", IDarticulo);
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

