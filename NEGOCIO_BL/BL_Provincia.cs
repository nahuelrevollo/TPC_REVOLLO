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
  public  class BL_Provincia
    {
        public void Agregar(Provincia provincia)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = REVOLLO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into Provincias(IDpais,Nombre,Activo) values(@IDpais,@Descripcion,@activo)";
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@IDpais", provincia.IDpais);
                comando.Parameters.AddWithValue("@Descripcion", provincia.Descripcion);
                comando.Parameters.AddWithValue("@activo", 1);


                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void EliminarProvincia_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update Provincias set Activo=@Activo where ID=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Provincia> Listar()


        {


            List<Provincia> listado = new List<Provincia>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {

                Datos.SettearQuery("select ID,IDpais, Nombre, Activo from Provincias");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())

                {
                    Provincia aux_m = new Provincia();

                    aux_m.ID = Datos.Lector.GetInt32(0);
                    aux_m.IDpais = Datos.Lector.GetInt32(1);
                    aux_m.Descripcion = Datos.Lector.GetString(2);
                    aux_m.Activo = Datos.Lector.GetBoolean(3);

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

        public void Modificar(Provincia provincia)
        {
            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update Provincias set IDpais=@IDpais Nombre=@Descripcion where ID=@id");
                datos.AgregarParametros("@Id", provincia.ID);
                datos.AgregarParametros("@IDpais", provincia.IDpais);
                datos.AgregarParametros("@Descripcion", provincia.Descripcion);


                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
