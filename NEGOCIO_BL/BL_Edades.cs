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
    public class BL_Edades
    {

        public void Agregar(Edades Edad)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = REVOLLO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into Tipo_Edades(Nombre,Activo) values(@Descripcion,@activo)";
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@Descripcion", Edad.Descripcion);
                comando.Parameters.AddWithValue("@activo", 1);


                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Eliminar_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update Tipo_Edades set Activo=@Activo where Id=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Edades> Listar()

        {
            List<Edades> Listado = new List<Edades>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SettearQuery("select ID, Nombre,Activo from Tipo_Edades");
                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Edades aux_c = new Edades();

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

        public void Modificar(Edades edad)
        {
            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update Tipo_Edades set Nombre=@Descripcion where ID=@id");
                datos.AgregarParametros("@Id", edad.ID);
                datos.AgregarParametros("@Descripcion", edad.Descripcion);


                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}

