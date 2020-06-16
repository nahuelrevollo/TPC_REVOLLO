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
    public class BL_Articulo
    {

        public List<Articulo> listar()

        {

            List<Articulo> listado = new List<Articulo>();
            AccesoDatos Datos = new AccesoDatos();


            try
            {
                Datos.SettearQuery("select A.Id, A.CODIGO, A.NOMBRE, A.DESCRIPCION, A.IMAGEN_URL,A.PRECIO,M.ID, M.DESCRIPCION,R.ID," +
                    " R.DESCRIPCION,E.ID,E.DESCRIPCION,T_A.ID,T_A.TIPO,A.ACTIVO " +
                    "from ARTICULOS as A " +
                    "inner join MARCAS as M on A.ID_MARCA=M.ID " +
                    "inner join RAZAS as R on A.IdRAZA=R.ID"+
                    "inner join EDADES AS E ON A.ID_EDADES=E.ID"+
                    "inner join TIPO_ANIMALES AS T_A ON A.ID_ANIMAL=T_A.ID"
                    );
                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Raza = new Raza();
                    aux.Edad = new Edades();
                    aux.Animal = new Animal();



                    aux.ID = Datos.Lector.GetInt32(0);
                    aux.Codigo = Datos.Lector.GetString(1);
                    aux.Nombre = Datos.Lector.GetString(2);
                    aux.Descripcion = Datos.Lector.GetString(3);
                    aux.Imagen_Url = (string)Datos.Lector[4];
                    aux.Precio = (decimal)Datos.Lector[5];
                    aux.Marca.ID = Datos.Lector.GetInt32(6);
                    aux.Marca.Descripcion = Datos.Lector.GetString(7);
                    aux.Raza.ID = Datos.Lector.GetInt32(8);
                    aux.Raza.Descripcion = Datos.Lector.GetString(9);
                    aux.Edad.ID = Datos.Lector.GetInt32(10);
                    aux.Edad.Descripcion = Datos.Lector.GetString(11); 
                    aux.Animal.ID = Datos.Lector.GetInt32(12);
                    aux.Animal.Descripcion = Datos.Lector.GetString(13);
                    aux.Activo = Datos.Lector.GetBoolean(14);



                    if (aux.Activo)
                    { listado.Add(aux); }

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

        public void Modificar(Articulo nuevo_art)
        {

            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.SettearQuery("update ARTICULOS set CODIGO=@Codigo,NOMBRE=@Nombre,DESCRIPCION=@Descripcion," +
                    "ID_MARCA=@IdMarca,ID_ANIMAL=@IdAnimal,ID_RAZA=@IdRaza,ID_EDAD=@IdEdad," +
                    "IMAGEN_URL=@ImagenUrl,Precio=@Precio where ID=@id");


                datos.AgregarParametros("@Id", nuevo_art.ID);
                datos.AgregarParametros("@Codigo", nuevo_art.Codigo);
                datos.AgregarParametros("@Nombre", nuevo_art.Nombre);
                datos.AgregarParametros("@Descripcion", nuevo_art.Descripcion);
                datos.AgregarParametros("@IdMarca", nuevo_art.Marca.ID);
                datos.AgregarParametros("@IdAnimal", nuevo_art.Animal.ID);
                datos.AgregarParametros("@IdRaza", nuevo_art.Raza.ID);
                datos.AgregarParametros("@IdEdad", nuevo_art.Edad.ID);
                datos.AgregarParametros("@ImagenUrl", nuevo_art.Imagen_Url);
                datos.AgregarParametros("@Precio", nuevo_art.Precio);

                datos.EjecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarArticulo_Logica(int iD)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SettearQuery("Update ARTICULOS set ACTIVO=@Activo where ID=@ID");
                datos.AgregarParametros("@Activo", 0);
                datos.AgregarParametros("ID", iD);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Agregar(Articulo nuevo_art)


        {


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();



            try
            {
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = REVOLLO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into ARTICULOS(CODIGO,NOMBRE,DESCRIPCION,ID_MARCA,ID_ANIMAL,ID_RAZA,ID_EDAD,IMAGEN_URL,PRECIO,ACTIVO)" +
                    " values(@Codigo,@Nombre,@Descripcion,@Marca,@Animal,@Raza,@Edad,@ImagenUrl,@Precio,@activo)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Codigo", nuevo_art.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo_art.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo_art.Descripcion);
                comando.Parameters.AddWithValue("@Marca", nuevo_art.Marca.ID);
                comando.Parameters.AddWithValue("@Animal", nuevo_art.Animal.ID);
                comando.Parameters.AddWithValue("@Raza", nuevo_art.Raza.ID);
                comando.Parameters.AddWithValue("@Edad", nuevo_art.Edad.ID);
                comando.Parameters.AddWithValue("@ImagenUrl", nuevo_art.Imagen_Url);
                comando.Parameters.AddWithValue("@Precio", nuevo_art.Precio);
                comando.Parameters.AddWithValue("@activo", 1);

                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }




}

