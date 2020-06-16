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
                Datos.SettearQuery("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl,A.Precio,M.Id, M.Descripcion,C.Id, C.Descripcion,A.activo " +
                    "from ARTICULOS as A " +
                    "inner join MARCAS as M on A.IdMArca=M.Id " +
                    "inner join CATEGORIAS as C on A.IdCategoria=C.Id");
                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();



                    aux.ID = Datos.Lector.GetInt32(0);
                    aux.Codigo = Datos.Lector.GetString(1);
                    aux.Nombre = Datos.Lector.GetString(2);
                    aux.Descripcion = Datos.Lector.GetString(3);
                    aux.Imagen_Url = (string)Datos.Lector[4];
                    aux.Precio = (decimal)Datos.Lector[5];
                    aux.Marca.ID = Datos.Lector.GetInt32(6);
                    aux.Marca.Descripcion = Datos.Lector.GetString(7);
                    aux.Categoria.ID = Datos.Lector.GetInt32(8);
                    aux.Categoria.Descripcion = Datos.Lector.GetString(9);
                    aux.Activo = Datos.Lector.GetBoolean(10);



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
                datos.SettearQuery("update ARTICULOS set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,ImagenUrl=@ImagenUrl,Precio=@Precio where id=@id");
                datos.AgregarParametros("@Id", nuevo_art.ID);
                datos.AgregarParametros("@Codigo", nuevo_art.Codigo);
                datos.AgregarParametros("@Nombre", nuevo_art.Nombre);
                datos.AgregarParametros("@Descripcion", nuevo_art.Descripcion);
                datos.AgregarParametros("@IdMarca", nuevo_art.Marca.ID);
                datos.AgregarParametros("@IdCategoria", nuevo_art.Categoria.ID);
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
                datos.SettearQuery("Update ARTICULOS set activo=@Activo where Id=@ID");
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
                conexion.ConnectionString = "data source = Paprika\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,activo) values(@Codigo,@Nombre,@Descripcion,@Marca,@Categoria,@ImagenUrl,@Precio,@activo)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Codigo", nuevo_art.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo_art.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo_art.Descripcion);
                comando.Parameters.AddWithValue("@Marca", nuevo_art.Marca.ID);
                comando.Parameters.AddWithValue("@Categoria", nuevo_art.Categoria.ID);
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

