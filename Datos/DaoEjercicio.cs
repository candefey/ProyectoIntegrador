using System;
using System.Collections.Generic;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
   public class DaoEjercicio
    {
         private static string cadenaConex = "Data Source=ASUS-FEY;Initial Catalog=Gimnasios;Integrated Security=True";
        public static DataSet select()
        {
          SqlConnection cn = new SqlConnection();
            DataSet ds;
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idEjercicio, nombre, descripcion, tiempo FROM Ejercicios";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los gimnasios.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return ds;
        }
    }
}
