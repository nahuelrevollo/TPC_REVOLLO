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
                string consulta = "select A.ID, A.Codigo, A.Nombre, A.Descripcion," +
                    "A.Imagen_Url,P.IDarticulo,P.Stock,P.PrecioVenta,P.PrecioCompra,M.ID, M.Nombre,R.ID," +
                    "R.Nombre,E.ID,E.Nombre,T_A.ID,T_A.Nombre,A.Activo " +
                    "from Articulos as A " +
                    "inner join Marcas as M on A.IDmarca=M.ID " +
                    "inner join Tipo_Razas as R on A.IDraza=R.ID " +
                    "inner join Tipo_Edades as E ON A.IDedades=E.ID " +
                    "inner join Tipo_Animales as T_A ON A.IDanimal=T_A.ID " +
                    "inner join PrecioyStock as P on A.ID=P.IDarticulo";

                Datos.SettearQuery(consulta);

                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Raza = new Raza();
                    aux.Edad = new Edades();
                    aux.Animal = new Animal();
                    aux.Precio = new PrecioyStock();



                    aux.ID = Datos.Lector.GetInt32(0);
                    aux.Codigo = Datos.Lector.GetString(1);
                    aux.Nombre = Datos.Lector.GetString(2);
                    aux.Descripcion = Datos.Lector.GetString(3);
                    aux.Imagen_Url = (string)Datos.Lector[4];
                    aux.Precio.IDarticulo = Datos.Lector.GetInt32(5);
                    aux.Precio.Stock = Datos.Lector.GetInt32(6);
                    aux.Precio.PrecioVenta = (decimal)Datos.Lector[7];
                    aux.Precio.PrecioCompra = (decimal)Datos.Lector[8];
                    aux.Marca.ID = Datos.Lector.GetInt32(9);
                    aux.Marca.Descripcion = Datos.Lector.GetString(10);
                    aux.Raza.ID = Datos.Lector.GetInt32(11);
                    aux.Raza.Descripcion = Datos.Lector.GetString(12);
                    aux.Edad.ID = Datos.Lector.GetInt32(13);
                    aux.Edad.Descripcion = Datos.Lector.GetString(14);
                    aux.Animal.ID = Datos.Lector.GetInt32(15);
                    aux.Animal.Descripcion = Datos.Lector.GetString(16);
                    aux.Activo = Datos.Lector.GetBoolean(17);



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
                datos.SettearQuery("update Articulos set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion," +
                    "IDmarca=@IdMarca,IDanimal=@IdAnimal,IDraza=@IdRaza,IDedades=@IdEdad," +
                    "Imagen_Url=@ImagenUrl where ID=@id");


                datos.AgregarParametros("@Id", nuevo_art.ID);
                datos.AgregarParametros("@Codigo", nuevo_art.Codigo);
                datos.AgregarParametros("@Nombre", nuevo_art.Nombre);
                datos.AgregarParametros("@Descripcion", nuevo_art.Descripcion);
                datos.AgregarParametros("@IdMarca", nuevo_art.Marca.ID);
                datos.AgregarParametros("@IdAnimal", nuevo_art.Animal.ID);
                datos.AgregarParametros("@IdRaza", nuevo_art.Raza.ID);
                datos.AgregarParametros("@IdEdad", nuevo_art.Edad.ID);
                datos.AgregarParametros("@ImagenUrl", nuevo_art.Imagen_Url);
                //datos.AgregarParametros("@IDPrecio", nuevo_art.Precio.IDarticulo);
                datos.AgregarParametros("@Activo", 1);


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
                datos.SettearQuery("Update Articulos set Activo=@Activo where ID=@ID");
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
                comando.CommandText = "Insert into Articulos(Codigo,Nombre,Descripcion,IDmarca,IDanimal,IDraza,IDedades,Imagen_Url,Activo)" +
                    " values(@Codigo,@Nombre,@Descripcion,@Marca,@Animal,@Raza,@Edad,@ImagenUrl,@activo)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Codigo", nuevo_art.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo_art.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo_art.Descripcion);
                comando.Parameters.AddWithValue("@Marca", nuevo_art.Marca.ID);
                comando.Parameters.AddWithValue("@Animal", nuevo_art.Animal.ID);
                comando.Parameters.AddWithValue("@Raza", nuevo_art.Raza.ID);
                comando.Parameters.AddWithValue("@Edad", nuevo_art.Edad.ID);
                comando.Parameters.AddWithValue("@ImagenUrl", nuevo_art.Imagen_Url);

                comando.Parameters.AddWithValue("@activo", 1);

                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public int BuscarUltimo()


        {

            int ID;

            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_UltimoArticulo");

                Datos.EjecutarLector();

                Datos.Lector.Read();

                ID = Datos.Lector.GetInt32(0);






                return ID;

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


        public List<Articulo> listar_AxV(int IDventa)

        {

            List<Articulo> listado = new List<Articulo>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_Listar_ArtxVenta");
                Datos.Comando.Parameters.Clear();
                Datos.AgregarParametros("@IDventa", IDventa);

                Datos.EjecutarLector();


                while (Datos.Lector.Read())

                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Raza = new Raza();
                    aux.Edad = new Edades();
                    aux.Animal = new Animal();
                    aux.Precio = new PrecioyStock();




                    aux.Nombre = Datos.Lector.GetString(0);
                    aux.Marca.Descripcion = Datos.Lector.GetString(1);
                    aux.Animal.Descripcion = Datos.Lector.GetString(2);
                    aux.Raza.Descripcion = Datos.Lector.GetString(3);
                    aux.Edad.Descripcion = Datos.Lector.GetString(4);
                    aux.Descripcion = Datos.Lector.GetString(5);
                    aux.Precio.Stock = Datos.Lector.GetInt32(6);
                    aux.Precio.PrecioVenta = (decimal)Datos.Lector[7];


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




