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
    public class BL_Pais
    {

        public void Agregar(Pais pais)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = REVOLLO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into Paises(Nombre,Activo) values(@Descripcion,@activo)";
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@Descripcion", pais.Descripcion);
                comando.Parameters.AddWithValue("@activo", 1);


                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void EliminarPais_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update Paises set Activo=@Activo where ID=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pais> Listar()


        {


            List<Pais> listado = new List<Pais>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {

                Datos.SettearQuery("select ID,Nombre,Activo from Paises");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())

                {
                    Pais aux_m = new Pais();

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

        public void Modificar(Pais pais)
        {
            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update Paises set Nombre=@Descripcion where ID=@id");
                datos.AgregarParametros("@Id", pais.ID);
                datos.AgregarParametros("@Descripcion", pais.Descripcion);


                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
