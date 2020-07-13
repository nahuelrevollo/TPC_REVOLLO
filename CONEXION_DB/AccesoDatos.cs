using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CONEXION_DB
{
    public class AccesoDatos
    {

        public SqlDataReader Lector { get; set; }
        public SqlConnection Conexion { get; set; }

        public SqlCommand Comando { get; set; }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("data source = Paprika\\SQLEXPRESS; initial catalog = REVOLLO_DB; integrated security = sspi");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void CerrarConexion()
        {
            Conexion.Close();
        }
        public void SettearQuery(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;

        }

        public void EjecutarLector()
        {
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SettearSP(string Sp)

        {


            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = Sp;


        }

        public void AgregarParametros(string nombre, object valor)
        {
            
            Comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarAccion()
        {
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                Conexion.Close();
            }
        }
    }
}

