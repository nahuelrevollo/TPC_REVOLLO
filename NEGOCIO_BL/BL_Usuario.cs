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
    public class BL_Usuario
    {

        public void Agregar(Usuario usuario, Direccion direccion)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_Guardar_Usuario");
                Datos.AgregarParametros("@Dni", usuario.Dni);
                Datos.AgregarParametros("@Apellido", usuario.Apellido);
                Datos.AgregarParametros("@Nombre", usuario.Nombre);
                Datos.AgregarParametros("@Nick_Name", usuario.Nick_name);
                Datos.AgregarParametros("@Contraseña", usuario.Contraseña);
                Datos.AgregarParametros("@Email", usuario.Mail);
                Datos.AgregarParametros("@Sexo", usuario.Sexo);
                Datos.AgregarParametros("@telefono", usuario.Telefono);
                
                Datos.AgregarParametros("@IDprovincia", usuario.IDprovincia);
                Datos.AgregarParametros("@F_nacimiento", usuario.Fecha_Nac);

                Datos.AgregarParametros("@IDprovincia", usuario.IDprovincia);
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


        public void AgregarAdmin(Usuario usuario)

        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_Guardar_Admin");
                Datos.AgregarParametros("@Dni", usuario.Dni);
                Datos.AgregarParametros("@Apellido", usuario.Apellido);
                Datos.AgregarParametros("@Nombre", usuario.Nombre);
                Datos.AgregarParametros("@Nick_Name", usuario.Nick_name);
                Datos.AgregarParametros("@Contraseña", usuario.Contraseña);
                Datos.AgregarParametros("@Email", usuario.Mail);
                Datos.AgregarParametros("@Sexo", usuario.Sexo);
                Datos.AgregarParametros("@telefono", usuario.Telefono);

                Datos.AgregarParametros("@IDprovincia", usuario.IDprovincia);
                Datos.AgregarParametros("@F_nacimiento", usuario.Fecha_Nac);

                



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



        public int BuscarUltimo()


        {

            int ID;

            AccesoDatos Datos = new AccesoDatos();

            try
            {


                Datos.SettearSP("SP_UltimoUsuario");

                

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


        public Usuario Validar_Usuario(string nick_name)

        {

            AccesoDatos Datos = new AccesoDatos();
            Usuario usuario = new Usuario();




            try
            {


                Datos.SettearSP("SP_ValidarUsuario");
                Datos.Comando.Parameters.Clear();
                Datos.AgregarParametros("@Nick_Name", nick_name);

                Datos.EjecutarLector();
             

                if (Datos.Lector.Read())
                {


                    usuario.ID = Datos.Lector.GetInt32(0);
                    usuario.Dni = Datos.Lector.GetInt32(1);
                    usuario.Apellido = Datos.Lector.GetString(2);
                    usuario.Nombre = Datos.Lector.GetString(3);
                    usuario.Nick_name = Datos.Lector.GetString(4);
                    usuario.Contraseña = Datos.Lector.GetString(5);
                    usuario.Mail = Datos.Lector.GetString(6);
                    usuario.Sexo = Convert.ToChar(Datos.Lector.GetString(7));
                    usuario.Telefono = Datos.Lector.GetInt32(8);

                    usuario.IDprovincia = Datos.Lector.GetInt32(9);
                    usuario.IDtipo = Datos.Lector.GetInt32(10);
                    usuario.Fecha_Nac = Datos.Lector.GetDateTime(11);
                    usuario.Activo = Datos.Lector.GetBoolean(12);

                    return usuario;

                }
                else
                {

                    return usuario;

                }



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

        public Usuario Validar_Email(string mail)

        {

            AccesoDatos Datos = new AccesoDatos();
            Usuario usuario = new Usuario();



            try
            {


                Datos.SettearSP("SP_ValidarMail");
                Datos.AgregarParametros("@mail", mail);

                Datos.EjecutarLector();
               


                if (Datos.Lector.Read())
                {


                    usuario.ID = Datos.Lector.GetInt32(0);
                    usuario.Dni = Datos.Lector.GetInt32(1);
                    usuario.Apellido = Datos.Lector.GetString(2);
                    usuario.Nombre = Datos.Lector.GetString(3);
                    usuario.Nick_name = Datos.Lector.GetString(4);
                    usuario.Contraseña = Datos.Lector.GetString(5);
                    usuario.Mail = Datos.Lector.GetString(6);
                    usuario.Sexo = Convert.ToChar(Datos.Lector.GetString(7));
                    usuario.Telefono = Datos.Lector.GetInt32(8);

                    usuario.IDprovincia = Datos.Lector.GetInt32(9);
                    usuario.IDtipo = Datos.Lector.GetInt32(10);
                    usuario.Fecha_Nac = Datos.Lector.GetDateTime(11);
                    usuario.Activo = Datos.Lector.GetBoolean(12);

                    return usuario;

                }
                else
                {

                    return usuario;

                }


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


        public Usuario Loguearse(string nick_name, string password)

        {

            AccesoDatos Datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            usuario.Direccion = new Direccion();
            usuario.Direccion.Provincia = new Provincia();



            try
            {


                Datos.SettearSP("SP_LogIn");
                Datos.AgregarParametros("@Nick_Name", nick_name);
                Datos.AgregarParametros("@Password", password);

                Datos.EjecutarLector();
               



                if (Datos.Lector.Read())
                {


                    usuario.ID = Datos.Lector.GetInt32(0);
                    usuario.Dni = Datos.Lector.GetInt32(1);
                    usuario.Apellido = Datos.Lector.GetString(2);
                    usuario.Nombre = Datos.Lector.GetString(3);
                    usuario.Nick_name = Datos.Lector.GetString(4);
                    usuario.Contraseña = Datos.Lector.GetString(5);
                    usuario.Mail = Datos.Lector.GetString(6);
                    usuario.Sexo =Convert.ToChar( Datos.Lector.GetString(7));
                    usuario.Telefono = Datos.Lector.GetInt32(8);
                    
                    usuario.IDprovincia = Datos.Lector.GetInt32(9);
                    usuario.IDtipo = Datos.Lector.GetInt32(10);
                    usuario.Fecha_Nac = Datos.Lector.GetDateTime(11);
                    usuario.Activo = Datos.Lector.GetBoolean(12);
                    usuario.Direccion.Provincia.Descripcion = Datos.Lector.GetString(13);
                    usuario.Direccion.Pais = Datos.Lector.GetString(14);
                    usuario.Direccion.Provincia.IDpais = Datos.Lector.GetInt32(15);

                    return usuario;

                }
                else
                {

                    return usuario;

                }



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


        public bool ModificarDatos_Personales(Usuario usuario)

        {

            AccesoDatos Datos = new AccesoDatos();

            try
            {

                if(usuario!=null)

                {
                    Datos.SettearSP("SP_ModificarDatos_Personales");
                    
                    Datos.AgregarParametros("@ID", usuario.ID);
                    Datos.AgregarParametros("@Dni", usuario.Dni);
                    Datos.AgregarParametros("@Apellido", usuario.Apellido);
                    Datos.AgregarParametros("@Nombre", usuario.Nombre);
                    Datos.AgregarParametros("@Nick_Name", usuario.Nick_name);
                    Datos.AgregarParametros("@Email", usuario.Mail);
                    Datos.AgregarParametros("@Sexo", usuario.Sexo);
                    Datos.AgregarParametros("@Telefono", usuario.Telefono);
                    Datos.AgregarParametros("@IDprovincia", usuario.IDprovincia);
                    Datos.AgregarParametros("@F_naciemiento ", usuario.Fecha_Nac);

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


        public Usuario BuscarUsuarioX_ID(int IDusuario)

        {
            AccesoDatos Datos = new AccesoDatos();
            Usuario usuario = new Usuario();




            try
            {


                Datos.SettearSP("SP_BuscarUsuario");
                Datos.Comando.Parameters.Clear();
                Datos.AgregarParametros("@IDusurio", IDusuario);

                Datos.EjecutarLector();


                if (Datos.Lector.Read())
                {


                    usuario.ID = Datos.Lector.GetInt32(0);
                    usuario.Dni = Datos.Lector.GetInt32(1);
                    usuario.Apellido = Datos.Lector.GetString(2);
                    usuario.Nombre = Datos.Lector.GetString(3);
                    usuario.Nick_name = Datos.Lector.GetString(4);
                    usuario.Contraseña = Datos.Lector.GetString(5);
                    usuario.Mail = Datos.Lector.GetString(6);
                    usuario.Sexo = Convert.ToChar(Datos.Lector.GetString(7));
                    usuario.Telefono = Datos.Lector.GetInt32(8);

                    usuario.IDprovincia = Datos.Lector.GetInt32(9);
                    usuario.IDtipo = Datos.Lector.GetInt32(10);
                    usuario.Fecha_Nac = Datos.Lector.GetDateTime(11);
                    usuario.Activo = Datos.Lector.GetBoolean(12);

                    return usuario;

                }
                else
                {

                    return usuario;

                }



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
