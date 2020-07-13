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
     public class BL_ReporteMensual
    {

        public Reporte_Mensual Traer_Reporte ()
        {
            AccesoDatos Datos = new AccesoDatos();
            Reporte_Mensual Rp = new Reporte_Mensual();

            try
            {
                Datos.SettearSP("SP_ReporteMensual");

                Datos.EjecutarLector();

                Datos.Lector.Read();

                Rp.Mes = Datos.Lector.GetInt32(0);
                Rp.Año = Datos.Lector.GetInt32(1);
                Rp.Ventas_Mensual = Datos.Lector.GetInt32(2);
                Rp.Envios_Mensual = Datos.Lector.GetInt32(3);
                Rp.Retiros_Mensual = Datos.Lector.GetInt32(4);
                Rp.Total_Vendido = Datos.Lector.GetInt32(5);

                return Rp;
              
            }
            catch (Exception ex)
            {

                throw ex;
            }


            


        }


    }
}
