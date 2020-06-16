using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOMINIO_DTO;
using CONEXION_DB;

namespace NEGOCIO_BL
{
    public class BL_Marca
    {

        public void Agregar(Marca marca)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into MARCAS(Descripcion,activo) values(@Descripcion,@activo)";
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@Descripcion", marca.Descripcion);
                comando.Parameters.AddWithValue("@activo", 1);


                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void EliminarMarca_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update MARCAS set activo=@Activo where Id=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Marca> Listar()


        {


            List<Marca> listado = new List<Marca>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {

                Datos.SettearQuery("select Id, Descripcion, activo from MARCAS ");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())

                {
                    Marca aux_m = new Marca();

                    aux_m.ID = Datos.Lector.GetInt32(0);
                    aux_m.Descripcion = Datos.Lector.GetString(1);
                    aux_m.Activo = Datos.Lector.GetBoolean(2);

                    if (aux_m.Activo)
                    {

                        listado.Add(aux_m);

                    }

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

        public void Modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update MARCAS set Descripcion=@Descripcion where id=@id");
                datos.AgregarParametros("@Id", marca.ID);
                datos.AgregarParametros("@Descripcion", marca.Descripcion);


                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
