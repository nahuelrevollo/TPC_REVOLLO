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
    public class BL_Direccion
    {
        public void Agregar(Direccion direccion)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_Nueva_Direccion");
                Datos.AgregarParametros("@IDusuario", direccion.IDusuario);
                Datos.AgregarParametros("@IDprovincia", direccion.Provincia.ID);
                Datos.AgregarParametros("@Localidad", direccion.Localidad);
                Datos.AgregarParametros("@CP", direccion.CP);
                Datos.AgregarParametros("@Calle", direccion.Calle);
                Datos.AgregarParametros("@Altura", direccion.Altura);
                Datos.AgregarParametros("@Entrecalle1", direccion.Entrecalle1);
                Datos.AgregarParametros("@Entrecalle2", direccion.Entrecalle2);
              



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

        public List<Direccion> Listar (int idUsuario)

        {

            List<Direccion> listado = new List<Direccion>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {
                Datos.SettearSP("SP_ListarDirecciones");
                Datos.Comando.Parameters.Clear();
                Datos.AgregarParametros("@IDusuario", idUsuario);

                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Direccion aux = new Direccion();
                    aux.Provincia = new Provincia();
                    

                    
                    aux.Pais = Datos.Lector.GetString(0);
                    aux.Provincia.IDpais = Datos.Lector.GetInt32(1);
                    aux.Provincia.ID = Datos.Lector.GetInt32(2);
                    aux.Provincia.Descripcion = Datos.Lector.GetString(3);
                    aux.IDusuario = Datos.Lector.GetInt32(4);
                    aux.Localidad = Datos.Lector.GetString(5);
                    aux.CP = Datos.Lector.GetInt32(6);
                    aux.Calle = Datos.Lector.GetString(7);
                    aux.Altura = Datos.Lector.GetInt32(8);
                    aux.Entrecalle1 = Datos.Lector.GetString(9);
                    aux.Entrecalle2 = Datos.Lector.GetString(10);
                    aux.ID = Datos.Lector.GetInt32(11);
                    


                   
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


        public void EliminarDireccion_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update Direcciones set Activo=@Activo where ID=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public bool Modificar(Direccion direccion)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {

                if (direccion != null)

                {
                    Datos.SettearSP("SP_ModificarDireccion");

                    Datos.AgregarParametros("@ID", direccion.ID);
                    Datos.AgregarParametros("@IDusuario", direccion.IDusuario);
                    Datos.AgregarParametros("@IDprovincia", direccion.Provincia.ID);
                    Datos.AgregarParametros("@Localidad",direccion.Localidad);
                    Datos.AgregarParametros("@CP", direccion.CP);
                    Datos.AgregarParametros("@Calle", direccion.Calle);
                    Datos.AgregarParametros("@Altura", direccion.Altura);
                    Datos.AgregarParametros("@Entrecalle1", direccion.Entrecalle1);
                    Datos.AgregarParametros("@Entrecalle2", direccion.Entrecalle2);
            

                    Datos.EjecutarAccion();

                    return true;


                }

                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Direccion BuscarEnvio(int IDventa)
        {


            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_BuscarEnvio");

                Datos.AgregarParametros("@IDventa", IDventa);

                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                { 

                 Direccion direccion = new Direccion();
                 direccion.Provincia = new Provincia();


                    direccion.Provincia.ID = Datos.Lector.GetInt32(0);
                    direccion.Pais = Datos.Lector.GetString(1);
                    direccion.Provincia.Descripcion = Datos.Lector.GetString(2);
                    direccion.Localidad = Datos.Lector.GetString(3);
                    direccion.CP = Datos.Lector.GetInt32(4);
                    direccion.Calle = Datos.Lector.GetString(5);
                    direccion.Altura = Datos.Lector.GetInt32(6);
                    direccion.Entrecalle1 = Datos.Lector.GetString(7);
                    direccion.Entrecalle2 = Datos.Lector.GetString(8);

                    return direccion;


                }

                return null;

                



                

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
