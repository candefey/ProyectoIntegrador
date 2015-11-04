using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoTipoRutina
    {

        private static string cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";
        public static DataSet select()
        {
            SqlConnection cn = new SqlConnection();
            DataSet ds;
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idTipoRutina, nombre, descripcion FROM TiposRutina";
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
