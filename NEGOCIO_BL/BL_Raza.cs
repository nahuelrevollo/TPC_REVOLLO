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
   public class BL_Raza
    {

        public void Agregar(Raza Raza)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = REVOLLO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into Tipo_Razas(Nombre,Activo) values(@Descripcion,@activo)";
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@Descripcion", Raza.Descripcion);
                comando.Parameters.AddWithValue("@activo", 1);


                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void EliminarCategoria_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update Tipo_Razas set Activo=@Activo where Id=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Raza> Listar()

        {
            List<Raza> Listado = new List<Raza>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SettearQuery("select ID, Nombre,Activo from Tipo_Razas");
                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Raza aux_c = new Raza();

                    aux_c.ID = Datos.Lector.GetInt32(0);
                    aux_c.Descripcion = Datos.Lector.GetString(1);
                    aux_c.Activo = Datos.Lector.GetBoolean(2);

                    if (aux_c.Activo)
                    {

                        Listado.Add(aux_c);

                    }

                }


                return Listado;
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

        public void Modificar(Raza Raza)
        {
            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update Tipo_Razas set Nombre=@Descripcion where ID=@id");
                datos.AgregarParametros("@Id", Raza.ID);
                datos.AgregarParametros("@Descripcion",Raza.Descripcion);


                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

